using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    private PlayerScr Player;
    int enemyHealth = 100;
    [SerializeField] int maxHealth = 100;
    [SerializeField] Slider slider;
    [SerializeField] int bonusProcent = 5;
    [SerializeField] int missProcent = 5;

    [SerializeField] TextDamage textPref;

    [SerializeField] Bonus[] bonuses;
    [SerializeField] GameObject bonusPref;

    void Start()
    {
        Player = FindObjectOfType<PlayerScr>();
        enemyHealth = maxHealth;
        slider.value = slider.maxValue= maxHealth;
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        if(enemyHealth < 0)
        {
            Destroy(gameObject);
            BonusDrop();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HealthTowerScr>() != null)
        {
            collision.gameObject.GetComponent<HealthTowerScr>().IsDamage();
            Destroy(gameObject);
        }
        if (collision.gameObject.GetComponent<Baricad>() != null)
        {
            collision.gameObject.GetComponent<Baricad>().IsDamage();
            Destroy(gameObject);
        }
    }
    public void Damage(int damage)
    {
        if (Random.Range(0, missProcent + 1) == missProcent)
        {
            var pref = Instantiate(textPref, transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
            pref.Init("Miss",Color.white);
        }
        else
        {
            enemyHealth -= damage; 
            slider.value = enemyHealth;
        }
    }
    public void BonusDrop()
    {
        if(Random.Range(0, bonusProcent + 1) == bonusProcent)
        {
            var pref = Instantiate(bonusPref,transform.position,transform.rotation);
        }
    }
}
