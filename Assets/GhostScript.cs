using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
int x = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            //transform.position.z = 0;
    }


void OnCollisionEnter2D(Collision2D collision)
{
    x++;
    if(x % 3 == 0){
    GetComponent<CircleCollider2D>().enabled = false;
    Invoke("enableHitbox", 5f);
    }
}

void enableHitbox(){
    GetComponent<CircleCollider2D>().enabled = true;
}


}