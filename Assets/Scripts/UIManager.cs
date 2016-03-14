using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public void GoPlay()
	{
		Application.LoadLevel(1);
	}

	public void GoOptions()
	{
		Application.LoadLevel(2);
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
