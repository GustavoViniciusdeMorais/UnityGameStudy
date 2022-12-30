using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float force = 200f;
    public Rigidbody2D ball;
    public bool canJump = false;
    public int twoJump = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (twoJump > 0) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                ball.AddForce(new Vector2(0, force * Time.deltaTime), ForceMode2D.Impulse);
                twoJump--;
            }
        }
    }
    
    void OnCollisionEnter2D(Collision2D otherObject)
    {
        if (otherObject.gameObject.CompareTag("floor1")) {
            twoJump = 2;
        }
    }
    
    /*
    void OnCollisionExit2D(Collision2D otherObject)
    {
        if (otherObject.gameObject.CompareTag("floor1")) {
            canJump = false;
        }
    }
    */
}
