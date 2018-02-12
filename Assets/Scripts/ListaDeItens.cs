using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaDeItens : MonoBehaviour {

	public List<Item> _itens = new List<Item>();

	void Start () {
		_itens.Add(new Item("Poção de Vida",200));
		_itens.Add(new Item("Espada",500));
		_itens.Add(new Item("Poção de Vida(l)",320));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
