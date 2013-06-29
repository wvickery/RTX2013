using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DebugWindow : MonoBehaviour {
	
	private static bool debug = false;
	private GUIStyle style;

	void Start(){
		style = new GUIStyle();
		style.wordWrap = true;
		style.alignment = TextAnchor.UpperLeft;
	}
	
	/*
	 * toggleDisplay()
	 * 
	 * Toggles the display of debug information.
	 * 
	 */
	public static void ToggleDisplay(){
		debug = !debug;
	}
	
	void OnGUI(){
		if(debug){
			
			string info = "";
			Dictionary<string, float> dict = DebugInfo.GetInfo();
			
			foreach(KeyValuePair<string, float> entry in dict){	
				string key = entry.Key;
				float val = entry.Value;
				
				//coordinate info for mouse always starts with "mouse"
				if(key.StartsWith("mouse")){
					if(key.EndsWith("X")) info += "\nMouse: ("+val+", ";
					else if(key.EndsWith("Y")) info +=  val+")";
				}
				
				//coordinate info for player always starts with "player"
				//NOTE: Player state info is being passed from the PlayerMovement class.
				else if(key.StartsWith("player")){
					if(key.EndsWith("X")) info += "\nPlayer: ("+val+", ";
					else if(key.EndsWith("Y")) info +=  val+", ";
					else if(key.EndsWith("Z")) info +=  val+")";
				}
				
				else info += "\n" + key + ": " + val;
				
			}
			//NOTE: The box takes up the whole screen; we may or may not want to change this.
			GUI.Box (new Rect(0,0,Screen.width,Screen.height), info, style);
		}
	}
	
	void Update(){
		if(debug){
			DebugInfo.SetValue("Framerate", 1.0f / Time.deltaTime);
		}
	}
	
	void FixedUpdate(){
		if(debug){
			DebugInfo.SetValue("mouseX", Input.mousePosition.x);
			DebugInfo.SetValue("mouseY", Input.mousePosition.y);
		}
	}
}
