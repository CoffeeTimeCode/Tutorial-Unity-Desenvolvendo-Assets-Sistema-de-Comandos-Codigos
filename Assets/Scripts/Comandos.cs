using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Comandos {
	public Dictionary<string, System.Action<string, Text>> lista = new Dictionary<string, System.Action<string, Text>>();
	private ListaDeUsuarios _listaU;

	public Comandos(ListaDeUsuarios lista_usuario){		
		this._listaU = lista_usuario;
		this.lista.Add ("/help", (param_comando, textos)=>{
			textos.text = "Informações de Uso dos Comandos.\n"
				+"-u -\t Para comandos com um pârametro\n\n"
				+"/limpar -\t Limpa os textos do terminal.\n"
				+"/luz -\t Alterar luzes da cena.\n"
				+"/dinheiro -\t Adiciona 500 de dinheiro pelo nome do usuário.\n"
				+"/sair -\t Finaliza o jogo.\n";
		});

		this.lista.Add("/limpar", (param_comando, textos)=>{
			textos.text = "";
		});

		this.lista.Add("/sair", (param_comando, textos)=>{
			Application.Quit();
		});

		this.lista.Add("/luz", (param_comando, textos)=>{
			Light[] temp = GameObject.FindObjectsOfType<Light>(); 
			foreach (var item in temp) {
				item.enabled = bool.Parse(param_comando);
			}
			textos.text += "Todas as luzes forão alteradas.\n";
		});

		this.lista.Add("/dinheiro", (param_comando, textos)=>{
			foreach (var item in _listaU._usuarios) {
				if(item._nome.Equals(param_comando)){
					item._dinheiro+=500;
					textos.text += "Valor Adicionado ao usuário: "+item._nome+"\n";
					break;
				}
			}
		});
	}
}
