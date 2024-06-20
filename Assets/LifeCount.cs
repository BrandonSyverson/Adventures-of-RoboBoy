using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class LifeCount : MonoBehaviour
{
    // Text Mesh Pro Text Object for Number of Collected Ammo
    public TMP_Text LifeText;
    public int life = 2;
    public int maxLife = 3;

    private void Start()
    {
            // disable the project images UI
        //foreach(var image in projectileImages)
        //{
        //    image.enabled = false;
        //}
    }

    // Update is called once per frame
    void Update()
    {   
        UpdateLifeText();
        //print("1 life updated. Life = " + life);
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Life")  && life < maxLife)
        {

            // increase number of available projectiles by one
            life++;
            // enable the appropriate project UI image
            //projectileImages[numProjectiles-1].enabled = true;
            UpdateLifeText();
            print("2 life collected. Life = " + life);
            Destroy(collision.gameObject);
        }
    }

    private void UpdateLifeText()
    {
        //LifeText.text = "Life: " + life.ToString();
        //print("3 Coin score text updated. Life = " + life);
    }

}