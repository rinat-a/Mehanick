using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Shoop : MonoBehaviour
{
    [SerializeField] GameObject healthTowerScr;
    [SerializeField] GameObject playerScr;
    public static Shoop S;
    [SerializeField] Text moneyText;
    public int money = 10;

    [SerializeField] GameObject shopPanel;
    [SerializeField] GameObject MenuPanel;
    #region upCoast
    [SerializeField] int speedCoast = 5;
    [SerializeField] int barickadCoast = 5;
    [SerializeField] int healthCoast = 5;
    [SerializeField] int upReloadCoast = 5;
    [SerializeField] int upbulletCountCoast = 5;
    #endregion

    #region Barickad
    [SerializeField] Transform PointBarickadprefLeft;  [SerializeField] GameObject PrefBarickadprefRightLeft;
    [SerializeField] Transform PointBarickadprefRight;  [SerializeField] GameObject PrefBarickUpDown;
    [SerializeField] Transform PointBarickadprefDown;  
    [SerializeField] Transform PointBarickadprefUp;
    #endregion

    private void Awake()
    {
        if (S == null) S = this;
        else Destroy(gameObject);
    }
    private void Start()
    {
        money += barickadCoast;
        Barickad();
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
        if (money >= healthCoast)
        {
            money -= healthCoast;
            moneyText.text = "Money: " + money;
            healthTowerScr.GetComponent<HealthTowerScr>().Uphealth();
        }
    }
    public void moneyUp()
    {
        money++;
        moneyText.text = "Money: " + money;
    }
    public void OpenShop() => shopPanel.SetActive(true);
    public void CloseShop() => shopPanel.SetActive(false);
    public void upReload()
    {
        if (money >= upReloadCoast)
        {
            money -= upReloadCoast;
            moneyText.text = "Money: " + money;
            playerScr.GetComponent<PlayerScr>().upReload();
        }
    }
}
