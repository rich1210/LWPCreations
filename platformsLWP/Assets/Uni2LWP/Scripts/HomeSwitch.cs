using UnityEngine;
using System.Collections;
using System;
using System.Globalization;


public class HomeSwitch : MonoBehaviour
{
	public float scaleFactor = 4f;
	private float camOffsetFactor = 0.5f;
	public float camSpeed = 0.10f;
	private Vector3 newPosition;
	public TextMesh touchCoord;
	

	void LateUpdate ()
	{
		//newPosition = new Vector3 ((camOffsetFactor - 0.5f) * scaleFactor, transform.position.y, transform.position.z);
		//transform.position = Vector3.Lerp (transform.position, newPosition, camSpeed);
	}


	public void SetCamOffset (string offset)
	{
		//float.TryParse (offset, out camOffsetFactor);
	}

	/// <summary>
	/// Emulates Swipe (Left/Right)
	/// </summary>
	/// <param name="swipe">
	/// A <see cref="System.String"/>
	/// </param>
	public void SetSimulateCamOffset (string swipe)
	{
		
		if (swipe == "RIGHT") {
			
			if (camOffsetFactor > 0.49f && camOffsetFactor < 0.51f)
				//middle position
				SetCamOffset ("0.0");
			
			if (camOffsetFactor >= 0.51f && camOffsetFactor <= 1.0f)
				//right position
				SetCamOffset ("0.5");
			
		} else if (swipe == "LEFT") {
			
			if (camOffsetFactor > 0.49f && camOffsetFactor < 0.51f)
				//middle position
				SetCamOffset ("1.0");
			
			
			if (camOffsetFactor >= 0.0f && camOffsetFactor <= 0.49f)
				//left position 
				SetCamOffset ("0.5");
			
		}
		
	}



	/// <summary>
	///	Rotate all cubes 
	/// </summary>
	/// <param name="opt">
	/// A <see cref="System.String"/>
	/// </param>
	public void SetRotation (string opt)
	{
		bool rotate;
		
		
		if (opt == "yes")
			rotate = true;
		else
			rotate = false;
		
		
		foreach (GameObject go in GameObject.FindGameObjectsWithTag ("CubeTag")) {
			go.GetComponent<Rotate> ().SetRotation (rotate);
		}
		
		
	}
	
	static public float[] colorArray = new float[3];
	static public bool colorChange = false; 
	
	public void SetR( string color )
	{
		colorArray[0] = float.Parse( color, CultureInfo.InvariantCulture.NumberFormat);
		colorChange = true;
	}
	
	public void SetG( string color)
	{
		colorArray[1] = float.Parse( color, CultureInfo.InvariantCulture.NumberFormat);
		colorChange = true;
	}
	
	public void SetB( string color)
	{
		
		colorArray[2] = float.Parse( color, CultureInfo.InvariantCulture.NumberFormat);
		colorChange = true;
	}
	
	static public float getColor( int state )
	{
		if( state == 0)
			return colorArray[0];
		if( state == 1)
			return colorArray[1];
		if( state == 2)
			return colorArray[2];
		else
			return colorArray[0];
		
	}
	
	static public bool getColorChange()
	{
		return colorChange;
	}
	
	static public void setColorChange(bool state)
	{
		colorChange = state; 
	}
	
	
	/// <summary>
	/// Receives XY touch values. 
	/// Replaces Unity native touch events.
	/// </summary>
	/// <param name="xy">
	/// A <see cref="System.String"/>
	/// </param>
	void SendTouchXY (string xy)
	{
		string[] coord = xy.Split (',');
		Vector3 pos = new Vector3 (float.Parse (coord[0]), (Screen.height - float.Parse (coord[1])), 0.0f);
		
		if (touchCoord!=null){
			touchCoord.text = "(" + pos.x + "," + pos.y + ")";
		}
	}

	
	
	
	#if UNITY_EDITOR
	/// <summary>
	/// Home switch emulation example.
	/// </summary>
	void OnGUI ()
	{
		GUILayout.BeginHorizontal ();
		if (GUILayout.Button ("Left")) {
			SetCamOffset ("0");
		}
		if (GUILayout.Button ("Center")) {
			SetCamOffset ("0.5");
		}
		if (GUILayout.Button ("Right")) {
			SetCamOffset ("1");
		}
		
		GUILayout.EndHorizontal ();
	}
	
	#endif
	
}