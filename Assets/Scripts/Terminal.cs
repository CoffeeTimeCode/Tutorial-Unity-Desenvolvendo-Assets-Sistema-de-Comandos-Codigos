using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Terminal : MonoBehaviour {
	private Comandos _comandos;

	public GameObject _terminal;
	public InputField _comando;
	public Text _textos;

	void Start(){
		_comandos = new Comandos(GameObject.FindObjectOfType<ListaDeUsuarios>());
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftControl)&&Input.GetKeyDown(KeyCode.T)){
			this._terminal.SetActive (!this._terminal.activeSelf);
			this._comando.ActivateInputField ();
		}

		if(this._comando.isFocused && this._comando.text!="" && Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)){
			this.analisar();
		}

	}

	public void analisar(){
		string[] temp = this._comando.text.ToString().Split(' ');

		if(this._comando.text.ToString().Contains("-u")){
			this.executar(temp[0],temp[2]);
		}else{
			this.executar(this._comando.text.ToString(),"");
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
