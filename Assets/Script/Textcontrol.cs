using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textcontrol : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().sortingOrder = 6;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (gameObject.name == "carrot")
        {
            GetComponent<TextMesh>().text = "Carrot Seeds: " + Inventory.carrotSeeds;
        }
        if (gameObject.name == "potato")
        {
            GetComponent<TextMesh>().text = "Potato Seeds: " + Inventory.potatoSeeds;
        }
        if (gameObject.name == "corn")
        {
            GetComponent<TextMesh>().text = "Corn Seeds: " + Inventory.cornSeeds;
        }
        if (gameObject.name == "tomato")
        {
            GetComponent<TextMesh>().text = "Tomato Seeds: " + Inventory.tomatoSeeds;
        }
        if (gameObject.name == "atiso")
        {
            GetComponent<TextMesh>().text = "Atiso Seeds: " + Inventory.cornSeeds;
        }
        if (gameObject.name == "cucumber")
        {
            GetComponent<TextMesh>().text = "Cucumber Seeds: " + Inventory.carrotSeeds;
        }
        if (gameObject.name == "chili")
        {
            GetComponent<TextMesh>().text = "Chili Seeds: " + Inventory.carrotSeeds;
        }
    }

    void OnMouseDown()
    {
        GMScript.currentTool = gameObject.name;
        Debug.Log(GMScript.currentTool);
    }
}
