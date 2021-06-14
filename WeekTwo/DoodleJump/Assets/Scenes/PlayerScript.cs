using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask;
    public GameObject player;
    // Start is called before the first frame update
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    
    void Start()
    {
        player = GameObject.Find("Player");
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (IsGrounded()){
            float jumpVelocity = 10f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }
    }
    void Jump()
    {
        
    }
    //Checks if the player is gounded
    private bool IsGrounded() 
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider !=null;
        

    }

}
