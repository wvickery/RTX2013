using UnityEngine;
using System.Collections;

public class RootModel : MonoBehaviour
{
	OTSprite sprite;

	public Texture rootTextureLiveBase;
	public Texture rootTextureLiveSection;
	public Texture rootTextureLiveTip; 
	
	public Texture rootTextureLockedBase;
	public Texture rootTextureLockedSection;
	public Texture rootTextureLockedTip;
	
	private string rootType;
	private string rootState;
	
	public float rootLifeTime;
	private float timeSinceRootCreation;

	void Awake()
	{
		sprite = GetComponent<OTSprite>();
	}	
	
	void Update()
	{
		if(rootState == Constants.rootStateLive)
		{			
			timeSinceRootCreation += Time.deltaTime;
		}
	}

/////////////////////////////////////////////////////////////////////////////////////////////	
	
	public void initialize(string type, string state)
	{		
		timeSinceRootCreation = 1f;
		
		rootType = Constants.rootTypeSection;
		rootState = Constants.rootStateDead;
		
		setImageFromTypeState(rootType,rootState);
	}
	
/////////////////////////////////////////////////////////////////////////////////////////////	
		
	void setPosition(float x, float y)
	{
		sprite.position = new Vector2(x,y);
	}
	
	void setSize(float x, float y)
	{
		sprite.size	= new Vector2(x,y);
	}
	
	public string getRootType()
	{
		return rootType;
	}
	
	public string getRootState()
	{
		return rootState; 
	}
	
	public void resetTimeSinceRootLifeStart()
	{ 
		timeSinceRootCreation = 0f;
	}
	
	public float getTimeSinceRootLifeStart()
	{ 
		return timeSinceRootCreation;
	}
//	
//	public void setRootType(string newType)
//	{
//		Texture spriteImage = getImageFromTypeState(newType, rootState);
//		
//		rootType = newType;
//		setSpriteImage(spriteImage);
//	}
//	
	public void setRootState(string newState)
	{
		Texture spriteImage = getImageFromTypeState(rootType, newState);
		
		rootState = newState;
		setSpriteImage(spriteImage);
	}
	
	public void setRootTypeAndState(string type, string state)
	{
		rootType = type;
		rootState = state;
		
		setImageFromTypeState(type,state);
		
		if(rootState == Constants.rootStateLocked)
		{
			sprite.registerInput = false;
		}
		
		else if(rootState == Constants.rootStateLive)
		{
			sprite.registerInput = false;
		}
		
		else //root state is dead
		{
			sprite.registerInput = true;
		}
	}	
	
	public void setImageFromTypeState(string type, string state)
	{
		Texture image = getImageFromTypeState(type,state);
		
		setSpriteImage(image);
	}
		
	private void setSpriteImage(Texture image)
	{
		if(image == null)
		{
			sprite.alpha = 0f;
		}
		else
		{
			sprite.image = image;
			sprite.alpha = 1f;
			
		}
	}
	
	public Texture getImageFromTypeState(string type, string state)
	{
		Texture image = null;
		if(state == Constants.rootStateLive)
		{
			if(type == Constants.rootTypeBase)
			{
				image = rootTextureLiveBase;
			}
			else if(type == Constants.rootTypeSection)
			{
				image = rootTextureLiveSection;
			}
			else if(type == Constants.rootTypeTip)
			{
				image = rootTextureLiveTip;
			}
		}
		
		else if(state == Constants.rootStateLocked)
		{
			if(type == Constants.rootTypeBase)
			{
				image = rootTextureLockedBase;
			}
			else if(type == Constants.rootTypeSection)
			{
				image = rootTextureLockedSection;
			}
			else if(type == Constants.rootTypeTip)
			{
				image = rootTextureLockedTip;
			}
		}
		else
		{
			image = null;
		}		
		
		return image;
	}		
}

