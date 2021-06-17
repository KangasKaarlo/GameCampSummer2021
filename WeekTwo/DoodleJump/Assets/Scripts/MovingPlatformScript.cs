using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    private GameObject player;
    bool moveRight = true;
    float moveSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >6.5f)
        {
            moveRight = false;
        }
        if (transform.position.x < -6.5f)
        {
            moveRight = true;
        }
        if (moveRight) {
            transform.position = new Vector2(transform.position.x +moveSpeed*Time.deltaTime, transform.position.y );
        }
        else {
            transform.position = new Vector2(transform.position.x -moveSpeed*Time.deltaTime, transform.position.y );
        }
    }
}
