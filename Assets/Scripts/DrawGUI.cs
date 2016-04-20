using UnityEngine;
using System.Collections;

public class DrawGUI : MonoBehaviour {

	// Use this for initialization
	void OnGUI()
	{
		GUIStyle style = new GUIStyle ();
		style.font = (Font)Resources.Load ("Demolition Crack Black", typeof(Font));
		style.fontSize = 25;
		GUI.Label (new Rect (10, 80, 100, 20), "DINO DEFENCE", style);
	}
}
