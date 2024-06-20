using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // increase number of available projectiles by one
            //numBombs = numBombs+1;
            // enable the appropriate project UI image
            //projectileImages[numProjectiles-1].enabled = true;
            //UpdateBombText();
            //Destroy(collision.gameObject);
             //Destroy(gameObject);
             Invoke("destroy", .1f);
             
             
        }
    }

void destroy(){
Destroy(gameObject);
}

}
