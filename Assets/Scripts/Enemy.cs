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
    [SerializeField] float distanceToMeat = 5.0f;

    [SerializeField] GameObject[] stars;
    [SerializeField] int twoStar = 10;
    [SerializeField] int threeStar = 10;
    [SerializeField] LayerMask maetLayer;


    GameObject meat;
    Vector3 moveDirection;
    void Start()
    {
        Player = FindObjectOfType<PlayerScr>();
        player = Player.transform;
        enemyHealth = maxHealth;
        slider.value = slider.maxValue= maxHealth;
        moveDirection = player.position - transform.position;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(-moveDirection.x, moveDirection.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        slider.transform.position = transform.position + new Vector3(0, 0.6f, 0);
        slider.transform.rotation = Quaternion.identity;
        RandomStar();
    }

    void RandomStar()
    {
        if (Random.Range(0,100) < threeStar)
        {
            enemyHealth = maxHealth + 50;
            speed += 10;
            distanceToMeat -=3;
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }
        else if(Random.Range(0, 100) < twoStar)
        {
            enemyHealth = maxHealth + 25;
            speed += 5;
            distanceToMeat -= 2;
            stars[1].SetActive(true);
        }

    }

    void Update()
    {
        if (meat != null)
        {
            //if ((transform.position - meat.transform.position).magnitude < distanceToMeat)
                transform.position = Vector2.MoveTowards(transform.position, meat.transform.position, speed * Time.deltaTime);
        }
        else
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        var hit = Physics2D.OverlapCircle(transform.position, distanceToMeat, maetLayer);
        if (hit != null)
            meat = hit.gameObject;
        
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
