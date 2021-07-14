using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public GameObject powerUp;
    public int powerUpCount = 0;
    public float playerSpeed;
    public float cameraSpeed;
    public float deltatime;
    public bool paused;

    public Vector2 cameraDimensions;
    public float timeFromLastShot;
    public float fireRate;
    public int playerHealth;
    public float playerSpeedMultiplier;

    public GameObject playerPrefab;
    public GameObject continueScreen;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        powerUp = GameObject.Find("PowerUp");
        timeFromLastShot = 0f;
        fireRate = 0.2f;
        //powerUpCount = 0;
        deltatime = Time.deltaTime;
        cameraDimensions = new Vector2(Camera.main.orthographicSize * 1.77f, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        deltatime = Time.deltaTime;
        PlayerMovement();
        //PowerUpCounter();
        if (timeFromLastShot >= fireRate)
        {
            Shoot();
            timeFromLastShot = 0;
        }
        else
        {
            timeFromLastShot += deltatime;

        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("CoreGameplay");
        }
    }
    private void LateUpdate()
    {
        if(playerHealth > 0)
        {
            CameraMovement();
        }
    }
    void PlayerMovement()
    {
        float trueSpeed;
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            trueSpeed = playerSpeed * playerSpeedMultiplier;
        } else
        {
            trueSpeed = playerSpeed;
        }
        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        player.transform.position = ClampPositionToCamera(player.transform.position + new Vector3(dir.x * trueSpeed * deltatime, dir.y * trueSpeed * deltatime, 0), player.transform.localScale);
    }
    void CameraMovement()
    {
        this.transform.position = this.transform.position + new Vector3(cameraSpeed * deltatime, 0, 0);
        player.transform.position = player.transform.position + new Vector3(cameraSpeed * deltatime, 0, 0);
    }
    Vector3 ClampPositionToCamera(Vector3 location, Vector3 scale)
    {
        return new Vector3(Mathf.Clamp(location.x, -cameraDimensions.x + scale.x / 2 + this.transform.position.x, cameraDimensions.x - scale.x / 2 + this.transform.position.x),
                            Mathf.Clamp(location.y, -cameraDimensions.y + scale.y / 2, cameraDimensions.y - scale.y / 2), location.z);
    }
    void Shoot()
    {
        if (Input.GetKey(KeyCode.Space) && playerHealth > 0)
        {
            if (powerUpCount > 2) 
            {
                powerUpCount = 2;
            }
            switch(powerUpCount){
                case 0:
                    GameObject tmp = Instantiate(bullet, new Vector3(player.transform.position.x + 0.5f, player.transform.position.y, 0), Quaternion.identity);
                    tmp.GetComponent<Bullet>().playerBullet = true;
                    tmp.GetComponent<Bullet>().angle = 0;
                    break;
                case 1: 
                    GameObject tmp2 = Instantiate(bullet, new Vector3(player.transform.position.x + 0.5f, player.transform.position.y + 0.5f, 0), Quaternion.identity);
                    tmp2.GetComponent<Bullet>().playerBullet = true;
                    tmp2.GetComponent<Bullet>().angle = 0; 
                    GameObject tmp3 = Instantiate(bullet, new Vector3(player.transform.position.x + 0.5f, player.transform.position.y - 0.5f, 0), Quaternion.identity);
                    tmp3.GetComponent<Bullet>().playerBullet = true;
                    tmp3.GetComponent<Bullet>().angle = 0;
                    break;
                case 2:
                    GameObject tmp4 = Instantiate(bullet, new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, 0), Quaternion.identity);
                    tmp4.GetComponent<Bullet>().playerBullet = true;
                    tmp4.GetComponent<Bullet>().angle = 0; 
                    GameObject tmp5 = Instantiate(bullet, new Vector3(player.transform.position.x, player.transform.position.y - 0.5f, 0), Quaternion.identity);
                    tmp5.GetComponent<Bullet>().playerBullet = true;
                    tmp5.GetComponent<Bullet>().angle = 0;
                    break;
            }
            
        }
    }
    
         Vector2 VectorFromAngle (float theta) {
         return new Vector2 (Mathf.Cos(theta), Mathf.Sin(theta)); // Trig is fun
    }
    public void Yes()
    {
        continueScreen.SetActive(false);
        playerHealth = 3;
        Time.timeScale = 1;
        this.transform.position += new Vector3(-24, 0, 0);
        player.GetComponent<PlayerHitReg>().dying = false;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<CircleCollider2D>().enabled = true;
        player.GetComponent<PlayerHitReg>().hitbox.SetActive(true);
        player.transform.position = new Vector3(this.transform.position.x - 4, 0, player.transform.position.z);
    }
    public void No()
    {
        Debug.Log("NO");
    }
}
