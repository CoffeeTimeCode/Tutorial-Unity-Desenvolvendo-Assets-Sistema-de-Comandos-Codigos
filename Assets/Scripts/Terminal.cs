using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Terminal : MonoBehaviour {
	private Comandos _comandos = new Comandos();

	public GameObject _terminal;
	public InputField _comando;
	public Text _textos;

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftControl)&&Input.GetKeyDown(KeyCode.T)){
			this._terminal.SetActive (!this._terminal.activeSelf);
			this._comando.ActivateInputField ();
		}

		if(this._comando.isFocused && this._comando.text!="" && Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)){
			this.executar (this._comando.text, "");	
		}

	}

	public void executar(string comando, string parametros){
		System.Action<string, Text> temp;

		if(this._comandos.lista.TryGetValue(comando, out temp)){
			temp.Invoke (parametros, this._textos);
		}else{
			this._textos.text = "Este comando/código não é valido.";
		}
	}
}
