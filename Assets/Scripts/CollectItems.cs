using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectItems : MonoBehaviour
{
    private float speed = 2.5f;
    public int items = 0;
    public GameObject itemSound;
    public TMP_Text score;
    
    // Start is called before the first frame update
    void Start()
    {
        //score = GameObject.FindWithTag("Score").GetComponent<UnityEngine.UI.Text>();
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
            Instantiate(
                itemSound,
                new Vector3(
                    this.gameObject.transform.position.x,
                    this.gameObject.transform.position.y,
                    this.gameObject.transform.position.z
                ),
                Quaternion.identity
            );
            items++;
            score.text = items.ToString();
            Destroy(otherObj.gameObject);
        }
    }
}
