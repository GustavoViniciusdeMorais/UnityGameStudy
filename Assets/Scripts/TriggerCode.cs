using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCode : MonoBehaviour
{
    public bool freeAction;
    public GameObject entity;
    
    // Start is called before the first frame update
    void Start()
    {
        freeAction = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (freeAction == true) {
            entity.gameObject.transform.Rotate(new Vector3(0, 0, 5 * Time.deltaTime));
        }
    }
    
    void OnTriggerEnter2D(Collider2D otherObj)
    {
        if (otherObj.gameObject.CompareTag("scenePlayer")) {
            freeAction = true;
        }
    }
    
    void OnTriggerExit2D(Collider2D otherObj)
    {
        if (otherObj.gameObject.CompareTag("scenePlayer")) {
            freeAction = false;
        }
    }
}
