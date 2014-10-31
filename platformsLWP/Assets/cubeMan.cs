using UnityEngine;
using System.Collections;

public class cubeMan : MonoBehaviour {
	
	//public grid grid;
	private Grid grid;
	int index;
	float pos1 = 0f,
		pos2 = 0.7f,
		pos3 = -0.7f;
	float speed1 = 0.0005f;
	float speedS = 0.0055f;
	
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
		//pause this if there is a touch enabled 
		//if( HomeSwitch.GetTouching() == false )
		moveBricks ();
	}
	
	void FixedUpdate() 
	{
		// randomly select which brick to move and to what location
		//pause this if there is a touch enabled
		
		selectBrickMove();
	}
	
	void selectBrickMove()
	{
		int ranMove;
		
		// ranMove is randomly genorated from 0 to 100
		if( HomeSwitch.GetTouching() == false)
		{
			 ranMove = Random.Range(0, 100);
		}
		else
		{
			 ranMove = Random.Range(0, 20);
		}
	
		// ranBrick is a random number to select one of the bricks
		int ranBrick = Random.Range (0, grid.myField.fieldSize);
		
		if( ranMove >= 0 && ranMove <= 33)
		{
			while( grid.myField.fieldArray[ranBrick].move == true )
			{
				ranBrick = Random.Range(0, grid.myField.fieldSize);
			}
		
			if( grid.myField.fieldArray[ranBrick].move != true)
			{
				grid.myField.fieldArray[ranBrick].move = true;
				grid.myField.fieldArray[ranBrick].pos = 0;
			}
		}
	
		//pos1
		if( ranMove >= 34 && ranMove <= 66)
		{
			while(grid.myField.fieldArray[ranBrick].move == true )
			{
				ranBrick = Random.Range(0, grid.myField.fieldSize);
			}
		
			if( grid.myField.fieldArray[ranBrick].move != true)
			{
				//Debug.Log("pos2 with :" + ranBrick);
				grid.myField.fieldArray[ranBrick].move = true;
				grid.myField.fieldArray[ranBrick].pos = 1;
			}
		}
		
		//pos2
		if( ranMove >= 67 && ranMove <= 99)
		{
		
			while(grid.myField.fieldArray[ranBrick].move == true )
			{
				ranBrick = Random.Range(0, grid.myField.fieldSize);
			}
		
			if( grid.myField.fieldArray[ranBrick].move != true)
			{
				//Debug.Log("pos3 with :" + ranBrick);
				grid.myField.fieldArray[ranBrick].move = true;
				grid.myField.fieldArray[ranBrick].pos = 2;
			}
		}
		
	
		
	}
	
	void moveBricks()
		{
		
			for( index = 0; index < grid.myField.fieldSize; index++ )
			{
		
				if( grid.myField.fieldArray[index].move == true)
				{
					switch(grid.myField.fieldArray[index].pos)
					{
					case 0:
						// if it is less then then we move up 
						if( grid.myField.fieldArray[index].cube.transform.position.y <= pos1-0.05f) 
						{ 
							if( grid.myField.fieldArray[index].cube.transform.position.y <= pos1-0.3f)
							{
								grid.myField.fieldArray[index].cube.transform.Translate(0f, speed1, 0f);
							}
							else
							{
								grid.myField.fieldArray[index].cube.transform.Translate(0f, speedS, 0f);
							}

							
						}
						// if it is not = to or < then we know it is > then so we move down
						else if( grid.myField.fieldArray[index].cube.transform.position.y >= pos1+0.05f)
						{ 
							if( grid.myField.fieldArray[index].cube.transform.position.y >= pos1+0.3f)
							{
								grid.myField.fieldArray[index].cube.transform.Translate(0f, -speed1, 0f);
							}
							else
							{
								grid.myField.fieldArray[index].cube.transform.Translate(0f, -speedS, 0f);
							}

							
						}
						else
						{
							grid.myField.fieldArray[index].move = false;
							speed1 = 0.05f;
						}
						
					break;
	
					case 1:
						
						// if it is less then then we move up 
						if( grid.myField.fieldArray[index].cube.transform.position.y <= pos2-0.05f) 
						{ 
							
							if( grid.myField.fieldArray[index].cube.transform.position.y <= pos2-0.3f)
							{
								grid.myField.fieldArray[index].cube.transform.Translate(0f, speed1, 0f);
							}
							else
							{
								grid.myField.fieldArray[index].cube.transform.Translate(0f, speedS, 0f);
							}
						}
						// if it is not = to or < then we know it is > then so we move down
						else if( grid.myField.fieldArray[index].cube.transform.position.y >= pos2+0.05f)
						{  
							if( grid.myField.fieldArray[index].cube.transform.position.y >= pos2+0.3f)
							{
								grid.myField.fieldArray[index].cube.transform.Translate(0f, -speed1, 0f);
							}
							else
							{
								grid.myField.fieldArray[index].cube.transform.Translate(0f, -speedS, 0f);
							}
						}
						else
						{
							grid.myField.fieldArray[index].move = false;
						}
						
					break;
					case 2:
						
						// if it is less then then we move up 
						if( grid.myField.fieldArray[index].cube.transform.position.y <= pos3-0.05f) 
						{ 
							if( grid.myField.fieldArray[index].cube.transform.position.y <= pos3-0.3f)
							{
								grid.myField.fieldArray[index].cube.transform.Translate(0f, speed1, 0f);
							}
							else
							{
								grid.myField.fieldArray[index].cube.transform.Translate(0f, speedS, 0f);
							}
						}
						// if it is not = to or < then we know it is > then so we move down
						else if( grid.myField.fieldArray[index].cube.transform.position.y >= pos3+0.05f)
						{ 
							if( grid.myField.fieldArray[index].cube.transform.position.y >= pos3+0.3f)
							{
								grid.myField.fieldArray[index].cube.transform.Translate(0f, -speed1, 0f);
							}
							else
							{
								grid.myField.fieldArray[index].cube.transform.Translate(0f, -speedS, 0f);
							}
						}
						else
						{
							grid.myField.fieldArray[index].move = false;
						}
					break;
					
					}
				//end of if move = true
				}
		// end of for loop
		}
	}

	

}
