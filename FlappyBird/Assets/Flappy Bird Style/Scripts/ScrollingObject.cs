using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour 
{
	private Rigidbody2D rb2d;

	
	void Start () 
	{
		// Reference to the Rigidbody2D attached to this GameObject.
		rb2d = GetComponent<Rigidbody2D>();

		//Start moving.
		rb2d.velocity = new Vector2 (GameControl.instance.scrollSpeed, 0);
	}

	void Update()
	{
		
		if(GameControl.instance.gameOver == true)
		{
            //stop scrolling.

            rb2d.velocity = Vector2.zero;
		}
	}
}
