using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TimeGrow
{
    public static float PLANTDIE = 1000000000;

    public static float CARROT1 = 4;
    public static float CARROT2 = 8;
    public static float CARROT3 = 12;
    public static float CARROT4 = 16;

    public static float POTATO1 = 5;
    public static float POTATO2 = 10;
    public static float POTATO3 = 15;
    public static float POTATO4 = 20;

    public static float CORN1 = 6;
    public static float CORN2 = 12;
    public static float CORN3 = 18;
    public static float CORN4 = 24;

    public static float ATISO1 = 3;
    public static float ATISO2 = 6;
    public static float ATISO3 = 9;
    public static float ATISO4 = 12;

    public static float CHILI1 = 3;
    public static float CHILI2 = 6;
    public static float CHILI3 = 9;
    public static float CHILI4 = 12;

    public static float CUCUMBER1 = 3;
    public static float CUCUMBER2 = 6;
    public static float CUCUMBER3 = 9;
    public static float CUCUMBER4 = 12;

    public static float TOMATO1 = 3;
    public static float TOMATO2 = 6;
    public static float TOMATO3 = 9;
    public static float TOMATO4 = 12;
}
public static class Water
{
    public static float MAXWATER = 40;
    public static float WATERADD = 5;
}

public class Plantcontrol : MonoBehaviour
{

    public Sprite weed0, weed1, weed2;
    public Sprite rock0, rock1, rock2;
    public Sprite branch0, branch1, branch2;
    public Sprite dirt, dirt_water, noPlantObj;

    public Sprite atiso0, atiso1, atiso2, atiso3, atiso4, atiso5;
    public Sprite carrot0, carrot1, carrot2, carrot3, carrot4, carrot5;
    public Sprite chili0, chili1, chili2, chili3, chili4, chili5;
    public Sprite corn0, corn1, corn2, corn3, corn4, corn5;
    public Sprite cucumber0, cucumber1, cucumber2, cucumber3, cucumber4, cucumber5;
    public Sprite potato0, potato1, potato2, potato3, potato4, potato5;
    public Sprite tomato0, tomato1, tomato2, tomato3, tomato4, tomato5;

    /*Time */
    public  float growTime, dieTime, waterTime;
    public bool watered = false;

    public  Transform plotObj;
    public  string currentSeed = "";

    public static int MAXROW = 15;
    public static int MAXCOLUMN = 10;

    private static Plantcontrol plantcontrol;

    private static bool created = false;
    
