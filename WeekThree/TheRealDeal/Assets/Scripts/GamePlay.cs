using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public float playerSpeed;
    public float cameraSpeed;
    public float deltatime;
    public Vector2 cameraDimensions;
    public float timeFromLastShot;
    public float fireRate;
    public int playerHealth;
    public float playerSpeedMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        timeFromLastShot = 0f;
        fireRate = 0.2f;
        deltatime = Time.deltaTime;
        cameraDimensions = new Vector2 (Camera.main.orthographicSize * 1.77f, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        deltatime = Time.deltaTime;
        PlayerMovement();
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
        if (Input.GetKey(KeyCode.Space))
        {
            GameObject tmp = Instantiate(bullet, new Vector3(player.transform.position.x + 0.5f, player.transform.position.y, 0), Quaternion.identity);
            tmp.GetComponent<Bullet>().playerBullet = true;
            tmp.GetComponent<Bullet>().angle = 0;
        }
    }
         Vector2 VectorFromAngle (float theta) {
         return new Vector2 (Mathf.Cos(theta), Mathf.Sin(theta)); // Trig is fun
     }
}
