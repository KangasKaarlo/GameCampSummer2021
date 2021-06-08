using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public SnakeSettings settings;
    public GameObject player;
    public Vector2 dir;
    public float timeFromLastStep;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Snake");
        dir = Vector2.right;
        timeFromLastStep = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        if (timeFromLastStep >= settings.stepLength)
        {
            SnakeMove();
            timeFromLastStep = 0;
        }
        else
        {
            timeFromLastStep += Time.deltaTime;
        }
    }
    void GetInput()
    {
        if (Input.GetKey(KeyCode.A))
            dir = Vector2.left;
        if (Input.GetKey(KeyCode.D))
            dir = Vector2.right;
        if (Input.GetKey(KeyCode.W))
            dir = Vector2.up;
        if (Input.GetKey(KeyCode.S))
            dir = Vector2.down;
    }
    void SnakeMove()
    {
        player.transform.position = new Vector3(
            Mathf.Clamp(player.transform.position.x + dir.x, -10, 9),
            Mathf.Clamp(player.transform.position.y + dir.y, -5, 4),
            0
            );
    }
}
[System.Serializable]
public struct SnakeSettings
{
    public float stepLength;
    public float pylly;
}
