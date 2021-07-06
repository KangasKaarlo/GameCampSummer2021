using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public GameObject mainCamera;
     public GameObject player;
    public GamePlay main;

    // Start is called before the first frame update
    void Start()
    {
        
        mainCamera = GameObject.Find("Main Camera");
        main = mainCamera.GetComponent<GamePlay>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CheckForOutOfBounds();
    }
   
    void CheckForOutOfBounds()
    {
        if (this.transform.position.x < -main.cameraDimensions.x + mainCamera.transform.position.x - 1 ||
            this.transform.position.y > main.cameraDimensions.y + 1 ||
            this.transform.position.y < -main.cameraDimensions.y - 1)
        {
            Destroy(this.gameObject);
        }
    }
}
