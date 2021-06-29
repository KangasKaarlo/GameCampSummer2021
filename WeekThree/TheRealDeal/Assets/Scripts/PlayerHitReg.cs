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
                this.GetComponent<Renderer>().material.color = new Color(this.GetComponent<Renderer>().material.color.r, this.GetComponent<Renderer>().material.color.g, this.GetComponent<Renderer>().material.color.b, 100);
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
    }
    void Blink()
    {
        Color current = this.GetComponent<Renderer>().material.color;
        if (this.GetComponent<Renderer>().material.color.a == 100)
        {
            this.GetComponent<Renderer>().material.color = new Color(current.r, current.g, current.b, 0);
        } 
        else
        {
            this.GetComponent<Renderer>().material.color = new Color(current.r, current.g, current.b, 100);
        }
    }
}
