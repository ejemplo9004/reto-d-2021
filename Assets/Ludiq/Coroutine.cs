using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Ludiq;
using Bolt;
using System.Threading;
using System.Threading.Tasks;

namespace Lasm.BoltAddons
{

    [UnitTitle("Coroutine")]
    [TypeIcon(typeof(WaitUnit))]
    [UnitCategory("Wait")]
    public class Coroutine : Unit
    {
        [Serialize]
        public GraphReference reference;

        [DoNotSerialize]
        ControlInput enter;
        [DoNotSerialize]
        ValueInput condition;

        [DoNotSerialize]
        ControlOutput entered, loop, exit;

        [DoNotSerialize]
        ValueOutput routine, coroutineRunner;

        CoroutineRunner runner;
        UnityEngine.Coroutine uCoroutine;

        protected override void Definition()
        {
            isControlRoot = true;
            enter = ControlInput("enter", new Func<Flow, ControlOutput>(Enter));

            entered = ControlOutput("entered");
            loop = ControlOutput("loop");
            exit = ControlOutput("exit");

            condition = ValueInput<bool>("condition", false);

            Func<Flow, UnityEngine.Coroutine> routineFunc = getRoutine => RoutineReturn();
            routine = ValueOutput<UnityEngine.Coroutine>("routine", routineFunc);

            Func<Flow, CoroutineRunner> coroutineRunnerFunc = getCoroutineRunner => CoroutineRunnerReturn();
            coroutineRunner = ValueOutput<CoroutineRunner>("coroutineRunner", coroutineRunnerFunc);
        }

        public ControlOutput Enter(Flow flow)
        {
            reference = flow.stack.AsReference();
            Flow.New(reference).StartCoroutine(entered);

            runner = CoroutineRunner.instance;
            uCoroutine = runner.StartCoroutine(Routine());

            return null;
        }

        public IEnumerator Routine()
        {
            bool canExit = true;
            while (Flow.New(reference).GetValue<bool>(condition))
            {
                Flow loopFlow = Flow.New(reference);
                loopFlow.StartCoroutine(loop);

                if (coroutineRunner == null)
                {
                    canExit = false;
                    break;
                }
                yield return null;
            }

            if (canExit)
            {
                Flow exitFlow = Flow.New(reference);
                exitFlow.StartCoroutine(exit);
            }
        }

        public UnityEngine.Coroutine RoutineReturn()
        {
            return uCoroutine;
        }

        public CoroutineRunner CoroutineRunnerReturn()
        {
            return runner;
        }
    }

}