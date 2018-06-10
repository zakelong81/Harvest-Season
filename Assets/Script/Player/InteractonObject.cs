/* Interact Object behavior
 * Logic behavior when player interact with Object*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class InteractonObject : MonoBehaviour
{    
    public bool inventory = true; //true if object can be put in inventory
    public Plantcontrol plantcontrol;
    public static int fullgrow;
    public static Sprite FinalProductSprite;

    /* Do interaction */
    /*Check if the plant is final state if not add nothing*/
    public void DoInteraction()
    {
        fullgrow = 0;
        gameObject.name = plantcontrol.currentSeed;
        //Picked up and put in inventory
        //check if FINAL STATE IF NOT RETURN FALSE
        if (gameObject.GetComponent<SpriteRenderer>().sprite == plantcontrol.atiso3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = plantcontrol.atiso4;
            plantcontrol.growTime = TimeGrow.ATISO1;
        }
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == plantcontrol.carrot3)
        {
            gameObject.GetComponent <SpriteRenderer>().sprite = plantcontrol.carrot4;
        }
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == plantcontrol.chili3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = plantcontrol.chili4;
            plantcontrol.growTime = TimeGrow.CHILI1;
        }
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == plantcontrol.corn3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = plantcontrol.corn4;
            plantcontrol.growTime = TimeGrow.CORN1;
        }
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == plantcontrol.cucumber3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = plantcontrol.cucumber4;
            plantcontrol.growTime = TimeGrow.CUCUMBER1;
        }
        else if(gameObject.GetComponent<SpriteRenderer>().sprite == plantcontrol.potato3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = plantcontrol.potato4;
        }
        else if(gameObject.GetComponent<SpriteRenderer>().sprite == plantcontrol.tomato3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = plantcontrol.tomato4;
            plantcontrol.growTime = TimeGrow.TOMATO1;
        }
        else
        {
            fullgrow = 1;
        }
    }

    /*Check what kind of plant to add to inventory*/
    public void FinalProduct()
    {
        if (gameObject.GetComponent<SpriteRenderer>().sprite == plantcontrol.atiso4)
        {
            FinalProductSprite = plantcontrol.atiso5;
        }
        else if(gameObject.GetComponent<SpriteRenderer>().sprite == plantcontrol.carrot4)
        {
            FinalProductSprite = plantcontrol.carrot5; 
        }
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == plantcontrol.chili4)
        {
            FinalProductSprite = plantcontrol.chili5;
        }
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == plantcontrol.corn4)
        {
            FinalProductSprite = plantcontrol.corn5;
        }
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == plantcontrol.cucumber4)
        {
            FinalProductSprite = plantcontrol.cucumber5;
        }
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == plantcontrol.potato4)
        {
            FinalProductSprite = plantcontrol.potato5;
        }
        else if (gameObject.GetComponent<SpriteRenderer>().sprite == plantcontrol.tomato4)
        {
            FinalProductSprite = plantcontrol.tomato5;
        }
        else
            FinalProductSprite= plantcontrol.potato5;
    }
}
