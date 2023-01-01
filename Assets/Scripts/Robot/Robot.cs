using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
	public float speed = 5.5f;
	public bool canShot = false;
	public float distance;
	public Transform ninja;
	public bool face = true;
	public Animator animator;
	
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(
        	this.transform.position,
        	ninja.transform.position
        );
        
        // Flip
        if (
        	(ninja.transform.position.x > this.transform.position.x)
        	&& !face
        ) {
        	Flip();
        }else if (
        	(ninja.transform.position.x < this.transform.position.x)
        	&& face
        ) {
        	Flip();
        }
        
        if (canShot && distance < 10.0f) {
        	animator.SetBool("idle", false);
        	animator.SetBool("shot", true);
        } else {
        	animator.SetBool("shot", false);
        	animator.SetBool("idle", true);
        }
    }
    
    void Flip()
    {
    	face = !face;
    	Vector3 scale = this.transform.localScale;
    	scale.x *= -1;
    	this.transform.localScale = scale;
    }
    
    void OnTriggerEnter2D(Collider2D otherObj)
    {
    	if (otherObj.gameObject.CompareTag("scenePlayer")) {
    		canShot = true;
    	}
    }
}
