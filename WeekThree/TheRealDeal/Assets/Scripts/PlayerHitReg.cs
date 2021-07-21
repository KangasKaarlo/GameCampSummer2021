using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerHitReg : MonoBehaviour
{
    public GameObject mainCamera;
    public GamePlay main;
    public ParticleSystem explosion;
    public ParticleSystem death;
    public AudioSource powerUpSound;

    public bool dying;
    public bool doneExploding;
    bool gotHitButAintDeadBitch;
    public GameObject hitbox;

    public GameObject continueScreen;

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
        Disable();
       
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
                Time.timeScale = 0;
                Enable();
                dying = false;
            }
            else
            {
                death.Play();
            }
        }
        else if (main.playerHealth <= 0)
        {
            dying = true;
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<CircleCollider2D>().enabled = false;
            hitbox.SetActive(false);

            /*Destroy(this.GetComponent<SpriteRenderer>());
            Destroy(this.GetComponent<CircleCollider2D>());
            Destroy(this.GetComponent<Rigidbody2D>());
            Destroy(hitbox);/**/
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
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" && !gotHitButAintDeadBitch)
        {
            main.playerHealth--;
            
            col.gameObject.GetComponent<Enemy>().health -= 3;
            explosion.Play();
            if (main.playerHealth > 0)
                {
                    gotHitButAintDeadBitch = true;
                    InvokeRepeating("Blink", 0, 0.1f);
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
            powerUpSound.Play();
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
    public void Enable()
    {
        continueScreen.GetComponent<CanvasGroup>().alpha = 1.0f;
        continueScreen.GetComponent<CanvasGroup>().interactable = true;
        continueScreen.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    public void Disable()
    {
        continueScreen.GetComponent<CanvasGroup>().alpha = 0.0f;
        //m_canvasGroup.blocksRaycasts = false;
        //m_canvasGroup.interactable = false;
        StartCoroutine(DelayedDisable());
    }

    //Work around button highlighting bug
    private IEnumerator DelayedDisable()
    {
        continueScreen.GetComponent<CanvasGroup>().blocksRaycasts = false;
        yield return new WaitForSeconds(0.01f);
        continueScreen.GetComponent<CanvasGroup>().interactable = false;
    }
}
