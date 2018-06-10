using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerInventory : MonoBehaviour
{
    public static int  MAX_INVENTORY = 20;
    public static int  MAX_ITEM = 99;
  
    public string[] inventory = new string[MAX_INVENTORY];
    public int[] stack = new int[MAX_INVENTORY];

    public Button[] InventoryButtons = new Button[MAX_INVENTORY];
    public Text[] StackText = new Text[MAX_INVENTORY];

    public void AddItem(GameObject item)
    {
        //Find empty space
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == "")
            {
                if (inventory.Contains(item.name))
                {
                    item.SendMessage("DoInteraction");
                    if (InteractonObject.fullgrow == 0)
                    { 
                        for (int j = 0; j < inventory.Length; j++)
                        {
                            if (inventory[j] == item.name)
                            {
                                stack[j]++;
                                StackText[j].text = stack[j].ToString();
                                j = inventory.Length;
                                i = inventory.Length;
                            }
                        }
                    }
                }
                else
                {                 
                    
                    item.SendMessage("DoInteraction");
                    if (InteractonObject.fullgrow == 0)
                    {
                        if (inventory.Contains(item.name))
                        {
                            for (int j = 0; j < inventory.Length; j++)
                            {
                                if (inventory[j] == item.name)
                                {
                                    stack[j]++;
                                    StackText[j].text = stack[j].ToString();
                                    j = inventory.Length;
                                    i = inventory.Length;
                                }
                            }
                        }                      
                        else
                        {
                            inventory[i] = item.name;
                            item.SendMessage("FinalProduct");
                            InventoryButtons[i].image.overrideSprite = InteractonObject.FinalProductSprite;
                            stack[i]++;
                            StackText[i].text = stack[i].ToString();
                            i = inventory.Length;
                        }
                            
                    }
                    
                }
            }
        }
    }



    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
}

