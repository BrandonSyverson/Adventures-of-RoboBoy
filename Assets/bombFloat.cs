using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class bombFloat : MonoBehaviour
{
    private Rigidbody2D theRB;
    private Vector2 initialPosition;
    //float originalY;
    private float speed = .5f;
    private float floatStrength = .1f;
 
    void Start()
    {
        theRB = this.GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
        //this.originalY = this.transform.position.y;
    }
 
    void Update()
    {
        //transform.position = new Vector2(transform.position.x, originalY + ((float)Mathf.Sin(Time.time * speed) * floatStrength));
 
        float newY = Mathf.Sin(Time.time * speed) * floatStrength;
        Vector3 position = new Vector2(0, newY) + initialPosition;
        theRB.MovePosition(position);
    }
}
 