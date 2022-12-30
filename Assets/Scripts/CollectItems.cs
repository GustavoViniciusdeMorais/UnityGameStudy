using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
    private float speed = 2.5f;
    public int items = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        
        print(items);
    }
    
    void OnTriggerEnter2D(Collider2D otherObj)
    {
        if (otherObj.gameObject.CompareTag("item")) {
            items++;
            Destroy(otherObj.gameObject);
        }
    }
}
