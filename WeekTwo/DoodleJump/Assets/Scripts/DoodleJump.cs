using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoodleJump : MonoBehaviour
{
    public GameObject player;
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject respawner;
    GameObject[] platforms;
    int score;
    public Text scoreDisplay;
    int amountOfMovingPlatforms;
    public GameObject movingPlatform;
    public Text endDisplay1;
    public Text endDisplay2;
    bool isAlive;
    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        amountOfMovingPlatforms = 0;
        player = GameObject.Find("Player");
        leftWall = GameObject.Find("LeftWall");
        rightWall = GameObject.Find("RightWall");
        respawner = GameObject.Find("Respawner");
        InitPlatforms();
        score = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        score = (int)this.transform.position.y;
        scoreDisplay.text = "Score: " + score.ToString();
        for (int i = 0; i < platforms.Length; i++)
        {
            if (platforms[i].transform.position.y <= this.transform.position.y - 8.25f)
            {
                if (platforms[i].layer.Equals(6) && score > 100 && amountOfMovingPlatforms < 3 && Random.value < 0.5)
                {
                    Destroy(platforms[i]);
                    platforms[i] = Instantiate(movingPlatform, new Vector3(Random.Range(-6.5f, 6.5f), this.transform.position.y + 8.25f, 0), Quaternion.identity);
                    amountOfMovingPlatforms++;
                }
                else
                {
                    platforms[i].transform.position = new Vector3(Random.Range(-6.5f, 6.5f), this.transform.position.y + 8.25f, 0);
                    if (platforms[i].GetComponent<Renderer>().material.color.a < 1)
                    {
                        platforms[i].GetComponent<Renderer>().material.color = new Color(platforms[i].GetComponent<Renderer>().material.color.r, platforms[i].GetComponent<Renderer>().material.color.g, platforms[i].GetComponent<Renderer>().material.color.b, 1); ;
                    }
                }

            }
        }
        if (isAlive)
        {
            if (player.transform.position.y < this.transform.position.y - 9)
            {
                isAlive = false;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene("DoodleGameplay");
            }
            SaveGame();
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
        endDisplay1.gameObject.SetActive(!isAlive);
         endDisplay2.gameObject.SetActive(!isAlive);

    }
    private void LateUpdate()
    {
        if (player.transform.position.y > this.transform.position.y)
        {
            Vector3 newPosition = new Vector3(0, player.transform.position.y, -10);
            this.transform.position = Vector3.Lerp(this.transform.position, newPosition, 0.35f);

            leftWall.transform.position = new Vector3(leftWall.transform.position.x, player.transform.position.y, 0);
            rightWall.transform.position = new Vector3(rightWall.transform.position.x, player.transform.position.y, 0);
        }
    }
    void InitPlatforms()
    {
        GameObject[] temp = Object.FindObjectsOfType<GameObject>();
        platforms = new GameObject[11];
        int counter = 0;
        for (int i = 0; i < temp.Length; i++)
        {
            if (temp[i].layer.Equals(6) || temp[i].layer.Equals(7))
            {
                platforms[counter] = temp[i];
                counter++;
            }
            else
            {

            }
        }
    }
    void SaveGame()
    {
        PlayerPrefs.SetInt("SavedInteger", score);
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }
}
