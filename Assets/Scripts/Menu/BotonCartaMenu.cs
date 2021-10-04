using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonCartaMenu : MonoBehaviour
{
	InfoCarta info;
	public int indice;

	public Image imFoto;
	public Button boton;

	public void Inicializar(InfoCarta _info, int _indice)
	{
		boton = GetComponent<Button>();
		info = _info;
		indice = _indice;
		imFoto.sprite = info.foto;
		Desactivar();
	}

	public void Desactivar()
	{
		boton.image.color = Color.black;
	}

	public void Activar()
	{
		SelectorCartas.singleton.Seleccionar(indice);
		Color c = Color.black;
		for (int i = 0; i < SelectorCartas.singleton.seleccionadas.Count; i++)
		{
			if (SelectorCartas.singleton.seleccionadas[i] == indice)
			{
				c = Color.green;
			}
		}
		boton.image.color = c;
	}

	public void MostrarInfo()
	{
		SelectorCartas.singleton.MostrarIniformacion(indice);
	}
}
[System.Serializable]
public class InfoCarta
{
	public string nombre;
	public string descripcion;
	public Sprite foto;
}
