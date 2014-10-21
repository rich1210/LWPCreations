using UnityEngine;
using System.Collections;

public class ColliderScr : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	

	void OnTriggerEnter (Collider other)
	{
		//if( other.name == "fingerPtr")
		Debug.Log ("Object entered the trigger " + other.name);
	}
	
	void onTriggerStay (Collider other)
	{
		//if( other.name == "fingerPtr")
		Debug.Log ("Object is within trigger");
	}
	
	void onTriggerExit (Collider other)
	{
		//if( other.name == "fingerPtr")
		Debug.Log ("Object has left the trigger");
	}
	
	

	
}
