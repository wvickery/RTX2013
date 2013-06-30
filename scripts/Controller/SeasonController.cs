using UnityEngine;
using System.Collections;

public class SeasonController : MonoBehaviour
{
	private float seasonTime;
	private string seasonState;
	
	public string initialSeason;
	
	void Start ()
	{
		seasonTime = 0f;
		seasonState = initialSeason;
	}
	
	void Update ()
	{
	
	}
	
	void incrementSeasonTime()
	{
		seasonTime += Time.deltaTime;
	}
	
	string getSeasonState()
	{
		return seasonState;
	}
	
	void initializeSeason()
	{
	}
	
	string getNextSeason()
	{
		string nextSeason;
		
		switch (seasonState)
		{
			case Constants.seasonSpring:
				nextSeason = Constants.seasonSummer;
				break;
			case Constants.seasonSummer:
				nextSeason = Constants.seasonAutumn;
				break;
			case Constants.seasonAutumn:
				nextSeason = Constants.seasonWinter;
				break;
			case Constants.seasonWinter:
				nextSeason = Constants.seasonSpring;
				break;
			
			default:
				nextSeason = Constants.seasonSpring;
				break;	
		}
		
		return nextSeason;
	}
	
}

