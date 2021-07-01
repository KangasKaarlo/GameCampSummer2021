using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    public GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x <= mainCamera.transform.position.x - 13)
        {
            this.transform.position += new Vector3(26, 0, 0);
        } 
        else
        {
            this.transform.position += new Vector3(-3f * Time.deltaTime, 0, 0);
        }
    }
}
