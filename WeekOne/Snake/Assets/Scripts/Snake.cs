using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public SnakeSettings settings;
    public GameObject player;
    
    public SnakeCollision snakeCollision;
    public GameObject apple;
    public Vector2 dir;
    public Vector2 lastMoveDir;
    public float timeFromLastStep;
    List<Transform> snakePieces;
    public GameObject piece;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Snake");
        apple = GameObject.Find("Apple");
        dir = Vector2.right;
        lastMoveDir = Vector2.right;
        timeFromLastStep = 0;
        snakePieces = new List<Transform>();
        snakePieces.Add(player.transform);
        GrowSnake();
        GrowSnake();
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
        if (Input.GetKey(KeyCode.A) && lastMoveDir != Vector2.right)
            dir = Vector2.left;
        if (Input.GetKey(KeyCode.D) && lastMoveDir != Vector2.left)
            dir = Vector2.right;
        if (Input.GetKey(KeyCode.W) && lastMoveDir != Vector2.down)
            dir = Vector2.up;
        if (Input.GetKey(KeyCode.S) && lastMoveDir != Vector2.up)
            dir = Vector2.down;
    }
    void SnakeMove()
    {

        for (int i = snakePieces.Count -1 ; i > 0; i--)
        {
            snakePieces[i].position = snakePieces[i - 1].position;
        }

        player.transform.position = new Vector3(
            player.transform.position.x + dir.x,
            player.transform.position.y + dir.y,
            0);

        lastMoveDir = dir;
        //wrapping the movement from one edge of the srceen to another
        if (player.transform.position.x > 9)
        {
            player.transform.position = new Vector3(
                -player.transform.position.x,
                player.transform.position.y,
                0);
        }
        else if (player.transform.position.x < -10)
        {
            player.transform.position = new Vector3(
                9,
                player.transform.position.y,
                0);
        }
        else if (player.transform.position.y > 4)
        {
            player.transform.position = new Vector3(
                player.transform.position.x,
                -player.transform.position.y,
                0);
        }
        else if (player.transform.position.y < -5)
        {
            player.transform.position = new Vector3(
                player.transform.position.x,
                4,
                0);
        }
    }
    //Eat calls GrowSnake and Food when the player collides with the apple
    void Eat() 
    {
       //OnTriggerEnter2D();
    }
    //Food randomly generates a position for the apple, 
    //and makes sure the apple won't collide with the player when spawned
    public void MoveFood() 
    {
        int foodX = (int)Random.Range(-10, 9);
        int foodY = (int)Random.Range(-5, 4);
        apple.transform.position = new Vector3(
        foodX, foodY, 0
        );

    }
    
    
    public void GrowSnake()
    {
        GameObject newPart = Instantiate(piece);
        newPart.transform.position = snakePieces[snakePieces.Count - 1].position;
        snakePieces.Add(newPart.transform);
    }
}
[System.Serializable]
public struct SnakeSettings
{
    public float stepLength;
}
