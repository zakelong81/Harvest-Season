using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMScript : MonoBehaviour
{

    public static string currentTool = "none";

    public Plantcontrol plantcontrol;
    public static int MAXROW = 18;
    public static int MAXCOLUMN = 18;




    // Use this for initialization
    void Start()
    {
   
        Plantcontrol pl;
        for (int xPos = 0; xPos < MAXROW; xPos = xPos + 2)
        {
            for (int yPos = 0; yPos < MAXCOLUMN; yPos = yPos + 2)
            {
                pl = Instantiate(plantcontrol, new Vector2(xPos, yPos), Quaternion.identity);
                pl.GetComponent<SpriteRenderer>().sortingOrder = MAXCOLUMN - yPos;
            }
        }
      

        
    }
    


    void OnGUI()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
}
