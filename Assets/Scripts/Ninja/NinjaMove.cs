using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaMove : MonoBehaviour
{
    public bool face = true;
    public GameObject player;
    public float speed = 5.5f;
    public float force = 10.5f;
    public Rigidbody2D playerRb;
    public bool canJump = false;
    public Animator animator;
    public bool alive = true;
    public GameObject kunai;
    public GameObject kunaiPoint;
    public Vector3 scale;
    
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
			}else if (Input.GetKeyDown(KeyCode.UpArrow) && canJump == true) {
				playerRb.AddForce(new Vector2(0, force ), ForceMode2D.Impulse);
				animator.SetBool("idle", false);
				animator.SetBool("run", false);
				animator.SetBool("jump", true);
			}else {
				animator.SetBool("run", false);
				animator.SetBool("jump", false);
				animator.SetBool("idle", true);
			}
			
			// Kunai code
			if (Input.GetKeyDown(KeyCode.Space)) {
				if (!face) {
					kunaiPoint.transform.rotation = Quaternion.Euler(
						kunaiPoint.transform.rotation.x,
						kunaiPoint.transform.rotation.y,
						180
					);
				} else {
					kunaiPoint.transform.rotation = Quaternion.Euler(
						kunaiPoint.transform.rotation.x,
						kunaiPoint.transform.rotation.y,
						kunaiPoint.transform.rotation.z
					);
				}
				
				Instantiate(
		            kunai,
		            new Vector3(
		                kunaiPoint.transform.position.x,
		                kunaiPoint.transform.position.y,
		                kunaiPoint.transform.position.y
		            ),
		            kunaiPoint.transform.rotation
	            );
			}
		}
    }
    
    void Flip()
    {
        face = !face;
        scale = player.transform.localScale;
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
