using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

	public void GoPlay(){ Application.LoadLevel(1);}// play menu
	public void GoOptions(){ Application.LoadLevel(2);}// options menu
	public void ExitGame(){ Application.Quit();}// exits game

}//end class