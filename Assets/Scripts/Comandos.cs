using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Comandos {
	public Dictionary<string, System.Action<string, Text>> lista = new Dictionary<string, System.Action<string, Text>>();

	public Comandos(){
		this.lista.Add ("/help", (param_comando, textos)=>{
			textos.text = "Informações de Uso dos Comandos.\n"
				+"/limpar -\t Limpa os textos do terminal.\n"
				+"/sair -\t Finaliza o jogo.\n";
		});

		this.lista.Add("/limpar", (param_comando, textos)=>{
			textos.text = "";
		});

		this.lista.Add("/sair", (param_comando, textos)=>{
			Application.Quit();
		});
	}
}
