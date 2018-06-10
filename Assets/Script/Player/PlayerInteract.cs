using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerInteract : MonoBehaviour
{
    public GameObject currrentInterObj = null;
    public InteractonObject currentInterObjScript = null;
    public PlayerInventory inventory;
    public DialogManager dialog;
// Update is called once per frame
void Update()
    {
        if (Input.GetButtonDown("Interact") && currrentInterObj != null)
        {
            // check if can be stored in inventory
            if(currentInterObjScript.inventory)
            {
                inventory.AddItem(currrentInterObj);
                dialog.DiaLogGrowCheck(currrentInterObj);
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Plant"))
        {
            currrentInterObj = other.gameObject;
            currentInterObjScript = currrentInterObj.GetComponent<InteractonObject>();
        }

    
    }
    void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Plant"))
        {
            if (other.gameObject == currrentInterObj)
            {
                currrentInterObj = null;
            }
        }
    }
}
