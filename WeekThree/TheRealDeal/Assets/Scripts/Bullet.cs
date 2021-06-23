using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public GameObject camera;
    public float cameraSpeed;
    public GamePlay main;
    float deltatime;
    
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera");
        main = camera.GetComponent<GamePlay>();
        cameraSpeed = main.cameraSpeed;
        deltatime = main.deltatime;
    }

    // Update is called once per frame
    void Update()
    {
        deltatime = main.deltatime;
        this.transform.position = this.transform.position + new Vector3(cameraSpeed * deltatime, 0, 0);
        this.transform.position = this.transform.position + new Vector3(bulletSpeed * deltatime, 0, 0);
        
        Debug.Log(cameraSpeed);
        Debug.Log(bulletSpeed);
        OutOfBounds();

    }
    void OutOfBounds()
    {
        if (this.transform.position.x > main.cameraDimensions.x + camera.transform.position.x +1 )
        {
            Destroy(this.gameObject);
        }
    }

}
