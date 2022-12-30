using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    public float force = 2.5f;
    public Rigidbody2D ball;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (
            Input.GetKeyDown(KeyCode.Space)
            & this.gameObject.CompareTag("ball")
    	) {
            ball.AddForce(new Vector2(0, force * Time.deltaTime), ForceMode2D.Impulse);
        }
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(h * Time.deltaTime, v * Time.deltaTime, 0));
    }
}
