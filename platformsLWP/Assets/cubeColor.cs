using UnityEngine;
using System.Collections;

public class cubeColor : MonoBehaviour {
	
	private Grid grid;
	public Material color;
	
	float R1 = 0f, G1 = 0f, B1 = 0f, //black
		  R2 = 0f, G2 = 1f, B2 = 0.125f; // green
	int colorChance = 50; 
	
	float smooth1 = 4.5f;
	
	bool testing = false;
	
	void Awake ()
    {
        grid = GetComponent<Grid>();
		//grid.myField.fieldArray[?].move // ect...
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		changeColor();
		changeSettings();
	}
	
	void FixedUpdate() 
	{
		selectColor();
	}
	
	void selectColor()
	{
		// inishalizing color grid
	
		//this will slow down the color select
		int brickRan = Random.Range (0, grid.myField.fieldSize);
	
			if( grid.myField.fieldArray[brickRan].colorState == 0 )
			{
				int colorRan = Random.Range(1, 100);
		
				if( colorRan <= colorChance) 
					grid.myField.fieldArray[brickRan].colorState = 1;
				else
					grid.myField.fieldArray[brickRan].colorState = 2;
			}
		
	}
	
	void changeColor()
	{
		 for( int i = 0; i < grid.myField.fieldSize; i++)
		{
			if(grid.myField.fieldArray[i].colorState == 1)
				{
				
					 //myBricks[ranBrick].cube.renderer.material.color = new Color(0.5f,1f,1f);
					grid.myField.fieldArray[i].cube.renderer.material.color = Color.Lerp(grid.myField.fieldArray[i].cube.renderer.material.color,
																					new Color(R1,G1,B1),  smooth1 * Time.deltaTime);
					
					grid.myField.fieldArray[i].colorSelCt++;
					if( grid.myField.fieldArray[i].colorSelCt > 350)
					{
						grid.myField.fieldArray[i].colorSelCt = 0;
						grid.myField.fieldArray[i].colorState = 0;
					}
						
				}
			else if(grid.myField.fieldArray[i].colorState == 2)
				{
				
					//myBricks[ranBrick].cube.renderer.material.color = new Color(1f,0.5f,1f);
					grid.myField.fieldArray[i].cube.renderer.material.color = Color.Lerp(grid.myField.fieldArray[i].cube.renderer.material.color,
																					new Color(R2, G2, B2),  smooth1 * Time.deltaTime);
					grid.myField.fieldArray[i].colorSelCt++;
					if( grid.myField.fieldArray[i].colorSelCt > 350)
					{
						grid.myField.fieldArray[i].colorSelCt = 0;
						grid.myField.fieldArray[i].colorState = 0;
					}
				}
		}
	}
		
		
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
}
		
	

