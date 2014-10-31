using UnityEngine;
using System.Collections;

public class VectorsScr : MonoBehaviour {
	public static string boxName;
	public GameObject bullets;
	float[] camera = new float[6];
	int counter = 0;
	bool testing = false, testingX = false, testingY = false;
	float testXPx, testYPx, testXU, testYU;

	// Use this for initialization
	void Start () {
		camera[0] = 27.9f; // x pos
		camera[1] = 10.5f; // y pos
		camera[2] = 1.95f; // z pos
		camera[3] = 51.06f; // x rot
		camera[4] = 334.6f; // y rot
		camera[5] = 0f;    // z rot
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(HomeSwitch.GetTouching() )
		{
			if( counter%5 == 0) // amount of bullets fired in a second 27/5 per sec
			{
				//create a bullet object at the the center 
				//GameObject newCube = (GameObject)Instantiate (bullets, new Vector3 (camera[0], camera[1], camera[2]), transform.rotation);
				GameObject newCube = (GameObject)Instantiate (bullets, new Vector3 (100f, 100f, 100f), transform.rotation);
				//This puts the cube under the camra
				 newCube.transform.parent = gameObject.transform;
				//Move newCube in to center of the camra 
			
				newCube.transform.position = new Vector3(camera[0], camera[1], camera[2]);
			
				
				newCube.transform.Rotate((float)HomeSwitch.getXY(1),(float)HomeSwitch.getXY(0),0);
				
				
				//force
				newCube.constantForce.relativeForce = new Vector3(0, 0, 1000);
				//rotate the object
				//newCube.transform.Rotate(10,0,0);
			}
		}
		//This will throdle the rate at which we do thing in update by being % 
		counter++;
	}
	
	
	public static void setBoxName( string other)
	{
		boxName = other;
	}
	
	public static string getBoxName()
	{
		return boxName;
	}
}
