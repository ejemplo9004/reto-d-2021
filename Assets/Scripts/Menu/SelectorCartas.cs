using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorCartas : MonoBehaviour
{
    public List<int> seleccionadas = new List<int>();
	public static SelectorCartas singleton;
	public GameObject botonPrefab;
	public Transform padre;
	public InfoCarta[] infos;
	public List<BotonCartaMenu> botonesCartas = new List<BotonCartaMenu>();
	[Header("Previa")]
	public Image imFoto;
	public Text txtNombre;
	public Text txtDescripcion;

    void Awake()
    {
		singleton = this;
    }
	private void Start()
	{
		for (int i = 0; i < infos.Length; i++)
		{
			BotonCartaMenu btn = Instantiate(botonPrefab, padre).GetComponent<BotonCartaMenu>();
			btn.Inicializar(infos[i], i);
			botonesCartas.Add(btn);
			if (i<4)
			{
				btn.Activar();
			}
		}
		MostrarIniformacion(0);
	}

	public void MostrarIniformacion(int cual)
	{
		imFoto.sprite = infos[cual].foto;
		txtDescripcion.text = infos[cual].descripcion;
		txtNombre.text = infos[cual].nombre;
	}

	public void Seleccionar(int cual)
	{
        bool activo = false;
		for (int i = 0; i < seleccionadas.Count; i++)
		{
			if (seleccionadas[i] == cual)
			{
				activo = true;
			}
		}
		if (activo)
		{
			Desactivar(cual);
		}
		else
		{
			Activar(cual);
		}

		if (seleccionadas.Count > 0)
		{
			PlayerPrefs.SetInt("c0", seleccionadas[0]);
		}
		else
		{
			PlayerPrefs.SetInt("c0", -1);
		}
		if (seleccionadas.Count > 1)
		{
			PlayerPrefs.SetInt("c1", seleccionadas[1]);
		}
		else
		{
			PlayerPrefs.SetInt("c1", -1);
		}

		if (seleccionadas.Count > 2)
		{
			PlayerPrefs.SetInt("c2", seleccionadas[2]);
		}
		else
		{
			PlayerPrefs.SetInt("c2", -1);
		}
		if (seleccionadas.Count > 3)
		{
			PlayerPrefs.SetInt("c3", seleccionadas[3]);
		}
		else
		{
			PlayerPrefs.SetInt("c3", -1);
		}
	}

	public void Desactivar(int cual)
	{
		print("Desactivando a " + cual);
		/*for (int i = 0; i < seleccionadas.Count; i++)
		{
			if (seleccionadas[i] == cual)
			{
				seleccionadas.RemoveAt(i);
				return;
			}
		}*/
		seleccionadas.Remove(cual);
	}
	public void Activar(int cual)
	{
		seleccionadas.Add(cual);
		while (seleccionadas.Count > 4)
		{
			botonesCartas[seleccionadas[0]].Desactivar();
			seleccionadas.RemoveAt(0);
		}
	}
}
