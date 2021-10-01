// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:Standard,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33597,y:32610,varname:node_3138,prsc:2|emission-4549-OUT,olwid-6487-OUT;n:type:ShaderForge.SFN_NormalVector,id:9936,x:32265,y:32820,prsc:2,pt:False;n:type:ShaderForge.SFN_LightVector,id:2986,x:32265,y:32672,varname:node_2986,prsc:2;n:type:ShaderForge.SFN_Dot,id:4606,x:32469,y:32731,varname:node_4606,prsc:2,dt:0|A-2986-OUT,B-9936-OUT;n:type:ShaderForge.SFN_Tex2d,id:9571,x:32777,y:32214,ptovrint:False,ptlb:Fondo,ptin:_Fondo,varname:node_9571,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Step,id:9659,x:32540,y:32566,varname:node_9659,prsc:2|A-9827-OUT,B-4606-OUT;n:type:ShaderForge.SFN_Slider,id:9827,x:32186,y:32569,ptovrint:False,ptlb:Sombreado,ptin:_Sombreado,varname:node_9827,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.474359,max:1;n:type:ShaderForge.SFN_Slider,id:9128,x:32581,y:32916,ptovrint:False,ptlb:IntensidadSombra,ptin:_IntensidadSombra,varname:node_9128,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:2;n:type:ShaderForge.SFN_Vector3,id:3758,x:32738,y:32724,varname:node_3758,prsc:2,v1:1,v2:1,v3:1;n:type:ShaderForge.SFN_Multiply,id:9410,x:32918,y:32749,varname:node_9410,prsc:2|A-3758-OUT,B-9128-OUT;n:type:ShaderForge.SFN_Add,id:1799,x:32834,y:32564,varname:node_1799,prsc:2|A-9659-OUT,B-9410-OUT,C-2502-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6487,x:32847,y:33121,ptovrint:False,ptlb:Grosor,ptin:_Grosor,varname:node_6487,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:4549,x:33076,y:32464,varname:node_4549,prsc:2|A-5228-OUT,B-1799-OUT;n:type:ShaderForge.SFN_Max,id:8828,x:33169,y:32609,varname:node_8828,prsc:2|A-1799-OUT,B-8189-OUT;n:type:ShaderForge.SFN_Vector1,id:8189,x:32925,y:32664,varname:node_8189,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Divide,id:5228,x:33089,y:32293,varname:node_5228,prsc:2|A-9571-RGB,B-879-OUT;n:type:ShaderForge.SFN_Vector1,id:879,x:32803,y:32409,varname:node_879,prsc:2,v1:2.5;n:type:ShaderForge.SFN_Divide,id:2702,x:32388,y:32344,varname:node_2702,prsc:2|A-9827-OUT,B-8956-OUT;n:type:ShaderForge.SFN_Vector1,id:8956,x:32181,y:32331,varname:node_8956,prsc:2,v1:2;n:type:ShaderForge.SFN_Step,id:2502,x:32540,y:32401,varname:node_2502,prsc:2|A-2702-OUT,B-4606-OUT;proporder:9571-9827-9128-6487;pass:END;sub:END;*/

Shader "Morion/Morion 7" {
    Properties {
        _Fondo ("Fondo", 2D) = "white" {}
        _Sombreado ("Sombreado", Range(0, 1)) = 0.474359
        _IntensidadSombra ("IntensidadSombra", Range(0, 2)) = 0.5
        _Grosor ("Grosor", Float ) = 0
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "Outline"
            Tags {
            }
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma target 3.0
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _Grosor)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 pos : SV_POSITION;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                float _Grosor_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Grosor );
                o.pos = UnityObjectToClipPos( float4(v.vertex.xyz + v.normal*_Grosor_var,1) );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                return fixed4(float3(0,0,0),0);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma target 3.0
            uniform sampler2D _Fondo; uniform float4 _Fondo_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _Sombreado)
                UNITY_DEFINE_INSTANCED_PROP( float, _IntensidadSombra)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
////// Emissive:
                float4 _Fondo_var = tex2D(_Fondo,TRANSFORM_TEX(i.uv0, _Fondo));
                float _Sombreado_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Sombreado );
                float node_4606 = dot(lightDirection,i.normalDir);
                float _IntensidadSombra_var = UNITY_ACCESS_INSTANCED_PROP( Props, _IntensidadSombra );
                float3 node_1799 = (step(_Sombreado_var,node_4606)+(float3(1,1,1)*_IntensidadSombra_var)+step((_Sombreado_var/2.0),node_4606));
                float3 emissive = ((_Fondo_var.rgb/2.5)*node_1799);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma target 3.0
            uniform sampler2D _Fondo; uniform float4 _Fondo_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float, _Sombreado)
                UNITY_DEFINE_INSTANCED_PROP( float, _IntensidadSombra)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
////// Lighting:
                float3 finalColor = 0;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Standard"
    CustomEditor "ShaderForgeMaterialInspector"
}
