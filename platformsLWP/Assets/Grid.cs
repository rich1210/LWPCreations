using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
	
	

	
	public class Field
	{
		public struct FieldObjects
		{
				//0 = 0 | 1 = .7 | 2 = -.7 
				public int pos;
				public GameObject cube; // a cube used on the stage 
				public string name;     // the name of the cube
				public string color;    // the color of the cube
				public bool move;	    // if the cube is ready to move move is true 
				public bool flat;		// if touch is false then cube should be at 0
										// if touch is true then cube should be moving to 1
				public bool colorSel;   // the color the cube will soon be
				public int colorSelCt;  // the counter that keeps track of where the color is when its lerping
				public int colorState; // 0 nothing 1 first color 2 second color, and if there is 3rd then 3 third color 	
		}
		
		public FieldObjects[] fieldArray;		   // the array of cubes that will be layed out 
		public int xSize, zSize;       // this is the width and langth of the gird and it can be changed in settings
		public int fieldSize;          // this is the total size of the all the bricks on the field
		public float sizeOfBrick; 	   // the wideth and hight of the the cube 
		
		public Field()
		{
			// setting the array of bricks
			fieldArray = new FieldObjects[21*14];
			xSize = 21;
			zSize = 14;
			fieldSize = 21*14;
			sizeOfBrick = 2f;
		}
	}
	
	public GameObject myCube;       // the cube that will be copyed 
	public GameObject myHex;
	private int index;              // the index will number the cubes in there names
	public Field myField = new Field();
	
	bool cube = true;
	
	// Use this for initialization
	void Start () {
		if( cube )
		{
			// laying out the field of bricks 
			for(float z = 0; z < (myField.zSize)*(myField.sizeOfBrick); z+=(myField.sizeOfBrick))
			{
				for( float x = 0; x < (myField.xSize)*(myField.sizeOfBrick); x+=(myField.sizeOfBrick))
				{
					// printing the cubes on the field
					myField.fieldArray[index].cube = (GameObject)Instantiate (myCube, new Vector3 (x, 0f, z), transform.rotation);
					// nameing the cubes
					myField.fieldArray[index].cube.name = "Cube," + index.ToString();;
					
					index++;
				}
			}
		}
		else
		{
			myField.sizeOfBrick = 4f;
			// laying out the field of bricks 
			for(float z = 0; z < (myField.zSize)*(myField.sizeOfBrick); z+=(myField.sizeOfBrick))
			{
				for( float x = 0; x < (myField.xSize)*(myField.sizeOfBrick); x+=(myField.sizeOfBrick))
				{
					if( z % 2 == 0)
					{
						x+=myField.sizeOfBrick; // off set
					}
					// printing the cubes on the field											//skip 		// half 
					myField.fieldArray[index].cube = (GameObject)Instantiate (myHex, new Vector3 ((x/2), 0f, (z+z)), transform.rotation);
					// nameing the cubes
					myField.fieldArray[index].cube.name = "Cube," + index.ToString();;
					
					index++;
				}
			}
		}
		index = 0;
	
	}
	
	// Update is called once per frame
	void Update () {

			myField.fieldArray[50].cube.transform.Rotate(.01f,0,0);
		
		//if settings 
		
		// if settings are changed 
		//print small medium and large grids 
			// squares
			// hexigons
	
	}
	
	

}
