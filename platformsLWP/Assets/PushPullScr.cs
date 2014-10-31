using UnityEngine;
using System.Collections;
using System;
using System.Globalization;

public class PushPullScr : MonoBehaviour {
	
	private Grid grid;
	int index;
	float pos1 = 0f, pos2 = 3f;
	float speed1 = 0.0005f, speed2 = .25f;
	float speedS = 0.0055f;
	bool level = true;
	int storeVal;
	
	string boxName;
	
	
	void Awake ()
    {
        grid = GetComponent<Grid>();
		//grid.myField.fieldArray[?].move // ect...
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if( HomeSwitch.GetTouching() )
		{
			
			//get the name of the brick 
			boxName = VectorsScr.getBoxName();      // get the name from VectorsScr
			string[] digit = boxName.Split (',');   // split the name of the box by the ,  
			int boxIndex;                          
			Int32.TryParse(digit[1], out boxIndex); // change the sting to an int
			
			//move that brick up to 1.5
			if( boxIndex >= 0 && boxIndex <= grid.myField.fieldSize)
			touchBrick( boxIndex);
			
			//then move the rest of the bricks around it up to 1
			
			// then move the bricks around the rest of the brick up to .5
			
			
		}
		//once were no longer touching the screen cubeMan will take over again with normal movments
	
	}
	
	
	/*this function is kinda grity, it just over powers the levelField function
	 * With this function i need a boolean that will tell the translate fucntion 
	 * to keep working unless we get to pos2.  Once we get there we want to wait for 
	 * the cube to hit another cube, then once that happens we need to just change
	 * the boolean and allow the prevus cube to drop down.  
	 * 
	 * In order to get the levels around the highest cube I think I create 2 more 
	 * booleans to tell the bricks what level they should be at if the tallest one is 
	 * close to them
	 */
	void touchBrick( int index)
	{
		//this will check to see 
		 if( storeVal != index)
		{
			grid.myField.fieldArray[storeVal].move = true;
		}
		
		// if cube is hit then set it to true and set all others to false 
		if( grid.myField.fieldArray[index].cube.transform.position.y <= pos2-0.05f) 
		{ 
			grid.myField.fieldArray[index].cube.transform.Translate(0f, speed2, 0f);
			grid.myField.fieldArray[index].move = true;
			
		}
		// if it is not = to or < then we know it is > then so we move down
		else if( grid.myField.fieldArray[index].cube.transform.position.y >= pos2+0.05f)
		{ 
			grid.myField.fieldArray[index].cube.transform.Translate(0f, -speed2, 0f);
			grid.myField.fieldArray[index].move = true;
		}
		else
		{
			/*this stops the cubeMan from pulling the brick down once its as high as we want it to go 
			* it stores the last birck used and checks it with the current birck if those two bricks are 
			* the same then that birck has been at the top and is still selected, It will then set the brick 
			* to move to false.
			* 
			* IF the two bricks are no longer the same then the user has moved on to a different brick and 
			* and the last brick need to move back down.  
			*/
			
			storeVal = index;//once at the top we test 
			
			grid.myField.fieldArray[index].move = false;
			
		}
	}
}
