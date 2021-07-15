using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenClear : MonoBehaviour
{
    public GameObject mainCamera;
    public ParticleSystem graphic;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        if (this.transform.position.x >= mainCamera.transform.position.x + 14)
        {
            Destroy(graphic);
            Destroy(this);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (!collision.GetComponent<Bullet>().playerBullet)
            {
                Destroy(collision.gameObject);
            }
        }
        //Checks for power ups
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().health = 0;
        }
    }

}
