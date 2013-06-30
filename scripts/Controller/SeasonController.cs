using UnityEngine;
using System.Collections;

public class SeasonController : MonoBehaviour
{
	public Texture[] babySeasons = new Texture[4];
	public Texture[] teenSeasons = new Texture[4];
	public Texture[] adultSeasons = new Texture[4];
	
	public float seasonChangeTime;
	public float seasonLength;
	
	private GameController gameController;
	
	private OTSprite seasonSprite;
	private OTSprite nextSeasonSprite;
	
	private OTTween fadeTween;
	
	private string currentSeason;
	private float currentSeasonTime;
	
	private bool fading;
	
	
	void Start()
	{
		gameController = GameObject.Find("GameController").GetComponent<GameController>();
		seasonSprite = GameObject.Find("SeasonSprite").GetComponent<OTSprite>();
		nextSeasonSprite = GameObject.Find("NextSeasonSprite").GetComponent<OTSprite>();
		
		currentSeason = Constants.seasonSpring;
		currentSeasonTime = 0f;
		fading = false;
	}
	
	void Update()
	{
		if(currentSeasonTime > seasonLength && !fading)
		{
			fadeIn();
			currentSeasonTime = 0f;
		}
		else{
			currentSeasonTime += Time.deltaTime;
		}
	}
	
	public string getCurrentSeason()
	{
		return currentSeason;
	}
	
	void changeSeason()
	{
		//setTweens(seasonSprite,nextSeasonSprite);
	}
	
	void fadeIn()
	{
		fading = true;
		fadeTween = new OTTween(GameObject.Find("SeasonSprite").GetComponent<OTSprite>(), seasonChangeTime, OTEasing.Linear).Tween("alpha",1f,0f,OTEasing.Linear);
		fadeTween.onTweenFinish = onFadeInDone;
	}	
	
	void onFadeInDone(OTTween tween)
	{
	  	seasonSprite.image = nextSeasonSprite.image;
		seasonSprite.alpha = 1;
		nextSeasonSprite.image = nextSeason(nextSeasonSprite.image.name);
		currentSeasonTime = 0f;
		fading = false;
	}
	
	Texture nextSeason(string current)
	{
		Texture nextSeason = null;
		
		if(current.IndexOf(Constants.stageBaby) != -1)
		{
			if(current.IndexOf(Constants.seasonSpring) != -1)				
					nextSeason = babySeasons[1];
			if(current.IndexOf(Constants.seasonSummer) != -1)				
					nextSeason = babySeasons[2];
			if(current.IndexOf(Constants.seasonAutumn) != -1)				
					nextSeason = babySeasons[3];
			if(current.IndexOf(Constants.seasonWinter) != -1)				
					nextSeason = teenSeasons[0];
		}	
		else if(current.IndexOf(Constants.stageTeen) != -1)
		{
			if(current.IndexOf(Constants.seasonSpring) != -1)				
					nextSeason = teenSeasons[1];
			if(current.IndexOf(Constants.seasonSummer) != -1)				
					nextSeason = teenSeasons[2];
			if(current.IndexOf(Constants.seasonAutumn) != -1)				
					nextSeason = teenSeasons[3];
			if(current.IndexOf(Constants.seasonWinter) != -1)				
					nextSeason = adultSeasons[0];
		}		
		else if(current.IndexOf(Constants.stageAdult) != -1)
		{
			if(current.IndexOf(Constants.seasonSpring) != -1)				
					nextSeason = adultSeasons[1];
			if(current.IndexOf(Constants.seasonSummer) != -1)				
					nextSeason = adultSeasons[2];
			if(current.IndexOf(Constants.seasonAutumn) != -1)				
					nextSeason = adultSeasons[3];
			if(current.IndexOf(Constants.seasonWinter) != -1)				
					nextSeason = babySeasons[0];
		}
		return nextSeason;
	}
	
	int seasonToIndex(string season)
	{
		switch (season)
		{
			case Constants.seasonSpring:
				return 0;
			case Constants.seasonSummer:
				return 1;
			case Constants.seasonAutumn:
				return 2;
			case Constants.seasonWinter:
				return 3;
		}
		return 0;
	}
	
}	
//	private float seasonTime;
//	private string seasonState;
//	
//	public string initialSeason;
//	
//	void Start ()
//	{
//		seasonTime = 0f;
//		seasonState = initialSeason;
//	}
//	
//	void Update ()
//	{
//	
//	}
//	
//	void incrementSeasonTime()
//	{
//		seasonTime += Time.deltaTime;
//	}
//	
//	string getSeasonState()
//	{
//		return seasonState;
//	}
//	
//	void initializeSeason()
//	{
//	}
//	
//	string getNextSeason()
//	{
//		string nextSeason;
//		
//		switch (seasonState)
//		{
//			case Constants.seasonSpring:
//				nextSeason = Constants.seasonSummer;
//				break;
//			case Constants.seasonSummer:
//				nextSeason = Constants.seasonAutumn;
//				break;
//			case Constants.seasonAutumn:
//				nextSeason = Constants.seasonWinter;
//				break;
//			case Constants.seasonWinter:
//				nextSeason = Constants.seasonSpring;
//				break;
//			
//			default:
//				nextSeason = Constants.seasonSpring;
//				break;	
//		}
//		
//		return nextSeason;
//	}
//	
//}

