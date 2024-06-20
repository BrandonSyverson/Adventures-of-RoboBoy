using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInput : MonoBehaviour
{
    Rigidbody2D rb;

    private float horVal;
    private float verVal;

    //[SerializedField]
    private float speed = 20;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(Input.GetAxisRaw("Horizontal"));
        horVal = Input.GetAxisRaw("Horizontal");

        //print(Input.GetAxisRaw("Vertical"));
        verVal = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate(){
        //rb.AddForce(new Vector2(horVal * speed, verVal * speed));
        rb.velocity = new Vector2(horVal * speed, verVal * speed);
    }

}
