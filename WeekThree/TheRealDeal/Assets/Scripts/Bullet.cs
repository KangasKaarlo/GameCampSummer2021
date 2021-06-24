using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletBaseSpeed;
    public GameObject camera;
    public GamePlay main;
    public float cameraSpeed;
    public bool playerBullet;
    public float angle;

    float deltatime;
    
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera");
        main = camera.GetComponent<GamePlay>();
        cameraSpeed = main.cameraSpeed;
        deltatime = main.deltatime;
        if (!playerBullet)
        {
            bulletBaseSpeed = -bulletBaseSpeed;
            GetComponent<BoxCollider2D>().size = new Vector3(0.5f, 0.5f, 1);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        deltatime = main.deltatime;

        this.transform.position = this.transform.position + new Vector3(cameraSpeed * deltatime, 0, 0);

        transform.Translate(VectorFromAngle(angle) * bulletBaseSpeed * deltatime);
        CheckForOutOfBounds();
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
}
