using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;
    public int deathValue;
    public ParticleSystem explosion;
    public ParticleSystem death;

    public bool dying;
    public bool doneExploding;

    public GameObject mainCamera;
    public GamePlay main;
    public GameObject player;

    public AudioSource deathSound;

    //variables for shooting
    public GameObject bullet;
    public float timeFromLastShot;
    public float fireRate;
    public abstract float[] ShootingPattern();
    public abstract void Move();
    public GameObject WinScreenScript;

    // Start is called before the first frame update
    void Start()
    {
        WinScreenScript = GameObject.Find("ResultScreen");
        mainCamera = GameObject.Find("Main Camera");
        main = mainCamera.GetComponent<GamePlay>();
        timeFromLastShot = 0f;
        dying = false;
        doneExploding = false;
        player = GameObject.Find("Player");


        WinScreenScript.GetComponent<CanvasGroup>().alpha = 0.0f;
        StartCoroutine(DelayedDisableCanvas());



    }
    // Update is called once per frame
    void Update()
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
                deathSound.pitch = Random.Range(0.9f, 1.1f);
                deathSound.Play();
            }
        }
        else if (health <= 0)
        {
            dying = true;

            Destroy(this.GetComponent<SpriteRenderer>());
            Destroy(this.GetComponent<CircleCollider2D>());
            Destroy(this.GetComponent<Rigidbody2D>());
        }
        else
        {
            Move();
            if (timeFromLastShot >= fireRate)
            {
                if (this.transform.position.x > mainCamera.transform.position.x - 4)
                {
                    Shoot(ShootingPattern());
                }
                
                timeFromLastShot = 0;
            }
            else
            {
                timeFromLastShot += Time.deltaTime;

            }
        }
        CheckForOutOfBounds();
    }
    public virtual void Shoot(float[] angles)
    {
        {
            for (int i = 0; i < angles.Length; i++)
            {
                GameObject newBullet = Instantiate(bullet, new Vector3(this.transform.position.x - 1f, this.transform.position.y, 0), Quaternion.identity);
                newBullet.GetComponent<Bullet>().playerBullet = false;
                newBullet.GetComponent<Bullet>().angle = angles[i];
            }
            
        }
    }
    public void CheckForOutOfBounds()
    {
        if (this.transform.position.x < -main.cameraDimensions.x + mainCamera.transform.position.x - 1 ||
            this.transform.position.y > main.cameraDimensions.y + 1 ||
            this.transform.position.y < -main.cameraDimensions.y - 1)
        {
            Destroy(this.gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet") {
            if (collision.GetComponent<Bullet>().playerBullet)
            {
            health--;
            explosion.Play();
            Destroy(collision.gameObject);
            }
        }
        
    }
            //Work around button highlighting bug
        private IEnumerator DelayedDisableCanvas()
        {
            WinScreenScript.GetComponent<CanvasGroup>().blocksRaycasts = false;
            yield return new WaitForSeconds(0.01f);
        WinScreenScript.GetComponent<CanvasGroup>().interactable = false;
        }

}
