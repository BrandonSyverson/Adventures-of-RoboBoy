using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
 
    public float Speed = 4.5f;

    private void Start(){
        transform.Rotate(new Vector3(0,0,90));
        
    }

    private void Update()
    {
        
        transform.position += -transform.up * Time.deltaTime * Speed;
    }



    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Enemy"){
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {

            // increase number of available projectiles by one
            //score++;
            // enable the appropriate project UI image
            //projectileImages[numProjectiles-1].enabled = true;
            //UpdateScoreText();
            //print("2 Coin collected. Score = " + score);
            Destroy(collision.gameObject);
        }
    }



}
