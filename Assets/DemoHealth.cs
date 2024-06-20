using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoHealth : MonoBehaviour{
    // Our health variable
    public int Health = 100;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    void TakeDamage(){
        Health = Health - 5;
        Debug.Log("Take Damage: " + Health);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Enemy")){
            TakeDamage();
        }
    }

}
