using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletBaseSpeed;
    public GameObject camera;
    public GamePlay main;
    public GameObject player;
    public float cameraSpeed;
    public bool playerBullet;
    public float angle;

    public Sprite enemyBulletTexture;
    public Sprite playerBulletTexture;
    float deltatime;
    public float playerBulletMultiplier;

    public bool homing;
    bool homingStarted;
    public float timeUntillHoming;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        camera = GameObject.Find("Main Camera");
        main = camera.GetComponent<GamePlay>();
        cameraSpeed = main.cameraSpeed;
        deltatime = main.deltatime;
        if (!playerBullet)
        {
            bulletBaseSpeed = bulletBaseSpeed * 0.75f;
            bulletBaseSpeed = -bulletBaseSpeed;
            GetComponent<CircleCollider2D>().radius = 0.25f;
            this.GetComponent<SpriteRenderer>().sprite = enemyBulletTexture;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = playerBulletTexture;
            //makes the powerUpLevel 0 feel sluggish compared to the rest 
            //gives the player a feeling of pride and accomplishment
            if (main.powerUpCount > 0)
            {
                playerBulletMultiplier = playerBulletMultiplier * 1.1f;
            }
            bulletBaseSpeed = bulletBaseSpeed * playerBulletMultiplier;
        }
        if (homing)
        {
            homingStarted = false;
            timer = 0;
            bulletBaseSpeed = bulletBaseSpeed / 2;
        }

    }

    // Update is called once per frame
    void Update()
    {

        deltatime = main.deltatime;

        this.transform.position = this.transform.position + new Vector3(cameraSpeed * deltatime, 0, 0);
        
        transform.Translate(VectorFromAngle(angle) * bulletBaseSpeed * deltatime);
        CheckForOutOfBounds();
        if (homing && !homingStarted)
        {
            if (timer >= timeUntillHoming)
            {
                homingStarted = true;
                bulletBaseSpeed = bulletBaseSpeed * 3;
                bulletBaseSpeed = -bulletBaseSpeed;
                angle = AngleInDeg(this.transform.position, player.transform.position);
            }
            else
            {
                timer += main.deltatime;
            }
            
            
        }

    }
    void CheckForOutOfBounds()
    {
        if (this.transform.position.x > main.cameraDimensions.x + camera.transform.position.x +1 ||
            this.transform.position.x < -main.cameraDimensions.x + camera.transform.position.x - 1 ||
            this.transform.position.y > main.cameraDimensions.y  + 1 ||
            this.transform.position.y < -main.cameraDimensions.y - 1)
        {
            Destroy(this.gameObject);
        }
    }
    Vector2 VectorFromAngle(float degree)
    {
        return (Vector2)(Quaternion.Euler(0, 0, degree) * Vector2.right);
    }
    public static float AngleInDeg(Vector3 vec1, Vector3 vec2)
    {
        return AngleInRad(vec1, vec2) * 180 / Mathf.PI;
    }
    public static float AngleInRad(Vector3 vec1, Vector3 vec2)
    {
        return Mathf.Atan2(vec2.y - vec1.y, vec2.x - vec1.x);
    }
}
