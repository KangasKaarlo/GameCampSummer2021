using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    public GameObject mainCamera;
    public GamePlay main;
    public float parallaxMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        main = mainCamera.GetComponent<GamePlay>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
