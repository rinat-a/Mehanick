using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shoop : MonoBehaviour
{
    [SerializeField] GameObject healthTowerScr;
    public static Shoop S;
    [SerializeField] Text moneyText;
    public int money = 0;
    [SerializeField] int speedCoast = 5;
    [SerializeField] int barickadCoast = 5;
    [SerializeField] int healthCoast = 5;

    //[SerializeField] GameObject shoopCreen;
    //[SerializeField] Transform canvas;
    //bool isShopCreen = false;

    [SerializeField] Transform PointBarickadprefLeft;  [SerializeField] GameObject PrefBarickadprefRightLeft;
    [SerializeField] Transform PointBarickadprefRight;  [SerializeField] GameObject PrefBarickUpDown;
    [SerializeField] Transform PointBarickadprefDown;  
    [SerializeField] Transform PointBarickadprefUp;  


    private void Awake()
    {
        if (S == null) S = this;
        else Destroy(gameObject);
    }
    private void Start()
    {
        moneyText.text = "Money: " + money;
    }

    public void speedUp()
    {
        if (money >= speedCoast)
        {
            money -= speedCoast;
            PlayerScr.P.upSpeedBuff();
            moneyText.text = "Money: " + money;
        }
    }
    public void Barickad()
    {
        if (money >= barickadCoast)
        {
            money -= barickadCoast;
            moneyText.text = "Money: " + money;
            Instantiate(PrefBarickadprefRightLeft, PointBarickadprefLeft);
            Instantiate(PrefBarickadprefRightLeft, PointBarickadprefRight);
            Instantiate(PrefBarickUpDown, PointBarickadprefDown);
            Instantiate(PrefBarickUpDown, PointBarickadprefUp);
        }
    }
    public void HealthUp()
    {
        money -= barickadCoast;
        moneyText.text = "Money: " + money;
        healthTowerScr.GetComponent<HealthTowerScr>().Uphealth();
    }
    public void moneyUp()
    {
        money++;
        moneyText.text = "Money: " + money;
    }
    /*
    public void shopping()
    {
        if (isShopCreen)
        {
            Instantiate(shoopCreen, canvas);
            isShopCreen = true;
        }
        else
        {
            Destroy(shoopCreen);
            isShopCreen = false;
        }
    }
    */
}
