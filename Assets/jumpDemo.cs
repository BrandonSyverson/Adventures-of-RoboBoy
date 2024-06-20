using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
// remove this namespace bracketing
namespace MAGD272Demo
{
    public class jumpDemo : MonoBehaviour
    {
        Animator animator;
        //float verticalValue2;
        //public boolean canJump;

        // button to press for jumps
        [SerializeField] private KeyCode jumpButton;
        // the number of jumps made
        [SerializeField] private int numJumps;
        // the jump height value
        [SerializeField] private float jumpForce;
        // the gravity value when falling
        [SerializeField] private float fallingGrav;
        // whether or not we can jump
        [SerializeField] private bool canJump;
        // jump number limit
        [SerializeField] private int jumpLimit;
 
        [SerializeField] private bool onGround;
 
        // vertical value
        [SerializeField] private float verticalValue;
 
        // reference to our rigidbody
        private Rigidbody2D rb;
 
        private void Awake()
        {
            // get reference of rigidbody on gameObject
            rb = GetComponent<Rigidbody2D>();
        }
 
 
        // Start is called before the first frame update
        void Start()
        {
            // reset number of jumps
            numJumps = 0;
                        // gets reference to Rigidbody2D on same GameObject
            rb = GetComponent<Rigidbody2D>();
 
            // get reference to Animator on the same GameObject
            animator = GetComponent<Animator>();
        }
 
        // Update is called once per frame
        void Update()
        {
            GetJumpPress();
            Animate();
        }
 
        void Animate()
        {
            //animator.SetFloat("verticalValue", Mathf.Abs(verticalValue));
            animator.SetFloat("verticalValue", Mathf.Abs(rb.velocity.y));
        }

        private void FixedUpdate()
        {
            // change our gravity scale when falling
            if (rb.velocity.y < 0)
            {
                rb.gravityScale = 1.2f;
            }
            else
            {
                rb.gravityScale = 1;
            }
 
            // ignores horizontal velocity, adds jumpHeight to vertical velocity
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + verticalValue);
        }
 
        void GetJumpPress()
        {
            // check if user presses the jump button
            if (Input.GetKeyDown(jumpButton))
            {
                if (canJump || (numJumps < jumpLimit))
                {
                    // setting our velocity.y to zero
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                    rb.AddForce(new Vector2(0, jumpForce));
                    numJumps++;
                }
            }
        }
 
        // detection of ground collider
        private void OnTriggerEnter2D(Collider2D collision)
        {
            // check if collider has 'Ground' tag
            if (collision.CompareTag("Ground"))
            {
                onGround = true;
                canJump = true;
                numJumps = 0;
            }
        }
 
        // detection of ground collider
        private void OnTriggerExit2D(Collider2D collision)
        {
             //check if collider has 'Ground' tag
            if (collision.CompareTag("Ground"))
            {
                //Debug.Log("off ground");
                canJump = false;
                onGround = false;
            }
        }
 
        private void OnTriggerStay2D(Collider2D collision)
        {
            // check if collider has 'Ground' tag
            if (collision.CompareTag("Ground"))
            {
                //Debug.Log("actually still on ground");
                canJump = true;
                numJumps = 0;
            }
        }
    }
}