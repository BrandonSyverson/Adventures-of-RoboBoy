using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombScript : MonoBehaviour
{

    public int numBombs = 0;
    public int maxBombs = 1;
    public bool bombCollected;
    public GameObject BombImage;
    public GameObject BombToolTip;
    public GameObject BombToolTipText;
    public bool showBomb;
    public bool tooltip = false;
    [SerializeField] private KeyCode bombKey;
    //public Image[] bombImages;
    public Transform bombPoint;
    public GameObject bomb;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if (numBombs == 1){
            BombImage.SetActive(true);
        }else{
            BombImage.SetActive(false);
        }

        if (Input.GetKeyDown(bombKey) && numBombs == 1){
            useBomb();
        }
        
        if(numBombs == 1 && tooltip == false){
            bombTooltipS();
            Invoke("toolTipOff", 4f);
        }
        else if(tooltip == true){
            bombTooltipS();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bomb") && numBombs < maxBombs)
        {
            // increase number of available projectiles by one
            numBombs = numBombs+1;
            // enable the appropriate project UI image
            //projectileImages[numProjectiles-1].enabled = true;
            //UpdateBombText();
            Destroy(collision.gameObject);
        }
    }

    private void useBomb(){
        numBombs = numBombs-1;
        Instantiate(bomb, bombPoint.position, transform.rotation);//transform.rotation);
    }

    private void bombTooltipS(){
        if(tooltip == true){
        BombToolTip.SetActive(false);
        BombToolTipText.SetActive(false);
        }
        else{
        BombToolTip.SetActive(true);    
        BombToolTipText.SetActive(true);
        }
    }

    private void toolTipOff(){
        tooltip = true;
    }




}
