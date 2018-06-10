using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tools : MonoBehaviour {

    public Transform cursorObj;
    public Transform seedInvObj;
    public GameObject InventoryCanvas;
    private bool inventoryShowing;
    // Use this for initialization
    void Start () {
        InventoryCanvas.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryShowing = !inventoryShowing;
            InventoryCanvas.SetActive(inventoryShowing);
        }

    }

    void OnMouseDown()
    {
        GMScript.currentTool = gameObject.name;
    
        if (gameObject.name == "seeds")
        {
            seedInvObj.transform.position = new Vector2(7, -4);
        }

        cursorObj.transform.position = transform.position;
        Debug.Log(GMScript.currentTool);
    }

}
