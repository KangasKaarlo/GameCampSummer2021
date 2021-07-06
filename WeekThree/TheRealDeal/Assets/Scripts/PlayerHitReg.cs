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
        InvokeRepeating("Player", 0, 0.1f);
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
        if (collision.gameObject.tag == "PowerUp")
        {
            main.powerUpCount += 1;
            Destroy(collision.gameObject);
        
        }
        if (collision.gameObject.tag == "Enemy")
        {
            main.playerHealth--;
            Destroy(collision.gameObject);
            explosion.Play();
        }
    }
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
