using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
  
	private string stateSeason;
	private RootController rootController;
	private ResourceController resourceController;
	private Storeopen storeOpen;
	private SeasonController seasonController;
	private TriadModel triadModel;
	
	
		void Awake()
	{
		
	}
	
	
	// Use this for initialization
	void Start () {
		rootController = GameObject.Find("Root").GetComponent<RootController>();
		resourceController = GameObject.Find("ResourceController").GetComponent<ResourceController>();
		storeOpen = GameObject.Find("Main Camera").GetComponent<Storeopen>();
		seasonController = GameObject.Find("SeasonController").GetComponent<SeasonController>();
		triadModel = GameObject.Find("Triad").GetComponent<TriadModel>();
		//resourceController = GameObject.Find("ResourceController").GetComponent<ResourceController>();
				
	}
	
	// Update is called once per frame
	void Update () {
    		resourceController.StupidStatment();
			if(Input.GetMouseButtonDown(0))
				resourceController.addResourceAmount(1,1);
	}
}
