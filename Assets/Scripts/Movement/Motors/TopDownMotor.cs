using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TopDownMotor : MonoBehaviour, IMove
{
    Animator animator;
    Rigidbody2D rb;
        float horizontalSpeed;
        float verticalSpeed;

    [SerializeField] Animator[] animators;
    [SerializeField] private bool facingRight;

    IAttack<Health>[] attackScrpits;

    public float moveSpeed = 10f;



    void Start() {
        attackScrpits = GetComponents<IAttack<Health>>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    void Update() {
        CheckAxes();
        FlipSprite();
    }

    public void Move(Vector2 direction) {
        if (direction.sqrMagnitude < .01f){
            rb.velocity = Vector2.zero;
            UpdateAnimations(direction.x, direction.y);
        }
        else {
            rb.velocity = direction.normalized * moveSpeed;
            UpdateAnimations(direction.normalized.x, direction.normalized.y);
        }
        

    }

    public void UpdateAnimations(float horizontal, float vertical) {
        animator.SetFloat("HorizontalSpeed", horizontal);
        animator.SetFloat("VerticalSpeed", vertical);

        if (animators.Length > 0) {
            foreach (Animator a in animators) {
                a.SetFloat("HorizontalSpeed", horizontal);
                a.SetFloat("VerticalSpeed", vertical);
            }
        }

        if (attackScrpits.Length > 0)
        {
            foreach (IAttack<Health> attack in attackScrpits)
            {
                attack.SetDirection(new Vector2(horizontal, vertical).normalized);
            }
        }
    }

        void CheckAxes()
        {
            horizontalSpeed = Input.GetAxis("Horizontal");//;
            //verticalValue = Input.GetAxis("Vertical") * speed;
            verticalSpeed = 0f;
            //print(horizontalValue + " - " + verticalValue);
        }
 
        void FlipSprite()
        {
            if (horizontalSpeed < 0 && facingRight == true)
            {
                transform.Rotate(0, 180, 0);
                facingRight = false;
            }
            else if (horizontalSpeed > 0 && facingRight == false)
            {
                transform.Rotate(0, 180, 0);
                facingRight = true;
            }
        }








}
