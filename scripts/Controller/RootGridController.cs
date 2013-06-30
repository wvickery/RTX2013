using UnityEngine;
using System.Collections;

public class RootGridController : MonoBehaviour
{
	public OTSprite RootObject;
	public GameObject TriadObject;
	
	
	private GameObject[][] rootGrid;
	
	// Use this for initialization
	void Start ()
	{		
		//loop through all triads
		initiateGrid();
		
		GameObject.Find("Triad0_7").GetComponent<TriadModel>().makeBaseTriad();
	}
	
	void initiateGrid()
	{
		rootGrid = new GameObject[Constants.rootGridRows][];
		for (int row=0; row < Constants.rootGridRows; row++)
		{
       		rootGrid[row] = new GameObject[Constants.rootGridCols];
       		for (int col=0; col<Constants.rootGridCols; col++)
			{
				Vector2 position = getTriadPosition(row,col);
				GameObject triad = createTriad(row, col, position);
         		rootGrid[row][col] = triad; 
       		}
    	}
	}
	
	GameObject createTriad(int row, int col, Vector2 position)
	{
		GameObject triad = (Instantiate(TriadObject.gameObject) as GameObject);	
		triad.name = "Triad"+row+"_"+col;
		triad.transform.position = position;		
		triad.GetComponent<TriadModel>().setIndex(row,col);
		return triad;
	}
	
	Vector2 getTriadPosition(int row, int col)
	{
		Vector2 position = new Vector2(Constants.triadBasePositionX + (row%2 * Constants.triadXDelta/2), Constants.triadBasePositionY );
		
		float offsetX = col * Constants.triadXDelta;
		float offsetY = row * Constants.triadYDelta;
		
		position.x += offsetX;
		position.y -= offsetY;
		
		return position;
	}
	
}

