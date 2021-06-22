using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < camera.transform.position.y -13)
        {
            this.transform.position = new Vector3(0, camera.transform.position.y + 13, 5);
        }
    }
}
