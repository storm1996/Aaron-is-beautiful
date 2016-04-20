using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public void GoMain()
	{ 
		Application.LoadLevel(0);
	}

	public void GoPlay()
	{ 
		Application.LoadLevel(1);
	}

	public void ExitGame()
	{ 
		Application.Quit();
	}

}