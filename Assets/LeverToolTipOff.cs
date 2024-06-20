using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeverToolTipOff : MonoBehaviour
{
    public Canvas ToolPromptCanvas1;

    void OnTriggerEnter2D(Collider2D TheThingEnteringTheTrigger){
        if(TheThingEnteringTheTrigger.tag == "Player"){
            ToolPromptCanvas1.enabled = false;
            Debug.Log("Player by lever");
        }
    }

}
