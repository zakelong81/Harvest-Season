using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerProfile : MonoBehaviour
{
    public Image ImgHealthBar;
    public Text TxtBar;

    public float min;
    public float max;

    private float mCurrentValue;
    private float mCurrentPercent;
    public PlayerController playercontroller;
    public void SetStamina(float stamia)
    {
        stamia= stamia * 10;
        if(stamia != mCurrentValue)
        {
            
            if (max - min == 0)
            {
                mCurrentValue = 0;
                mCurrentPercent = 0;
            }
            else
            {
                mCurrentValue = stamia;
                mCurrentPercent = mCurrentValue / (max - min);
            }
            ImgHealthBar.fillAmount = mCurrentPercent;
          
            if (mCurrentValue < 20)
            {
                if (playercontroller.out_stamina == true)
                {
                    ImgHealthBar.color = new Color32(255, 0, 0, 255);
                }
                else
                    ImgHealthBar.color = new Color32(255, 255, 0, 255);
            }
            else if (mCurrentValue > 20)
            {
                ImgHealthBar.color = new Color32(0, 255, 0, 255);
            }

        }
     
    }

    public float CurrentPercent()
    {
        return mCurrentPercent;
    }
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetStamina(playercontroller.stamia );
    }
}
