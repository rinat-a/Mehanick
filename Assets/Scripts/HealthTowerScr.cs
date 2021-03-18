using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HealthTowerScr : MonoBehaviour
{
    [SerializeField] int Health = 3;
    [SerializeField] Text healthText;
    void Start()
    {
        healthText.text = "Health: " + Health;
    }
    public void IsDamage()
    {
        Health--;
        if(Health <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        healthText.text = "Health: " + Health;
    }
    public void Uphealth()
    {
        Health++;
        healthText.text = "Health: " + Health;
    }
}
