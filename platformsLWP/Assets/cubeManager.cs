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
		pos3 = -0.7f;
	
	// game objects
	public GameObject myCube;
	
	//color vars
	float R1 = 0f, G1 = 0f, B1 = 0f, //black
		  R2 = 0f, G2 = 1f, B2 = 0.125f; // green
	int colorChance = 100; 
	
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
	
	/*
	//How fast the cube changes color 
	bool colorChange = true;
	int colorCt;
	int ranColorBrick;
	bool colorFirst;
	remove this if not needed*/
	
	// size of array for cubes
	static int size = 14*21;
	brick[] myBricks = new brick[size];
	
	
	//test Var
	int testCounter;
	Vector3 testVec;
	bool testing = false;
	
	// Use this for initialization
	void Start () {
		
		
		for(float z = 0; z < 14*sizeOfBrick; z+=sizeOfBrick)
		{
			for( float x = 0; x < 21*sizeOfBrick; x+=sizeOfBrick)
			{
				myBricks[index].cube = (GameObject)Instantiate (myCube, new Vector3 (x, 0f, z), transform.rotation);
				myBricks[index].cube.name = "Cube" + index.ToString();;
				
				index++;
			}
		}
		
		index = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
			if(testing)
			{
				if(testCounter >= size)
				{
					testCounter = 0;
					testing = false;
				}
				
				testVec = myBricks[testCounter].cube.transform.position + new Vector3( 0, 1, 0);		
				myBricks[testCounter].cube.transform.position = testVec;
			
				testCounter++;
			}
		
			
			
			pushPullBrick();
			
			// function that checks the settings in HomeSwitcher to see if anything needs be changed
			changeSettings();
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
	
	/// <summary>
	/// Changes the settings.
	/// </summary>/
	void changeSettings()
	{
					//changing the color of the tiles with settings from unity
			if( HomeSwitch.getColorChange())
			{
				R2 = HomeSwitch.getColor(0);
				G2 = HomeSwitch.getColor(1);
				B2 = HomeSwitch.getColor(2);
			
				R1 = HomeSwitch.getColor(3);
				G1 = HomeSwitch.getColor(4);
				B1 = HomeSwitch.getColor(5);
			
				HomeSwitch.setColorChange( false ); 
			}
		
			//this if statement checks to see if the colorChance has changed in the settings 
			// if it has then we change it 
			if(HomeSwitch.getColorChance() != colorChance)
			{
				colorChance = HomeSwitch.getColorChance();
				
				if( testing)
				{
					colorChance = 100;
				}
				
			}
	}
	/// <summary>
	/// Selects the brick move.
	/// </summary>
	void selectBrickMove()
		{
			// ranMove is randomly genorated from 0 to 100 and caught by 5 if statments
			// all ranging 10 values so each loation has a 10/100 changce of getting hit
			ranMove = Random.Range(0, 100);
		
			// ranBrick is randomly selecting 1 of the 100 bricks in the array 
			// it ranges from 0 to scale^2 which is the total number of brick genorated
			
			
			
			//myBricks[10].cube.transform.Translate(0f, speed, 0f); 
			
			if( ranMove >= 0 && ranMove <= 33)
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
			if( ranMove >= 34 && ranMove <= 66)
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
			if( ranMove >= 67 && ranMove <= 99)
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
			
		
			
		}
	/// <summary>
	/// Moves the bricks.
	/// </summary>
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
					
					}
				//end of if move = true
				}
		// end of for loop
		}
	}
	/// <summary>
	/// Selects the color.
	/// </summary>
	void selectColor()
		{
			// inishalizing color grid
		
			//this will slow down the color select
			int brickRan = Random.Range (0, size-1);
		
				if( myBricks[brickRan].colorState == 0 )
				{
					int colorRan = Random.Range(1, 100);
			
					if( colorRan <= colorChance) 
						myBricks[brickRan].colorState = 1;
					else
						myBricks[brickRan].colorState = 2;
				}
			
		}
	/// <summary>
	/// Changes the color.
	/// </summary>
	void changeColor()
	{
		 for( int i = 0; i < size; i++)
		{
			if(myBricks[i].colorState == 1)
				{
				
					 //myBricks[ranBrick].cube.renderer.material.color = new Color(0.5f,1f,1f);
					myBricks[i].cube.renderer.material.color = Color.Lerp(myBricks[i].cube.renderer.material.color,
																					new Color(R1,G1,B1),  smooth1 * Time.deltaTime);
					
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
																					new Color(R2, G2, B2),  smooth1 * Time.deltaTime);
					myBricks[i].colorSelCt++;
					if( myBricks[i].colorSelCt > 350)
					{
						myBricks[i].colorSelCt = 0;
						myBricks[i].colorState = 0;
					}
				}
		}
	}
	/// <summary>
	/// Pushs the pull brick.
	/// </summary>
	void pushPullBrick()
	{
		Debug.Log( "Message sent is :" + VectorsScr.getBoxName());
	}
	
	
}
