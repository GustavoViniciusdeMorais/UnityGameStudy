using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoad : MonoBehaviour
{
    public float speed = 0.1f;
    public Renderer quad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(0, speed * Time.deltaTime);
        quad.material.mainTextureOffset += offset;
    }
}
