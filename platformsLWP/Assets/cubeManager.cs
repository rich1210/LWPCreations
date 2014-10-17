/*
 * if move is getting stuck to true then this is why they stop moving
 * 
 * */

using UnityEngine;
using System.Collections;

public class cubeManager : MonoBehaviour {
	
	struct brick {
		
		//0 = 0 | 1 = .5 | 2 = 1 | 3 = -0.5 | 4 = -1
		public int pos;
		public GameObject cube;
		public string color;
		public bool move;	
		public bool colorSel;
		public int colorSelCt; 
		public int colorState; // 0 nothing 1 first color 2 second color
	};
			
	// y variables for vector 3
	float pos1 = 0f,
		pos2 = 0.7f,
		pos3 = 0.7f,
		pos4 = -0.7f,
		pos5 = -0.7f;
	
	// game objects
	public GameObject myCube;
	public GameObject myLight; 
	
	// materals of the cubes to change color
	public Material color1;
	public Material color2;
	
	// size of grid
	//static int scale = 16;
	private float sizeOfBrick = 2f;
	//location of cube in array of cubes
	private int index; 
	
	// random numbers to select a cube and its movement
	private int ranMove;
	private int ranBrick;
	private int ranColor;
	// how fast that cube will move up or down
	float speed1 = 0.0005f;
	float speedS = 0.0055f;
	float smooth1 = 4.5f;
	
	//How fast the cube changes color 
	bool colorChange = true;
	int colorCt;
	int ranColorBrick;
	bool colorFirst;
	
	// size of array for cubes
	static int size = 14*21;
	brick[] myBricks = new brick[size];
	
	//test Var
	int testCounter;

	// Use this for initialization
	void Start () {
		
		
		for(float z = 0; z < 14*sizeOfBrick; z+=sizeOfBrick)
		{
			for( float x = 0; x < 21*sizeOfBrick; x+=sizeOfBrick)
			{
				myBricks[index].cube = (GameObject)Instantiate (myCube, new Vector3 (x, 0f, z), transform.rotation);
				
				index++;
			}
		}
		
		Debug.Log(" this man bricks " + size + " This many its trying to use " + index);
		index = 0;
	}
	
	// Update is called once per frame
	void Update () {
					
			//check to see where each each brick is at that should be moving
			moveBricks ();
			changeColor();		
		}
	
