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
		
		// send a message to cubeManager
		VectorsScr.setBoxName(other.name);
		
		// distroy our selfs when colliding with boxes
		Destroy(gameObject);
	}
	
}
