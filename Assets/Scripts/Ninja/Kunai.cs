using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : MonoBehaviour
{
	public float speed = 4.5f;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	transform.Translate(new Vector2(speed * Time.deltaTime, 0));
    }
}
