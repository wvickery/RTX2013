using UnityEngine;
using System.Collections;

public class TriadModel : MonoBehaviour {

	private GameObject rootLeft;
	private GameObject rootTop;
	private GameObject rootRight;
	
	private int rowIndex;
	private int colIndex;
	
	public OTSprite RootObject;
	
	private string[]  rootNames = new string[3] {Constants.rootLeft, Constants.rootTop, Constants.rootRight};
	private Vector2[] rootPositions = new Vector2[3] {new Vector2(3.4f, 1.8f), new Vector2(-4.2f,4.3f), new Vector2(22.1f,5.5f)};
	private Vector2[] rootSizes = new Vector2[3] {new Vector2(27f, 6.75f), new Vector2(28f, 6.75f), new Vector2(28f, 6.75f)};
	private	float[]   rootRotations = new float[3] {240f, 0f, 300f};
	
	public void setSingleRoot(int index, GameObject root)
	{
		switch(index)
		{
		case 0:
			rootLeft = root;
			break;
		case 1:
			rootTop = root;
			break;
		case 2:
			rootRight = root;
			break;
		}
	}
	
	public void setRoots(GameObject left, GameObject top, GameObject right)
	{
		rootLeft = left;
		rootTop = top;
		rootRight = right;
	}
	
	public void setIndex(int row, int col)
	{
		rowIndex = row;
		colIndex = col;
	}
	
	public void makeBaseTriad()
	{
		GameObject triad = getOtherTriad(rowIndex, colIndex);
		addSingleRoot(1,triad.transform,triad.name,triad.GetComponent<TriadModel>());
		onTopRootStarted();
		RootModel topRootModel = rootTop.GetComponent<RootModel>();
		topRootModel.setRootTypeAndState(Constants.rootTypeSection,Constants.rootStateLocked);
	}
	
	public void onLeftRootStarted()
	{
		int newTriadRow, newTriadCol;
		newTriadRow = rowIndex + 1;
		
	
		if(rowIndex%2 == 1)
		{	//odd row
			newTriadCol = colIndex;
		}
		else
		{   //even row
			newTriadCol = colIndex - 1;
		}
				
		GameObject newTriad = getOtherTriad(newTriadRow, newTriadCol);
		//top root
		addSingleRoot(1,newTriad.transform,newTriad.name,newTriad.GetComponent<TriadModel>());
		//right root
		addSingleRoot(2,newTriad.transform,newTriad.name,newTriad.GetComponent<TriadModel>());
	}
	
	public void onRightRootStarted()
	{
		int newTriadRow, newTriadCol;
		newTriadRow = rowIndex + 1;
		
		
		if(rowIndex%2 == 1)
		{	//odd row
			newTriadCol = colIndex + 1;
		}
		else
		{   //even row
			newTriadCol = colIndex;
		}
				
		GameObject newTriad = getOtherTriad(newTriadRow, newTriadCol);
		//top root
		addSingleRoot(1,newTriad.transform,newTriad.name,newTriad.GetComponent<TriadModel>());
		//left root
		addSingleRoot(0,newTriad.transform,newTriad.name,newTriad.GetComponent<TriadModel>());
	}
	
	public void onTopRootStarted()
	{
		//same triad
		GameObject triad = getOtherTriad(rowIndex, colIndex);
		//left root
		addSingleRoot(0,triad.transform,triad.name,triad.GetComponent<TriadModel>());
		//right root
		addSingleRoot(2,triad.transform,triad.name,triad.GetComponent<TriadModel>());
	}
	
	GameObject getOtherTriad(int row, int col)
	{
		return GameObject.Find("Triad"+row+"_"+col);
	}
	
	void addSingleRoot(int rootIndex, Transform parentTransform, string parentName, TriadModel triadModel)
	{
		if(GameObject.Find(parentName + rootNames[rootIndex]) == null )
		{
			GameObject rObject =(Instantiate(RootObject.gameObject) as GameObject);
			OTSprite rSprite = rObject.GetComponent<OTSprite>();
				
			rSprite.transform.parent = parentTransform;
	
			rSprite.name = parentName + rootNames[rootIndex];
			rSprite.position = rootPositions[rootIndex];
			rSprite.size = rootSizes[rootIndex];
			rSprite.rotation = rootRotations[rootIndex];
					
			rObject.GetComponent<RootModel>().initialize(Constants.rootTypeSection, Constants.rootStateDead);
					
			triadModel.setSingleRoot(rootIndex, rObject);
		}
	}
	
	
}
