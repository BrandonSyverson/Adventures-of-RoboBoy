using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCount : MonoBehaviour
{

    //public TMP_Text KeyText;
    public int key = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateKeyText();
    }

        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {

            // increase number of available projectiles by one
            key++;
            // enable the appropriate project UI image
            //projectileImages[numProjectiles-1].enabled = true;
            //UpdateKeyText();
            print("1 key collected. Key = " + key);
            Destroy(collision.gameObject);
        }
    }

    //private void UpdateKeyText()
    //{
    //    KeyText.text = "Keys: " + key.ToString();
    //    //print("3 Coin score text updated. Score = " + score);
    //}




}
