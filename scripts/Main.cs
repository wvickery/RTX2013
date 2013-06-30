using UnityEngine;
using System.Collections;

public class Main: MonoBehaviour {
	
	
	private bool initialized = false;
	// Use this for application initialization
	void Initialize () {
	  	//TODO initialize
		// - game controller
		// - the root grid and calculate the positions
		// - bring up spring background and grid overlay
	
		initialized = true;
	}
	
	// Update is called once per frame
	void Update () {
        // Only go one when Orthello is initialized
        if (!OT.isValid)
		{
			return;
		}

        // Call initialization once from this Update() so we can be sure all
        // Orthello objects have been started
        if (!initialized)
		{
            Initialize();
		}
	}
}
