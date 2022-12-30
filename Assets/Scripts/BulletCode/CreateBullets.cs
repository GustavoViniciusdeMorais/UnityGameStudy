using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBullets : MonoBehaviour
{
    public GameObject bullets;
    public GameObject gun;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(
                bullets,
                new Vector3(
                    gun.transform.position.x,
                    gun.transform.position.y,
                    gun.transform.position.z
                ),
                Quaternion.identity
            );
            /*
            If you want the gun to rotate and the
            bullets to follow the rotation
            
            Instantiate(
                bullets,
                new Vector3(
                    gun.transform.position.x,
                    gun.transform.position.y,
                    gun.transform.position.z
                ),
                gun.transform.rotation
            );
            */
        }
    }
}
