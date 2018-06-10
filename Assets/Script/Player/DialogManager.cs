using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogManager : MonoBehaviour
{
    public GameObject think_box;
    public Text think_text;
    public Plantcontrol plantcontrol;

    public float sec = 2f;
    private int check = 0;
    // Use this for initialization
    void Start()
    {

        think_box.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DiaLogGrowCheck(GameObject item)
    {

        if (item.GetComponent<SpriteRenderer>().sprite == plantcontrol.noPlantObj)
        {
            think_text.text = "I can start grow something here";
        }

        else if (item.GetComponent<SpriteRenderer>().sprite == plantcontrol.branch0 ||
            item.GetComponent<SpriteRenderer>().sprite == plantcontrol.branch1 ||
            item.GetComponent<SpriteRenderer>().sprite == plantcontrol.branch2)
        {
            think_text.text = "I can use axe to chop this branch";
        }

        else if (item.GetComponent<SpriteRenderer>().sprite == plantcontrol.rock0 ||
            item.GetComponent<SpriteRenderer>().sprite == plantcontrol.rock1 ||
            item.GetComponent<SpriteRenderer>().sprite == plantcontrol.rock2)
        {
            think_text.text = "I can use pickaxe to smash rock";
        }

        else if (item.GetComponent<SpriteRenderer>().sprite == plantcontrol.weed0 ||
          item.GetComponent<SpriteRenderer>().sprite == plantcontrol.weed1 ||
          item.GetComponent<SpriteRenderer>().sprite == plantcontrol.weed2)
        {
            think_text.text = "I can use scythe to cut weed";
        }
        else
        {
            item.SendMessage("DoInteraction");
            if (InteractonObject.fullgrow == 1)
            {        
                think_text.text = "I need to wait for it to fully grow";             
            }
        }

        // wait for 1 second before turn off
        // this can be improve 
        if(check == 0)
        {
            check = 1;
            StartCoroutine(LateCall());
        }
        
        
    }

    IEnumerator LateCall()
    {
        think_box.SetActive(true);
        yield return new WaitForSeconds(sec);
        think_box.SetActive(false);
        check = 0;
    }

}
