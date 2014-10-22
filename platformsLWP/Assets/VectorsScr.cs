using UnityEngine;
using System.Collections;

public class VectorsScr : MonoBehaviour {
	public static string boxName;
	public GameObject bullets;
	float[] camera = new float[6];
	int counter = 0;
	

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
		
		if(HomeSwitch.GetTouching())
		{
			if( counter%5 == 0)
			{
				//create a bullet object at the the center 
				GameObject newCube = (GameObject)Instantiate (bullets, new Vector3 (camera[0], camera[1], camera[2]), transform.rotation);
				//force
				newCube.constantForce.relativeForce = new Vector3(0, 0, 1000);
				//inizalize rotation
				newCube.transform.Rotate(camera[3]-45,camera[4]+20,camera[5]);
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
