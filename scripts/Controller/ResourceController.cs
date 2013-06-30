using UnityEngine;
using System.Collections;

public class ResourceController: MonoBehaviour {


	public int[] resources;
	
	public int initialRoots; 
	public int initialCOtwo;
	public int initialNtwo;
	public int initialP;
	
	void Start()
	{
		//resources[Constants.indexCOtwo] = initialCOtwo;
	//	resources[Constants.indexNtwo]  = initialNtwo;
		//resources[Constants.indexP]     = initialP;	
		//resources[Constants.indexRoots] = initialRoots;
	}
	
	public int getResourceAmount(int resourceIndex)
	{
		Debug.Log (resourceIndex);
		return resources[resourceIndex];
	}
	
	public void addResourceAmount(int resourceIndex, int amount)
	{
		resources[resourceIndex] += amount;
		Debug.Log (resourceIndex);		
	}
	
	public void StupidStatment()
	{
		Debug.Log ("Weird Kid");		
	}
	
	void removeResourceAmount(int resourceIndex, int amount)
	{
		resources[resourceIndex] -= amount;
	}
}
