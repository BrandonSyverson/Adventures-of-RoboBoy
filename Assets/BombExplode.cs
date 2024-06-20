using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplode : MonoBehaviour
{

    public bool exploded = false;
    public GameObject bombDamage;
    public Transform bombPoint;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("causeDamage", 2.0f);
        Invoke("explode", 2.6f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void causeDamage(){
        Instantiate(bombDamage, bombPoint.position, transform.rotation);
    }


    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Box")){// && exploded == true){
            //Destroy(collision.gameObject);
        }
    }

    void explode(){
        //Instantiate(bombDamage, bombPoint.position, transform.rotation);
        Destroy(gameObject);
        exploded = true;
        
    }



}
