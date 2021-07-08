using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitReg : MonoBehaviour
{
    public GameObject mainCamera;
    public GamePlay main;
    public ParticleSystem explosion;
    public ParticleSystem death;

    public bool dying;
    public bool doneExploding;
    bool gotHitButAintDeadBitch;
    public GameObject hitbox;

    public float blinkAfterDeath;
    float blinkAfterDeathTimer;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        main = mainCamera.GetComponent<GamePlay>();
        dying = false;
        doneExploding = false;
        gotHitButAintDeadBitch = false;
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
                
            }
            else
            {
                death.Play();
            }
        }
        else if (main.playerHealth <= 0)
        {
            dying = true;

            Destroy(this.GetComponent<SpriteRenderer>());
            Destroy(this.GetComponent<CircleCollider2D>());
            Destroy(this.GetComponent<Rigidbody2D>());
            Destroy(hitbox);
        }
        else if (gotHitButAintDeadBitch)
        {
            if (blinkAfterDeathTimer >= blinkAfterDeath)
            {
                gotHitButAintDeadBitch = false;
                blinkAfterDeathTimer = 0;
                GetComponent<SpriteRenderer>().enabled = true;
                CancelInvoke();
            }
            else
            {
                blinkAfterDeathTimer += main.deltatime;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (!collision.GetComponent<Bullet>().playerBullet && !gotHitButAintDeadBitch)
            {
                main.playerHealth--;
                Destroy(collision.gameObject);
                explosion.Play();
                if (main.playerHealth > 0)
                {
                    gotHitButAintDeadBitch = true;
                    InvokeRepeating("Blink", 0, 0.1f);
                }

            }
        }
        //Checks for power ups
        if (collision.gameObject.tag == "PowerUp")
        {
            main.powerUpCount += 1;
            Destroy(collision.gameObject);
            //Boosts player firerate upon picking up powerups
            //is configured per poweruplever to avoid insane firerates
            switch(main.powerUpCount) {
                case 1:
                    main.fireRate = main.fireRate * 0.75f;
                    break;
                case 2:
                    main.fireRate = main.fireRate * 0.5f;    
                    break;
                default:
                    break;
            }
        }
        /*//Not yet functioning
        if (collision.gameObject.tag == "Enemy")
        {
            main.playerHealth--;
            Destroy(collision.gameObject);
            explosion.Play();
        }*/
    }
    /*public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            main.playerHealth--;
            
        }
    }*/
    void Blink()
    {
        if (GetComponent<SpriteRenderer>().enabled)
        {
            GetComponent<SpriteRenderer>().enabled = false;
        } 
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
