using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
    List<GameObject> snakePieces;
    public GameObject piece;
    public GameObject boom;
    public AudioSource ooof;
    bool isAlive;
    public Text text;

    public Sprite head;
    public Sprite body;
    public Sprite tail;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        player = GameObject.Find("Snake");
        apple = GameObject.Find("Apple");
        dir = Vector2.right;
        lastMoveDir = Vector2.right;
        timeFromLastStep = 0;
        snakePieces = new List<GameObject>();
        snakePieces.Add(player);
        GrowSnake();
        GrowSnake();
        text.gameObject.SetActive(!isAlive);
        snakePieces[0].GetComponent<SpriteRenderer>().sprite = head;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            GetInput();
            if (timeFromLastStep >= settings.stepLength)
            {
                SnakeMove();
                SetTextures();
                CheckForDeath();
                timeFromLastStep = 0;
            }
            else
            {
                timeFromLastStep += Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene("Snake");
            }
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
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
            snakePieces[i].transform.position = snakePieces[i - 1].transform.position;
        }

        player.transform.position = new Vector3(
            player.transform.position.x + dir.x,
            player.transform.position.y + dir.y,
            0);

        //Saves the last made move to prevent backtracking
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
        newPart.transform.position = snakePieces[snakePieces.Count - 1].transform.position;
        snakePieces.Add(newPart);
        snakePieces[snakePieces.Count - 1].SetActive(false);
    }
    void CheckForDeath()
    {
        for (int i = 3; i < snakePieces.Count; i++)
        {
            if (snakePieces[i].transform.position.Equals(snakePieces[0].transform.position))
            {
                isAlive = false;
                text.gameObject.SetActive(!isAlive);
                ooof.Play();
            }
        }
    }
    void SetTextures()
    {
        snakePieces[snakePieces.Count - 1].SetActive(true);
        snakePieces[snakePieces.Count - 2].SetActive(true);
        //direction of the head
        snakePieces[0].transform.localEulerAngles = new Vector3(0, 0, 0);

        if (lastMoveDir == Vector2.left)
        {
            snakePieces[0].GetComponent<SpriteRenderer>().flipX = true;
            snakePieces[0].GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            snakePieces[0].GetComponent<SpriteRenderer>().flipX = false;
            snakePieces[0].GetComponent<SpriteRenderer>().flipY = false;
        }

        if (lastMoveDir == Vector2.up)
        {
            snakePieces[0].transform.localEulerAngles = new Vector3(0, 0, 90);
        }
        else if (lastMoveDir == Vector2.down)
        {
            snakePieces[0].transform.localEulerAngles = new Vector3(0, 0, -90);
        }


        //position of the tail
        snakePieces[snakePieces.Count - 1].GetComponent<SpriteRenderer>().sprite = tail;
        snakePieces[snakePieces.Count - 1].transform.localEulerAngles = new Vector3(0, 0, 0);
        
        if (snakePieces[snakePieces.Count - 2].transform.position == snakePieces[snakePieces.Count - 1].transform.position + Vector3.left)
        {
            snakePieces[snakePieces.Count - 1].GetComponent<SpriteRenderer>().flipX = true;
        } 
        else
        {
            snakePieces[snakePieces.Count - 1].GetComponent<SpriteRenderer>().flipX = false;
        }


        if (snakePieces[snakePieces.Count - 2].transform.position == snakePieces[snakePieces.Count - 1].transform.position + Vector3.up)
        {
            snakePieces[snakePieces.Count - 1].transform.localEulerAngles = new Vector3(0, 0, 90);
        }
        else if (snakePieces[snakePieces.Count - 2].transform.position == snakePieces[snakePieces.Count - 1].transform.position + Vector3.down)
        {
            snakePieces[snakePieces.Count - 1].transform.localEulerAngles = new Vector3(0, 0, -90);
        }

        for (int i = 1; i < snakePieces.Count-1; i++)
        {
            snakePieces[i].GetComponent<SpriteRenderer>().sprite = body;
        }
    }
}
[System.Serializable]
public struct SnakeSettings
{
    public float stepLength;
}
