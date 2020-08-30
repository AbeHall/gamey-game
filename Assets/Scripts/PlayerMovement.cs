using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public PlayerInput input;
	public int facing = 1;
	public Animator anim;
	public int currentJumps = 1;
    public int numberOfJumps = 1; 

	Rigidbody2D rb;
	float varyJumpHeightDuration = 0.5f;
    float varyJumpHeightForce = 10f;
    float jumpSpeed = 32f;
    Coroutine varyJumpHeight;
    float delayedJumpDuration = 0.05f;
    CapsuleCollider2D col;
    RaycastHit2D[] hits = new RaycastHit2D[10];
    bool grounded = true;


    


    // Start is called before the first frame update
    void Start()
    {
    	 rb = GetComponent<Rigidbody2D>();
    	 col = GetComponent<CapsuleCollider2D>();
        
    }
 
    // Update is called once per frame
    void Update()
    {
    	anim.SetBool("Grounded", IsGrounded());
    	bool moving = input.MoveX != 0;
    	if(IsGrounded()){
    		currentJumps = numberOfJumps;
    	}
    	if (moving)
        {
        	if(grounded){
        		anim.SetBool("Walking", true);
        	}
        	UnityEngine.Debug.Log(input.Jump);
        	updateFacing();

        	rb.velocity = new Vector2(13* facing,rb.velocity.y);

        }
        else{
        	rb.velocity = new Vector2(rb.velocity.x * .99f,rb.velocity.y);
        	anim.SetBool("Walking", false);
        }

        if (input.Jump && currentJumps > 0) //&& rb.velocity.y < 0.8f * jumpSpeed)
        {
            currentJumps--;
            rb.velocity = new Vector2(rb.velocity.x,15f);
        }
        
    }

    public void updateFacing()
    {
        if(input.MoveX > 0){
                facing = 1;
            }
        else if(input.MoveX < 0){
            facing = -1;
        }
        transform.localScale = new Vector3(facing * Mathf.Abs(transform.localScale.x),
        transform.localScale.y, transform.localScale.z);
    }

    private bool IsGrounded()
    {
        int count = Physics2D.RaycastNonAlloc(col.bounds.center + col.bounds.extents.y * Vector3.down, Vector3.down, hits, 0.2f);
        for (int i = 0; i < count; i++)
        {
            if (hits[i].collider.gameObject.tag == "Ground")
            {
                return true;
            }
        }
        return false;
    }
}
