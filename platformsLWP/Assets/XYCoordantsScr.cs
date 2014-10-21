using UnityEngine;
using System.Collections;

public class XYCoordantsScr : MonoBehaviour {
	
	public static float[ , ] touchCoord = new float[294 , 4];

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public static void setTouchCoord( float xVal, float yVal, float xCube, float yCube, int row, int col)
	{
		if( xVal != -1 && col == 0)
		{
			touchCoord[ row, col ] = xVal;
		}
		else if( yVal != -1 && col == 1)
		{
			touchCoord[ row, col ] = yVal;
		}
		else if( yVal != -1 && col == 2)
		{
			touchCoord[ row, col ] = xCube;
		}
		else
		{
			touchCoord[ row, col ] = yCube;
		}
	}
}
