using UnityEngine;
using System.Collections;

public class cubeManager : MonoBehaviour {
	
	struct brick {
		
		//0 = 0 | 1 = .5 | 2 = 1 | 3 = -0.5 | 4 = -1
		public int pos;
		public GameObject cube;
		public string color;
		public bool move;	
	};
			
	// y variables for vector 3
	float pos1 = 0f,
		pos2 = 0.5f,
		pos3 = 1f,
		pos4 = -0.5f,
		pos5 = -1f;
	
	
	public GameObject myCube;
	public GameObject myLight; 
	private int scale = 14;
	private int index; 
	
	private int ranMove;
	private int ranBrick;
	
	float speed = 0.01f;
	static int size = 200;
	brick[] myBricks = new brick[size];

	// Use this for initialization
	void Start () {
		
		for(float z = 0; z < scale; z+=2)
		{
			for( float x = 0; x < scale; x+=2)
			{
				myBricks[index].cube = (GameObject)Instantiate (myCube, new Vector3 (x, 0f, z), transform.rotation);
				
				index++;
			}
		}
		
		index = 0;
	}
	
	// Update is called once per frame
	void Update () {
		ranMove = Random.Range(0, 100);
		ranBrick = Random.Range(0, 100);
		
		//myBricks[10].cube.transform.Translate(0f, speed, 0f); 
		
		if( ranMove >= 0 && ranMove <= 10)
		{
			Debug.Log("pos1 with :" + ranBrick);
			myBricks[ranBrick].move = true;
			myBricks[ranBrick].pos = 0;
		}
		//pos1
		if( ranMove >= 11 && ranMove <= 20)
		{
			Debug.Log("pos2 with :" + ranBrick);
			
			myBricks[ranBrick].move = true;
			myBricks[ranBrick].pos = 1;
		}
		
		//pos2
		if( ranMove >= 21 && ranMove <= 30)
		{
			Debug.Log("pos3 with :" + ranBrick);
			
			myBricks[ranBrick].move = true;
			myBricks[ranBrick].pos = 2;
		}
		
		if( ranMove >= 31 && ranMove <= 40)
		{
			Debug.Log("pos4 with :" + ranBrick);
			
			myBricks[ranBrick].move = true;
			myBricks[ranBrick].pos = 3;
		}
		
		//Pos3
		if( ranMove >= 50 && ranMove <= 60)
		{
			Debug.Log("pos5 with :" + ranBrick);
			
			myBricks[ranBrick].move = true;
			myBricks[ranBrick].pos = 4;
		}
		
		//check to see where each each brick is at that should be moving
		moveBricks ();
				
		}

		void moveBricks()
		{
			for( index = 0; index < size; index++ )
			{
				if( myBricks[index].move == true)
				{
					switch(myBricks[index].pos)
					{
					case 1:
						// if it is equal then we stop moving
						if(myBricks[index].cube.transform.position.y == pos1){
							myBricks[index].move = false;
						}
						// if it is less then then we move up 
						else if( myBricks[index].cube.transform.position.y <= pos1) 
						{ 
							myBricks[index].cube.transform.Translate(0f, speed, 0f); 
						}
						// if it is not = to or < then we know it is > then so we move down
						else
						{ 
							myBricks[index].cube.transform.Translate(0f, -speed, 0f); 
						}
					break;
					case 2:
						if(myBricks[index].cube.transform.position.y == pos2){
						myBricks[index].move = false;
						}
						else if( myBricks[index].cube.transform.position.y <= pos2) 
						{ 
							myBricks[index].cube.transform.Translate(0f, speed, 0f); 
						}
						// if it is not = to or < then we know it is > then so we move down
						else
						{ 
							myBricks[index].cube.transform.Translate(0f, -speed, 0f); 
						}
						
					break;
					case 3:
						if(myBricks[index].cube.transform.position.y == pos3){
						myBricks[index].move = false;
						}
						else if( myBricks[index].cube.transform.position.y <= pos3) 
						{ 
							myBricks[index].cube.transform.Translate(0f, speed, 0f); 
						}
						// if it is not = to or < then we know it is > then so we move down
						else
						{ 
							myBricks[index].cube.transform.Translate(0f, -speed, 0f); 
						}
					break;
					case 4:
						if(myBricks[index].cube.transform.position.y == pos4){
						myBricks[index].move = false;
						}
						else if( myBricks[index].cube.transform.position.y <= pos4) 
						{ 
							myBricks[index].cube.transform.Translate(0f, speed, 0f); 
						}
						// if it is not = to or < then we know it is > then so we move down
						else
						{ 
							myBricks[index].cube.transform.Translate(0f, -speed, 0f); 
						}
					break;
					case 5:
						if(myBricks[index].cube.transform.position.y == pos5){
						myBricks[index].move = false;
						}
						else if( myBricks[index].cube.transform.position.y <= pos5) 
						{ 
							myBricks[index].cube.transform.Translate(0f, speed, 0f); 
						}
						// if it is not = to or < then we know it is > then so we move down
						else
						{ 
							myBricks[index].cube.transform.Translate(0f, -speed, 0f); 
						}
					break;
					}
				//end of if move = true
				}
		// end of for loop
		}
	}
}
