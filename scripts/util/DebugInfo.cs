using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DebugInfo : MonoBehaviour{
	private static Dictionary<string, float> info = new Dictionary<string, float>();
	
	public void Start(){
		info["Framerate"] = 0.0f;
		ResetMouseCoords();
		ResetPlayerCoords();
	}
	
	//NOTE: These functions are probably unnecessary.
	//		They're mainly used for priming the dictionary with these entries.
	private void ResetMouseCoords(){
		info["mouseX"] = float.PositiveInfinity;
		info["mouseY"] = float.PositiveInfinity;
	}
	private void ResetPlayerCoords(){
		info["playerX"] = float.PositiveInfinity;
		info["playerY"] = float.PositiveInfinity;
		info["playerZ"] = float.PositiveInfinity;
	}
	
	
	/*
	 *	SetValue(string, float)
	 *
	 *	If the key exists in the dictionary, its value is updated.
	 *	Otherwise, an entry is created for it.
	 *
	 */
	public static void SetValue(string key, float val){
		if(info.ContainsKey(key)) 
			info[key] = val;
		else 
			info.Add(key, val);
	}
	
	/*
	 * RemoveEntry(string)
	 * 
	 * Removes the dictionary entry that matches the given key.
	 * 
	 */
	public static void RemoveEntry(string key){
		if(info.ContainsKey(key)) info.Remove(key);
		//else What do?
	}
	
	/*
	 * GetInfo()
	 * 
	 * Returns the Dictionary of debug information.
	 * Mainly used in the DebugWindow class, so try to avoid calling
	 * it in other scripts unless absolutely necessary.
	 * 
	 */
	public static Dictionary<string, float> GetInfo(){
		return info;
	}
	
	
}