		void FixedUpdate() 
		{
		
			// randomly select which brick to move and to what location
			selectBrickMove();
			selectColor();
		}
	
	
		void selectBrickMove()
		{
			// ranMove is randomly genorated from 0 to 100 and caught by 5 if statments
			// all ranging 10 values so each loation has a 10/100 changce of getting hit
			ranMove = Random.Range(0, 100);
		
			// ranBrick is randomly selecting 1 of the 100 bricks in the array 
			// it ranges from 0 to scale^2 which is the total number of brick genorated
			
			
			
			//myBricks[10].cube.transform.Translate(0f, speed, 0f); 
			
			if( ranMove >= 0 && ranMove <= 20)
			{
				while( myBricks[ranBrick].move == true )
				{
					ranBrick = Random.Range(0, size);
				}
			
				if( myBricks[ranBrick].move != true)
				{
					myBricks[ranBrick].move = true;
					myBricks[ranBrick].pos = 0;
				}
			}
		
			//pos1
			if( ranMove >= 21 && ranMove <= 40)
			{
				while( myBricks[ranBrick].move == true )
				{
					ranBrick = Random.Range(0, size);
				}
			
				if( myBricks[ranBrick].move != true)
				{
					//Debug.Log("pos2 with :" + ranBrick);
					myBricks[ranBrick].move = true;
					myBricks[ranBrick].pos = 1;
				}
			}
			
			//pos2
			if( ranMove >= 41 && ranMove <= 60)
			{
			
				while( myBricks[ranBrick].move == true )
				{
					ranBrick = Random.Range(0, size);
				}
			
				if( myBricks[ranBrick].move != true)
				{
					//Debug.Log("pos3 with :" + ranBrick);
					myBricks[ranBrick].move = true;
					myBricks[ranBrick].pos = 2;
				}
			}
			
			if( ranMove >= 61 && ranMove <= 80)
			{
			
				while( myBricks[ranBrick].move == true )
				{
					ranBrick = Random.Range(0, size);
				}
			
				if( myBricks[ranBrick].move != true)
				{
				//Debug.Log("pos4 with :" + ranBrick);
				myBricks[ranBrick].move = true;
				myBricks[ranBrick].pos = 3;
				}
			}
			
			//Pos3
			if( ranMove >= 81 && ranMove <= 100)
			{
				while( myBricks[ranBrick].move == true )
				{
					ranBrick = Random.Range(0, size);
				}
			
				if( myBricks[ranBrick].move != true)
				{
				//Debug.Log("pos5 with :" + ranBrick);
				myBricks[ranBrick].move = true;
				myBricks[ranBrick].pos = 4;
				}
			}
			
		}
		void moveBricks()
		{
		
			for( index = 0; index < size; index++ )
			{
		
				if( myBricks[index].move == true)
				{
					switch(myBricks[index].pos)
					{
					case 0:
					
						
		
						// if it is less then then we move up 
						if( myBricks[index].cube.transform.position.y <= pos1-0.05f) 
						{ 
							if( myBricks[index].cube.transform.position.y <= pos1-0.3f)
							{
								myBricks[index].cube.transform.Translate(0f, speed1, 0f);
							}
							else
							{
								myBricks[index].cube.transform.Translate(0f, speedS, 0f);
							}

							
						}
						// if it is not = to or < then we know it is > then so we move down
						else if( myBricks[index].cube.transform.position.y >= pos1+0.05f)
						{ 
							if( myBricks[index].cube.transform.position.y >= pos1+0.3f)
							{
								myBricks[index].cube.transform.Translate(0f, -speed1, 0f);
							}
							else
							{
								myBricks[index].cube.transform.Translate(0f, -speedS, 0f);
							}

							
						}
						else
						{
							myBricks[index].move = false;
							speed1 = 0.05f;
						}
						
					break;
	
					case 1:
						
						// if it is less then then we move up 
						if( myBricks[index].cube.transform.position.y <= pos2-0.05f) 
						{ 
							
							if( myBricks[index].cube.transform.position.y <= pos2-0.3f)
							{
								myBricks[index].cube.transform.Translate(0f, speed1, 0f);
							}
							else
							{
								myBricks[index].cube.transform.Translate(0f, speedS, 0f);
							}
						}
						// if it is not = to or < then we know it is > then so we move down
						else if( myBricks[index].cube.transform.position.y >= pos2+0.05f)
						{  
							if( myBricks[index].cube.transform.position.y >= pos2+0.3f)
							{
								myBricks[index].cube.transform.Translate(0f, -speed1, 0f);
							}
							else
							{
								myBricks[index].cube.transform.Translate(0f, -speedS, 0f);
							}
						}
						else
						{
							myBricks[index].move = false;
						}
						
					break;
					case 2:
						
						// if it is less then then we move up 
						if( myBricks[index].cube.transform.position.y <= pos3-0.05f) 
						{ 
							if( myBricks[index].cube.transform.position.y <= pos3-0.3f)
							{
								myBricks[index].cube.transform.Translate(0f, speed1, 0f);
							}
							else
							{
								myBricks[index].cube.transform.Translate(0f, speedS, 0f);
							}
						}
						// if it is not = to or < then we know it is > then so we move down
						else if( myBricks[index].cube.transform.position.y >= pos3+0.05f)
						{ 
							if( myBricks[index].cube.transform.position.y >= pos3+0.3f)
							{
								myBricks[index].cube.transform.Translate(0f, -speed1, 0f);
							}
							else
							{
								myBricks[index].cube.transform.Translate(0f, -speedS, 0f);
							}
						}
						else
						{
							myBricks[index].move = false;
						}
					break;
					case 3:
						
						// if it is less then then we move up 
						if( myBricks[index].cube.transform.position.y <= pos4-0.05f) 
						{ 
							if( myBricks[index].cube.transform.position.y <= pos4-0.3f)
							{
								myBricks[index].cube.transform.Translate(0f, speed1, 0f);
							}
							else
							{
								myBricks[index].cube.transform.Translate(0f, speedS, 0f);
							}
						}
						// if it is not = to or < then we know it is > then so we move down
						else if( myBricks[index].cube.transform.position.y >= pos4+0.05f)
						{ 
							if( myBricks[index].cube.transform.position.y >= pos4+0.3f)
							{
								myBricks[index].cube.transform.Translate(0f, -speed1, 0f);
							}
							else
							{
								myBricks[index].cube.transform.Translate(0f, -speedS, 0f);
							}
						}
						else
						{
							myBricks[index].move = false;
						}
					break;
					case 4:
						
						// if it is less then then we move up 
						if( myBricks[index].cube.transform.position.y <= pos5-0.05f) 
						{ 
							if( myBricks[index].cube.transform.position.y <= pos5-0.3f)
							{
								myBricks[index].cube.transform.Translate(0f, speed1, 0f);
							}
							else
							{
								myBricks[index].cube.transform.Translate(0f, speedS, 0f);
							}
						}
						// if it is not = to or < then we know it is > then so we move down
						else if( myBricks[index].cube.transform.position.y >= pos5+0.05f)
						{ 
							if( myBricks[index].cube.transform.position.y >= pos5+0.3f)
							{
								myBricks[index].cube.transform.Translate(0f, -speed1, 0f);
							}
							else
							{
								myBricks[index].cube.transform.Translate(0f, -speedS, 0f);
							}
						}
						else
						{
							myBricks[index].move = false;
						}
					break;
					
					}
				//end of if move = true
				}
		// end of for loop
		}
	}
		void selectColor()
		{
			// inishalizing color grid
		
			//this will slow down the color select
			int brickRan = Random.Range (0, size);
		
				if( myBricks[brickRan].colorState == 0 )
				{
					int colorRan = Random.Range(0, 100);
			
					if( colorRan > 50)
						myBricks[brickRan].colorState = 1;
					else
						myBricks[brickRan].colorState = 2;
				}
			
		}
	
	void changeColor()
	{
		 for( int i = 0; i < size; i++)
		{
			if(myBricks[i].colorState == 1)
				{
				
					 //myBricks[ranBrick].cube.renderer.material.color = new Color(0.5f,1f,1f);
					myBricks[i].cube.renderer.material.color = Color.Lerp(myBricks[i].cube.renderer.material.color,
																					new Color(0f,0f,0f),  smooth1 * Time.deltaTime);
					
					myBricks[i].colorSelCt++;
					if( myBricks[i].colorSelCt > 350)
					{
						myBricks[i].colorSelCt = 0;
						myBricks[i].colorState = 0;
					}
						
				}
			else if(myBricks[i].colorState == 2)
				{
				
					//myBricks[ranBrick].cube.renderer.material.color = new Color(1f,0.5f,1f);
					myBricks[i].cube.renderer.material.color = Color.Lerp(myBricks[i].cube.renderer.material.color,
																					new Color(0f, 1f, 0.5f),  smooth1 * Time.deltaTime);
					myBricks[i].colorSelCt++;
					if( myBricks[i].colorSelCt > 350)
					{
						myBricks[i].colorSelCt = 0;
						myBricks[i].colorState = 0;
					}
				}
		}
	}
}
