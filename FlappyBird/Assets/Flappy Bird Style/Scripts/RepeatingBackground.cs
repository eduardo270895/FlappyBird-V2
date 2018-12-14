using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RepeatingBackground : MonoBehaviour 
{
	
	private BoxCollider2D groundCollider;		
	private float groundHorizontalLength;		//Stores the x-axis length of the collider2D attached 

	
	private void Awake ()
     
	{
		//Get and store a reference to the collider2D 
		groundCollider = GetComponent<BoxCollider2D> ();
		//Stores the size of the collider along the x axis.
		groundHorizontalLength = groundCollider.size.x;
	}


	 void Update()
	{
		//Check if the difference along the x axis between the main Camera and the position of the object.
        
		if (transform.position.x < -groundHorizontalLength)
		{
	    //If true, this means this object is no longer visible and we can safely move it forward to be re-used.
			RepositionBackground ();
		}
	}


	private void RepositionBackground()
	{
		Vector2 groundOffSet = new Vector2(groundHorizontalLength * 2f, 0);

		
		transform.position = (Vector2) transform.position + groundOffSet;
	}
}