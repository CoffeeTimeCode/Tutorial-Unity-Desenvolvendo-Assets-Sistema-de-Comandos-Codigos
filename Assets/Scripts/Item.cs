using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item {
	public string nome;
	public int valor;

	public Item(string nome, int valor){
		this.nome = nome;
		this.valor = valor;
	}
}