    void RandomLand()
    {
        int random = UnityEngine.Random.Range(0, 17);
        
        if (random < 8)
            GetComponent<SpriteRenderer>().sprite = noPlantObj;
        if (random == 8)
            GetComponent<SpriteRenderer>().sprite = weed0;
        if (random == 9)
            GetComponent<SpriteRenderer>().sprite = rock0;
        if (random == 10)
            GetComponent<SpriteRenderer>().sprite = branch0;
        if (random == 11)
            GetComponent<SpriteRenderer>().sprite = weed1;
        if (random == 12)
            GetComponent<SpriteRenderer>().sprite = rock1;
        if (random == 13)
            GetComponent<SpriteRenderer>().sprite = branch1;
        if (random == 14)
            GetComponent<SpriteRenderer>().sprite = weed2;
        if (random == 15)
            GetComponent<SpriteRenderer>().sprite = rock2;
        if (random == 16)
            GetComponent<SpriteRenderer>().sprite = branch2;
    }
    void WarterLogic()
    {
        if (waterTime > 0)
        {
            waterTime = waterTime - Time.deltaTime;
            watered = true;
            plotObj.GetComponent<SpriteRenderer>().sprite = dirt_water;
        }
        else
        {
            waterTime = 0;
            watered = false;
            plotObj.GetComponent<SpriteRenderer>().sprite = dirt;

        }
    }
    void Watercheck()
    {

        if (watered == true)
        {
            dieTime = 0;
            growTime = growTime + Time.deltaTime;
        }
        if (watered == false)
        {
            dieTime = dieTime + Time.deltaTime;
        }
        if (dieTime > TimeGrow.PLANTDIE)
        {
            GetComponent<SpriteRenderer>().sprite = noPlantObj;
            currentSeed = "";
            dieTime = 0;
            growTime = 0;
        }
    }
    void CarrotGrow()
    {
        if (GetComponent<SpriteRenderer>().sprite == noPlantObj)
        {
            GetComponent<SpriteRenderer>().sprite = carrot0;
        }
        if (GetComponent<SpriteRenderer>().sprite != carrot3 && GetComponent<SpriteRenderer>().sprite != carrot4)
        {
                Watercheck();
        }
        if (GetComponent<SpriteRenderer>().sprite == carrot0)
        {
            if (growTime > TimeGrow.CARROT1)
            {
                GetComponent<SpriteRenderer>().sprite = carrot1;
            }
        }
        if (GetComponent<SpriteRenderer>().sprite == carrot1)
        {
            if (growTime > TimeGrow.CARROT2)
            {
                GetComponent<SpriteRenderer>().sprite = carrot2;
            }
        }
        if (GetComponent<SpriteRenderer>().sprite == carrot2)
        {
            if (growTime > TimeGrow.CARROT3)
            {
                GetComponent<SpriteRenderer>().sprite = carrot3;
               
            }
        }
    }
    void PotatoGrow()
    {
        if (GetComponent<SpriteRenderer>().sprite == noPlantObj)
        {
            GetComponent<SpriteRenderer>().sprite = potato0;
        }
        if (GetComponent<SpriteRenderer>().sprite != potato3 && GetComponent<SpriteRenderer>().sprite != potato4)
        {
                Watercheck();
        }
        if (GetComponent<SpriteRenderer>().sprite == potato0)
        {
            if (growTime > TimeGrow.POTATO1)
            {
                GetComponent<SpriteRenderer>().sprite = potato1;
            }
        }
        if (GetComponent<SpriteRenderer>().sprite == potato1)
        {
            if (growTime > TimeGrow.POTATO2)
            {
                GetComponent<SpriteRenderer>().sprite = potato2;
            }
        }
        if (GetComponent<SpriteRenderer>().sprite == potato2)
        {
            if (growTime > TimeGrow.POTATO3)
            {
                GetComponent<SpriteRenderer>().sprite = potato3;
            }
        }
    }
    void CornGrow()
    {
        if (GetComponent<SpriteRenderer>().sprite == noPlantObj)
        {
            GetComponent<SpriteRenderer>().sprite = corn0;
        }
        else
        {
            Watercheck();
        }
        if (GetComponent<SpriteRenderer>().sprite == corn0)
        {

            if (growTime > TimeGrow.CORN1)
            {
                GetComponent<SpriteRenderer>().sprite = corn1;
            }
        }
        if (GetComponent<SpriteRenderer>().sprite == corn1)
        {
            if (growTime > TimeGrow.CORN2)
            {
                GetComponent<SpriteRenderer>().sprite = corn2;
            }
        }
        if (GetComponent<SpriteRenderer>().sprite == corn2)
        {
            if (growTime > TimeGrow.CORN3)
            {
                GetComponent<SpriteRenderer>().sprite = corn3;
            }
        }
        if (GetComponent<SpriteRenderer>().sprite == corn4)
        {
            if (growTime > TimeGrow.CORN2)
            {
                GetComponent<SpriteRenderer>().sprite = corn2;
            }
        }
    }
    void ChiliGrow()
    {
        if (GetComponent<SpriteRenderer>().sprite == noPlantObj)
        {
            GetComponent<SpriteRenderer>().sprite = chili0;
        }
        else
        {
            Watercheck();
        }
        if (GetComponent<SpriteRenderer>().sprite == chili0)
        {

            if (growTime > TimeGrow.CHILI1)
            {
                GetComponent<SpriteRenderer>().sprite = chili1;
            }
        }
        if (GetComponent<SpriteRenderer>().sprite == chili1)
        {
            if (growTime > TimeGrow.CHILI2)
            {
                GetComponent<SpriteRenderer>().sprite = chili2;
            }
        }
        if (GetComponent<SpriteRenderer>().sprite == chili2)
        {
            if (growTime > TimeGrow.CHILI3)
            {
                GetComponent<SpriteRenderer>().sprite = chili3;
            }
        }
        if (GetComponent<SpriteRenderer>().sprite == chili4)
        {
            if (growTime > TimeGrow.CHILI2)
            {
                GetComponent<SpriteRenderer>().sprite = chili2;
            }
        }
    }
    void AtisoGrow()
    {
        if (GetComponent<SpriteRenderer>().sprite == noPlantObj)
        {
            GetComponent<SpriteRenderer>().sprite = atiso0;
        }
        else
        {
            Watercheck();
        }
        if (GetComponent<SpriteRenderer>().sprite == atiso0)
        {

            if (growTime > TimeGrow.ATISO1)
            {
                GetComponent<SpriteRenderer>().sprite = atiso1;
            }
        }
        if (GetComponent<SpriteRenderer>().sprite == atiso1)
        {
            if (growTime > TimeGrow.ATISO2)
            {
                GetComponent<SpriteRenderer>().sprite = atiso2;
            }
        }
        if (GetComponent<SpriteRenderer>().sprite == atiso2)
        {
            if (growTime > TimeGrow.ATISO3)
            {
                GetComponent<SpriteRenderer>().sprite = atiso3;
            }
        }
        if (GetComponent<SpriteRenderer>().sprite == atiso4)
        {
            if (growTime > TimeGrow.ATISO2)
            {
                GetComponent<SpriteRenderer>().sprite = atiso2;
            }
        }
    }
    void CucumberGrow()
    {

        if (GetComponent<SpriteRenderer>().sprite == noPlantObj)
        {
            GetComponent<SpriteRenderer>().sprite = cucumber0;
        }
        else
        {
            Watercheck();
        }
        if (GetComponent<SpriteRenderer>().sprite == cucumber0)
        {

            if (growTime > TimeGrow.CUCUMBER1)
            {
                GetComponent<SpriteRenderer>().sprite = cucumber1;
            }
        }
        if (GetComponent<SpriteRenderer>().sprite == cucumber1)
        {
            if (growTime > TimeGrow.CUCUMBER2)
            {
                GetComponent<SpriteRenderer>().sprite = cucumber2;
            }
        }
        if (GetComponent<SpriteRenderer>().sprite == cucumber2)
        {
            if (growTime > TimeGrow.CUCUMBER3)
            {
                GetComponent<SpriteRenderer>().sprite = cucumber3;
            }
        }
        if (GetComponent<SpriteRenderer>().sprite == cucumber4)
        {
            if (growTime > TimeGrow.CUCUMBER2)
            {
                GetComponent<SpriteRenderer>().sprite = cucumber2;
            }
        }
    }
    void TomatoGrow()
    {

        if (GetComponent<SpriteRenderer>().sprite == noPlantObj)
        {
            GetComponent<SpriteRenderer>().sprite = tomato0;
        }
        else
        {
            Watercheck();
        }
        if (GetComponent<SpriteRenderer>().sprite == tomato0)
        {

            if (growTime > TimeGrow.TOMATO1)
            {
                GetComponent<SpriteRenderer>().sprite = tomato1;
            }
        }
        if (GetComponent<SpriteRenderer>().sprite == tomato1)
        {
            if (growTime > TimeGrow.TOMATO2)
            {
                GetComponent<SpriteRenderer>().sprite = tomato2;
            }
        }
        if (GetComponent<SpriteRenderer>().sprite == tomato2)
        {
            if (growTime > TimeGrow.TOMATO3)
            {
                GetComponent<SpriteRenderer>().sprite = tomato3;
            }
        }
        if (GetComponent<SpriteRenderer>().sprite == tomato4)
        {
            if (growTime > TimeGrow.TOMATO2)
            {
                GetComponent<SpriteRenderer>().sprite = tomato2;
            }
        }
    }
    void PlantGrow()
    {
        if (currentSeed == "carrot")
        {
            CarrotGrow();
        }
        if (currentSeed == "potato")
        {
            PotatoGrow();
        }
        if (currentSeed == "corn")
        {
            CornGrow();
        }
        if (currentSeed == "chili")
        {
            ChiliGrow();
        }
        if (currentSeed == "atiso")
        {
            AtisoGrow();
        }
        if (currentSeed == "cucumber")
        {
            CucumberGrow();
        }
        if (currentSeed == "tomato")
        {
            TomatoGrow();
        }
    }


