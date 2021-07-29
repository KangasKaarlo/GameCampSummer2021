using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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

    public int bombCount;
    public GameObject bomb;
    bool everySecondBullet;
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
        if (Input.GetKey(KeyCode.B) && bombCount > 0)
        {
            bombCount--;
            Instantiate(bomb, new Vector3(this.transform.position.x - 13, 0, -2), Quaternion.identity);
        }

    }
    private void LateUpdate()
    {
        if (playerHealth > 0)
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
            if (powerUpCount > 3)
            {
                powerUpCount = 3;
            }
            switch (powerUpCount)
            {
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
                case 3:
                    GameObject tmp6 = Instantiate(bullet, new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, 0), Quaternion.identity);
                    tmp6.GetComponent<Bullet>().playerBullet = true;
                    tmp6.GetComponent<Bullet>().angle = 0;
                    GameObject tmp7 = Instantiate(bullet, new Vector3(player.transform.position.x, player.transform.position.y - 0.5f, 0), Quaternion.identity);
                    tmp7.GetComponent<Bullet>().playerBullet = true;
                    tmp7.GetComponent<Bullet>().angle = 0;
                    if (everySecondBullet)
                    {
                        everySecondBullet = false;
                        GameObject tmp8 = Instantiate(bullet, new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, 0), Quaternion.identity);
                        tmp8.GetComponent<Bullet>().playerBullet = true;
                        tmp8.GetComponent<Bullet>().angle = 35;
                        GameObject tmp9 = Instantiate(bullet, new Vector3(player.transform.position.x, player.transform.position.y - 0.5f, 0), Quaternion.identity);
                        tmp9.GetComponent<Bullet>().playerBullet = true;
                        tmp9.GetComponent<Bullet>().angle = -35;
                    } else
                    {
                        everySecondBullet = true;
                    }
                    break;
            }
        }
    }
    public void Yes()
    {

        //continueScreen.SetActive(false);
        player.GetComponent<PlayerHitReg>().Disable();
        playerHealth = 3;
        ScoreScript.scoreValue = ScoreScript.scoreValue -ScoreScript.scoreValue/3;
        bombCount = 1;
        Time.timeScale = 1;
        this.transform.position += new Vector3(-24, 0, 0);
        player.GetComponent<PlayerHitReg>().dying = false;
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<CircleCollider2D>().enabled = true;
        player.GetComponent<PlayerHitReg>().hitbox.SetActive(true);
        player.GetComponent<PlayerHitReg>().doneExploding = false;
        player.transform.position = new Vector3(this.transform.position.x - 4, 0, player.transform.position.z);
    }
    public void No()
    {
        Debug.Log("NO");
    }
}
