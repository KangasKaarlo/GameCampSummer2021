using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlatforms : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayerMask;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    private GameObject player;
    bool isFading;
    public float fadeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        isFading = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFading)
        {
            Color platformColor = this.GetComponent<Renderer>().material.color;
            float newFadeAmount = platformColor.a - fadeSpeed * Time.deltaTime;
            this.GetComponent<Renderer>().material.color = new Color(platformColor.r, platformColor.g, platformColor.b, newFadeAmount);

            if (newFadeAmount <= 0)
            {
                isFading = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hep");
        if (player.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {
            isFading = true;
        }
    }    
}