    // Use this for initialization
    void Start()
    {
        RandomLand();
    }

    void Awake()
    {
   
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake: " + this.gameObject);
        }
       
    }


    // Update is called once per frame
    void Update()
    {
        WarterLogic();
        PlantGrow();
    }


    void OnMouseDown()
    {
        if (GetComponent<SpriteRenderer>().sprite == noPlantObj)
        {
            currentSeed = GMScript.currentTool;
        }

        if (GMScript.currentTool == "scythe")
        {
            if (currentSeed != "")
            {
                currentSeed = "";
                dieTime = 0;
                growTime = 0;
            }
            if (GetComponent<SpriteRenderer>().sprite != rock0
                && GetComponent<SpriteRenderer>().sprite != rock1
                && GetComponent<SpriteRenderer>().sprite != rock2
                && GetComponent<SpriteRenderer>().sprite != branch0
                && GetComponent<SpriteRenderer>().sprite != branch1
                && GetComponent<SpriteRenderer>().sprite != branch2)
            {
                    GetComponent<SpriteRenderer>().sprite = noPlantObj;
            }                   
        }
        else if (GMScript.currentTool == "pickaxe")
        {
            if (GetComponent<SpriteRenderer>().sprite == rock0
               || GetComponent<SpriteRenderer>().sprite == rock1
               || GetComponent<SpriteRenderer>().sprite == rock2)
            { 
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
            }
        }

        else if (GMScript.currentTool == "axe")
        {
            if (GetComponent<SpriteRenderer>().sprite == branch0
               || GetComponent<SpriteRenderer>().sprite == branch1
               || GetComponent<SpriteRenderer>().sprite == branch2)
            {
                GetComponent<SpriteRenderer>().sprite = noPlantObj;
            }
        }

        else if (GMScript.currentTool == "bucket")
        {
            if (waterTime < Water.MAXWATER)
            {
                waterTime = waterTime + Water.WATERADD;
            }
            if (waterTime > Water.MAXWATER)
            {
                waterTime = Water.MAXWATER;
            }
        }
        else if (GMScript.currentTool == "harvest")
        {
            if (GetComponent<SpriteRenderer>().sprite == carrot3)
            {
                GetComponent<SpriteRenderer>().sprite = carrot4;
            }
            if (GetComponent<SpriteRenderer>().sprite == potato3)
            {
                GetComponent<SpriteRenderer>().sprite = potato4;
            }
            if (GetComponent<SpriteRenderer>().sprite == corn3)
            {
                GetComponent<SpriteRenderer>().sprite = corn4;
                growTime = TimeGrow.CORN1;
            }
            if (GetComponent<SpriteRenderer>().sprite == chili3)
            {
                GetComponent<SpriteRenderer>().sprite = chili4;
                growTime = TimeGrow.CHILI1;
            }
            if (GetComponent<SpriteRenderer>().sprite == atiso3)
            {
                GetComponent<SpriteRenderer>().sprite = atiso4;
                growTime = TimeGrow.ATISO1;
            }
            if (GetComponent<SpriteRenderer>().sprite == cucumber3)
            {
                GetComponent<SpriteRenderer>().sprite = cucumber4;
                growTime = TimeGrow.CUCUMBER1;
            }
            if (GetComponent<SpriteRenderer>().sprite == tomato3)
            {
                GetComponent<SpriteRenderer>().sprite = tomato4;
                growTime = TimeGrow.TOMATO1;
            }
        }       
    }
}
