using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public Menu CurrentMenu;
		
	void Start(){
		ShowMenu(CurrentMenu);
	}

	public void ShowMenu(Menu menu){
		if(CurrentMenu != null){
			CurrentMenu.IsOpen = false;
		}

		CurrentMenu = menu;
		CurrentMenu.IsOpen = true;
	}

	public void StartLevel(){
		Application.LoadLevel("Demo");
	}

	public void ExitGame(){
		Application.Quit();
	}
}
