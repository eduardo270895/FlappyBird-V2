using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bird : MonoBehaviour 
{
	public float upForce= 400f;					// this is the Upward force to flap
	private bool isDead = false;			

	private Animator anim;					//Reference to the Animator component.
	private Rigidbody2D rb2d;				// Reference to the Rigidbody2D component of the bird.

	void Start()
	{
		// Animator component attached to this GameObject.
		anim = GetComponent<Animator> ();
		//Reference to the Rigidbody2D attached to this GameObject.
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		
		if (isDead == false) 
		{
			//Looking  for an input
			if (Input.GetMouseButtonDown(0)) 
			{
				anim.SetTrigger("Flap");
				//Zero out the birds current y velocity before...
				rb2d.velocity = Vector2.zero;
					new Vector2(rb2d.velocity.x, 0);
				//Applying upforce
				rb2d.AddForce(new Vector2(0, upForce));
			}
		}
	}


    void OnCollisionEnter2D(Collision2D other)
  {
      //  bird's velocity to 0
     rb2d.velocity = Vector2.zero;
      // If the bird collides with something is dead
      isDead = true;
     
      anim.SetTrigger ("Die");
        //...and tell the game control about it.
        GameControl.instance.BirdDied();
  }
}

  