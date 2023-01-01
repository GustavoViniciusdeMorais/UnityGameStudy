using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsMove : MonoBehaviour
{
	private float speed = 2.5f;
	public Button btRight;
	public Button btLeft;
	public bool moveRight;
	public bool moveLeft;
	
    // Start is called before the first frame update
    void Start()
    {
        btRight.onClick.AddListener(ClickRight);
        btLeft.onClick.AddListener(ClickLeft);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight) {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        } else if (moveLeft) {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
    }
    
    void ClickRight()
    {
    	moveRight = true;
    	moveLeft = false;
    }
    
    void ClickLeft()
    {
    	moveRight = false;
    	moveLeft = true;
    }
}
