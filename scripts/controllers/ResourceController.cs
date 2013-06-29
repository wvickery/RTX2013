using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	private int indexCOtwo = 0;
	private int indexNtwo = 1;
	private int indexP = 2;
	private int[] resources;
	
	public int initialCOtwo;
	public int initialNtwo;
	public int initialP;
	
	void Start()
	{
		resources[indexCOtwo] = initialCOtwo;
		resources[indexNtwo]  = initialNtwo;
		resources[indexP] 	  = initialP;		
	}
	
	int getResourceAmount(int resourceIndex)
	{
		return resources[resourceIndex];
	}
	
	void addResourceAmount(int resourceIndex, int amount)
	{
		resources[resourceIndex] += amount;
	}
	
	void removeResourceAmount(int resourceIndex, int amount)
	{
		resources[resourceIndex] -= amount;
	}
}
