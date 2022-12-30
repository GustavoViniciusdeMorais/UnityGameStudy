using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaMove : MonoBehaviour
{
    public bool face = true;
    public GameObject player;
    public float speed = 2.5f;
    public float force = 6.5f;
    public Rigidbody2D playerRb;
    public bool canJump = false;
    public Animator animator;
    public bool alive = true;
    
    // Start is called before the first frame update
    void Start()
    {
    	animator = player.GetComponent<Animator>();
    	playerRb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		if (alive == true) {
			if (Input.GetKey(KeyCode.RightArrow) && !face) {
				Flip();
			}else if (Input.GetKey(KeyCode.LeftArrow) && face) {
				Flip();
			}

			if (Input.GetKey(KeyCode.RightArrow)) {
				transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
				animator.SetBool("idle", false);
				animator.SetBool("run", true);
			}else if (Input.GetKey(KeyCode.LeftArrow)) {
				transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
				animator.SetBool("idle", false);
				animator.SetBool("run", true);
			}else if (Input.GetKeyDown(KeyCode.Space) && canJump == true) {
				playerRb.AddForce(new Vector2(0, force ), ForceMode2D.Impulse);
				animator.SetBool("idle", false);
				animator.SetBool("run", false);
				animator.SetBool("jump", true);
			}else {
				animator.SetBool("run", false);
				animator.SetBool("jump", false);
				animator.SetBool("idle", true);
			}
			
		}
    }
    
    void Flip()
    {
        face = !face;
        Vector3 scale = player.transform.localScale;
        scale.x *= -1;
        player.transform.localScale = scale;
    }
    
    void OnCollisionEnter2D(Collision2D otherObj)
    {
        if (otherObj.gameObject.CompareTag("floor1")) {
            canJump = true;
        }
    }
    
    void OnCollisionExit2D(Collision2D otherObj)
    {
        if (otherObj.gameObject.CompareTag("floor1")) {
            canJump = false;
        }
    }
    
    void OnTriggerEnter2D(Collider2D otherObj)
    {
    	if (otherObj.gameObject.CompareTag("bomb")) {
    		alive = false;
    		animator.SetBool("run", false);
			animator.SetBool("dead", true);
    	}
    }
}
