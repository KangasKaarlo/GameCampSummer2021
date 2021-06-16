using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoodleJump : MonoBehaviour
{
    public GameObject player;
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject respawner;
    GameObject[] platforms;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        leftWall = GameObject.Find("LeftWall");
        rightWall = GameObject.Find("RightWall");
        respawner = GameObject.Find("Respawner");
        InitPlatforms();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < platforms.Length; i++)
        {
            if (platforms[i].transform.position.y <= this.transform.position.y -8.25f)
            {
                platforms[i].transform.position = new Vector3(Random.Range(-6.5f, 6.5f), this.transform.position.y + 8.25f, 0);
                if (platforms[i].GetComponent<Renderer>().material.color.a < 1)
                {
                    platforms[i].GetComponent<Renderer>().material.color = new Color(platforms[i].GetComponent<Renderer>().material.color.r, platforms[i].GetComponent<Renderer>().material.color.g, platforms[i].GetComponent<Renderer>().material.color.b, 1); ;
                }
            }
        }
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
        platforms = new GameObject[temp.Length-1];
        int counter = 0;
        for (int i = 0; i < temp.Length; i++)
        {
            if (temp[i].Equals(player))
            {
               
            }
            else
            {
                platforms[counter] = temp[i];
                counter++;
            }
        }
    }
}
