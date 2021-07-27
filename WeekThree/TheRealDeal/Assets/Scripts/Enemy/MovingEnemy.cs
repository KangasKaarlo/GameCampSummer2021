using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : Enemy
{   public float speed;
    Vector3 spawnLocation;
    Vector2 dir;
    /*
    public int health;
    public int deathValue;
    public ParticleSystem explosion;
    public ParticleSystem death;
    

    bool dying;
    bool doneExploding;

    public GameObject mainCamera;
    public GamePlay main;

 

    //variables for shooting
    public GameObject bullet;
    public float timeFromLastShot;
    public float fireRate;/**/
    // Start is called before the first frame update
    void Start()
    {
        deathValue = 1000;
        mainCamera = GameObject.Find("Main Camera");
        main = mainCamera.GetComponent<GamePlay>();
        
        timeFromLastShot = 0f;
        dying = false;
        doneExploding = false;
        dir = Vector2.down;
        spawnLocation = this.transform.position;
    }

    // Update is called once per frame
    /*void Update()
    {

        if (dying)
        {
            if (death.isPlaying)
            {
                doneExploding = true;
            }
            else if (doneExploding)
            {
                Destroy(this.gameObject);
                ScoreScript.scoreValue += deathValue;
            }
            else
            {
                death.Play();
            }
        }
        else if (health <= 0)
        {
            dying = true;


            Destroy(this.GetComponent<SpriteRenderer>());
            Destroy(this.GetComponent<BoxCollider2D>());
            Destroy(this.GetComponent<Rigidbody2D>());
        }
        else
        {
            this.transform.position += new Vector3(0, dir.y * speed * main.deltatime, 0);
            if (this.transform.position.y < spawnLocation.y -2 || this.transform.position.y > spawnLocation.y + 2)
            {
                this.transform.position = new Vector3(this.transform.position.x, Mathf.Clamp(this.transform.position.y, spawnLocation.y - 2, spawnLocation.y + 2), 0);
                speed = -speed;
            }
            if (timeFromLastShot >= fireRate)
            {
                Shoot();
                timeFromLastShot = 0;
            }
            else
            {
                timeFromLastShot += Time.deltaTime;

            }
        }
        CheckForOutOfBounds();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (collision.GetComponent<Bullet>().playerBullet)
            {
                health--;
                explosion.Play();
                Destroy(collision.gameObject);
            }
        }
        else if (collision.gameObject.tag == "Bomb")
        {
            health = 0;
        }
        
    }
    void Shoot()
    {
        {
            GameObject tmp = Instantiate(bullet, new Vector3(this.transform.position.x - 1f, this.transform.position.y, 0), Quaternion.identity);
            tmp.GetComponent<Bullet>().playerBullet = false;
        }
    }
    void CheckForOutOfBounds()
    {
        if (this.transform.position.x < -main.cameraDimensions.x + mainCamera.transform.position.x - 1)
        {
            Destroy(this.gameObject);
        }
    }/**/

    public override float[] ShootingPattern()
    {
        return new float[] { 0 };
    }

    public override void Move()
    {
        this.transform.position += new Vector3(0, dir.y * speed * main.deltatime, 0);
        if (this.transform.position.y < spawnLocation.y - 2 || this.transform.position.y > spawnLocation.y + 2)
        {
            this.transform.position = new Vector3(this.transform.position.x, Mathf.Clamp(this.transform.position.y, spawnLocation.y - 2, spawnLocation.y + 2), 0);
            speed = -speed;
        }
    }
}
