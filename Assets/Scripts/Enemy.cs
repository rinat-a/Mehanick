using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    private PlayerScr Player;
    [SerializeField] Transform player;
    int enemyHealth = 100;
    [SerializeField] int maxHealth = 100;
    [SerializeField] Slider slider;
    [SerializeField] int bonusProcent = 5;
    [SerializeField] int missProcent = 5;

    [SerializeField] TextDamage textPref;

    [SerializeField] Bonus[] bonuses;
    [SerializeField] GameObject bonusPref;
    [SerializeField] GameObject particles;
    Vector3 moveDirection;
    void Start()
    {
        Player = FindObjectOfType<PlayerScr>();
        enemyHealth = maxHealth;
        slider.value = slider.maxValue= maxHealth;
        moveDirection = player.position - transform.position;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(-moveDirection.x, moveDirection.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HealthTowerScr>() != null)
        {
            collision.gameObject.GetComponent<HealthTowerScr>().IsDamage();
            var part = Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(part, 0.4f);
            Destroy(gameObject);
        }
        if (collision.gameObject.GetComponent<Baricad>() != null)
        {
            collision.gameObject.GetComponent<Baricad>().IsDamage();
            var part = Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(part, 0.4f);
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
            if (enemyHealth < 0)
            {
                Destroy(gameObject);
                BonusDrop();
            }
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
