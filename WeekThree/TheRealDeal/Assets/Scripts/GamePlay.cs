using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public GameObject player;
    public float playerSpeed;
    public float cameraSpeed;
    public float deltatime;
    // Start is called before the first frame update
    void Start()
    {
        deltatime = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        deltatime = Time.deltaTime;
        PlayerMovement();
    }
    private void LateUpdate()
    {
        CameraMovement();
    }
    void PlayerMovement()
    {
        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        player.transform.position = player.transform.position + new Vector3(dir.x * playerSpeed * deltatime, dir.y * playerSpeed * deltatime, 0);
        
    }
    void CameraMovement()
    {
        this.transform.position = this.transform.position + new Vector3(cameraSpeed * deltatime, 0, 0);
        player.transform.position = player.transform.position + new Vector3(cameraSpeed * deltatime, 0, 0);
    }
}
