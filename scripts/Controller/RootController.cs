using UnityEngine;
using System.Collections;

public class RootController : MonoBehaviour {
	
	
	OTSprite sprite;
	private RootModel model;
	private ResourceController resourceController;
	
	public float resourceProcessMinTime;
	private float timeSinceLastCollision;
	
	
	private float timeSinceRootLifeStart;

/////////////////////////////////////////////////////////////////////////////////////////////
	
	void Awake()
	{
		sprite = GetComponent<OTSprite>();
		model = GetComponent<RootModel>();
		//resourceController = GameObject.Find(Constants.ResourceGameObject).GetComponent<Resourc
	}
	
	void Start ()
	{		
		timeSinceLastCollision = resourceProcessMinTime;
		timeSinceRootLifeStart = 0f;
		
		sprite.onMouseEnterOT = onMouseEnter;
		sprite.onMouseExitOT = onMouseExit;
		sprite.onInput = onInput;
	}
	
	void Update()
	{
		if(model.getRootState() == Constants.rootStateLocked)
		{
			
		}
		
		else if(model.getRootState() == Constants.rootStateLive)
		{
			sprite.registerInput = false;
			
			timeSinceLastCollision += Time.deltaTime;
	
			if(model.getTimeSinceRootLifeStart() > model.rootLifeTime)
			{
				//killRoot();
			}
		}
		
		else //root state is dead
		{
			sprite.registerInput = true;
		}

	}

/////////////////////////////////////////////////////////////////////////////////////////////
	
	void killRoot()
	{
		sprite.collidable = true;
		sprite.registerInput = true;
		model.setRootState(Constants.rootStateDead);
		model.resetTimeSinceRootLifeStart();
	}
	
	void startRoot(string type, string state)
	{
		switch(state)
		{
		case(Constants.rootStateLocked):
			sprite.registerInput = false;
			sprite.alpha = 1f;
			break;
			
		case(Constants.rootStateLive):
			sprite.registerInput = false;
			sprite.collidable = true;
			model.resetTimeSinceRootLifeStart();
			break;
		}
		model.setRootTypeAndState(type, state);
		
		rootStartedCallbacks();
	}
	
	void rootStartedCallbacks()
	{
		TriadModel tModel = GameObject.Find(sprite.transform.parent.name).GetComponent<TriadModel>();
		if(sprite.name.IndexOf(Constants.rootLeft) != -1)
		{
			tModel.onLeftRootStarted();
		}
		else if(sprite.name.IndexOf(Constants.rootTop) != -1)
		{
			tModel.onTopRootStarted();
		}
		else if(sprite.name.IndexOf(Constants.rootRight) != -1)
		{
			tModel.onRightRootStarted();
		}
	}
	
	
/////////////////////////////////////////////////////////////////////////////////////////////	
	
	public void onMouseEnter(OTObject owner)
	{
		//TODO need to make sure that we have the green texture
		if(model.getRootState() == Constants.rootStateDead)
		{
			sprite.alpha = .5f;	
		}
	}
	
	public void onMouseExit(OTObject owner)
	{
		//TODO need to make sure that we have the green texture
		if(model.getRootState() == Constants.rootStateDead)
		{
			sprite.alpha = 0f;	
		}
	}
	
	public void onInput(OTObject owner)
	{
		if(Input.GetMouseButtonDown(0))
        {
			startRoot(Constants.rootTypeSection, Constants.rootStateLive);
        }
	}
	
	public void OnCollision(OTObject owner)
	{
    	
	} 
}
