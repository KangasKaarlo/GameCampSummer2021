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
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        main = mainCamera.GetComponent<GamePlay>();
        dying = false;
        doneExploding = false;
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
            Destroy(this.GetComponent<BoxCollider2D>());
            Destroy(this.GetComponent<Rigidbody2D>());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            main.playerHealth--;
            Destroy(collision.gameObject);
            explosion.Play();
        }
    }
}
