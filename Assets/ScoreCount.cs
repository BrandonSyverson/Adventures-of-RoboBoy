using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ScoreCount : MonoBehaviour
{
    // Text Mesh Pro Text Object for Number of Collected Ammo
    public TMP_Text ScoreText;
    public int score = 1;

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
        UpdateScoreText();
        //print("1 Coin updated. Score = " + score);
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {

            // increase number of available projectiles by one
            score++;
            // enable the appropriate project UI image
            //projectileImages[numProjectiles-1].enabled = true;
            UpdateScoreText();
            print("2 Coin collected. Score = " + score);
            Destroy(collision.gameObject);
        }
    }

    private void UpdateScoreText()
    {
        ScoreText.text = score.ToString() + "x";
        //print("3 Coin score text updated. Score = " + score);
    }

}