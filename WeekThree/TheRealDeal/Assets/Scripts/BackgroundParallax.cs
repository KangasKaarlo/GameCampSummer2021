using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    public GameObject mainCamera;
    public GamePlay main;
    public float parallaxMultiplier;

    Vector2 startPosition;
    float startZ;
    float distanceFromThePlayer => transform.position.z;

    Vector2 travel => (Vector2)mainCamera.transform.position;
    Vector2 parallaxFactor;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        main = mainCamera.GetComponent<GamePlay>();

        startPosition = this.transform.position;
        startZ = this.transform.position.z;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = new Vector3(startPosition.x + travel.x * parallaxMultiplier, startPosition.y + travel.y * parallaxMultiplier, startZ );
    }
}
