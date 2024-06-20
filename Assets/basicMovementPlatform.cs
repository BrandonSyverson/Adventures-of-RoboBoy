using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MAGD272Demo;
 
// remove this namespace bracketing
namespace MAGD272Demo
{
 
    public class basicMovementPlatform : MonoBehaviour
    {
        [SerializeField] private bool facingRight;
 
        float horizontalValue;
        float verticalValue;
 
        public float speed;
 
        Rigidbody2D rb;
 
        // reference var for our Animator Component
        Animator animator;
 
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private GameObject bulletPrefab;
 
        private void Start()
        {
            // gets reference to Rigidbody2D on same GameObject
            rb = GetComponent<Rigidbody2D>();
 
            // get reference to Animator on the same GameObject
            animator = GetComponent<Animator>();
        }
 
        // Update is called once per frame
        void Update()
        {
            CheckAxes();
            Animate();
            //PositionMove();
            FlipSprite();
        }
 
        void FixedUpdate()
        {
            // call physics-related methods like setvelocity in FixedUpdate
 
            // Use either Set Velocity or ForceMove. Not both. They are different movement ideas
 
            SetVelocity();
 
            //ForceMove();
        }
 
        void Animate()
        {
            // use the absolute value of horizontal so that "horizontalValue" parameter is
            // only between 0 and +number
            animator.SetFloat("horizontalValue", Mathf.Abs(horizontalValue));
            //animator.SetFloat("verticalValue", Mathf.Abs(verticalValue));
        }
 
        void CheckAxes()
        {
            horizontalValue = Input.GetAxis("Horizontal") * speed;
            //verticalValue = Input.GetAxis("Vertical") * speed;
            verticalValue = 0f;
            //print(horizontalValue + " - " + verticalValue);
        }
 
        void FlipSprite()
        {
            if (horizontalValue < 0 && facingRight == true)
            {
                transform.Rotate(0, 180, 0);
                facingRight = false;
            }
            else if (horizontalValue > 0 && facingRight == false)
            {
                transform.Rotate(0, 180, 0);
                facingRight = true;
            }
        }
 
 
        // the three functions below control our movement, we should only be calling one of these at anytime. 
 
        void PositionMove()
        {
            // changing by addressing its Transform.position
            //transform.position += new Vector3(horizontalValue, verticalValue, 0);
            transform.Translate(new Vector3(horizontalValue, verticalValue, 0));
        }
 
        void SetVelocity()
        {
            // assigns value to our rigidbody's velocity
            rb.velocity = new Vector2(horizontalValue, verticalValue + rb.velocity.y);
        }
 
        void ForceMove()
        {
            rb.AddForce(new Vector2(horizontalValue, verticalValue));
        }
    }
}