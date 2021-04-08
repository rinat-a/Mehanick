using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class BossScr : MonoBehaviour
{
    [SerializeField] GameObject portal;
    [SerializeField] GameObject bullet;
    [SerializeField] float speed;
    int enemyHealth = 100;
    [SerializeField] int maxHealth = 100;
    [SerializeField] int damage = 20;
    [SerializeField] int missProcent = 5;
    Transform player;

    [SerializeField] TextDamage textPref;
    Vector2 min, max;
    [SerializeField] float bossMoveTime = 2.0f;
    [SerializeField] float radiusFromPlayer = 2.0f;
    [SerializeField] float fireTime = 0.1f;
    bool isOnScene = false;

    [SerializeField] Slider slider;

    public Action OnBossDef;
    void Start()
    {
        enemyHealth = maxHealth;
        min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        max = Camera.main.ViewportToWorldPoint(Vector2.one);
        player = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(BossMove());
        StartCoroutine(Shoot());

        slider.value = slider.maxValue = maxHealth;
    }


    void Update()
    {
   
    }

    public void Damage(int _damage)
    {
            enemyHealth -= _damage;
            slider.value = enemyHealth;
        if (enemyHealth <= 0)
        {
            OnBossDef?.Invoke();
            Destroy(gameObject);
        }
    }
    IEnumerator BossMove()
    {
        while (true)
        {
            Vector2 newPos;
            do
            {
                yield return new WaitForEndOfFrame();
                newPos = new Vector2(UnityEngine.Random.Range(min.x, max.x), UnityEngine.Random.Range(min.y, max.y));
            } while ((newPos - (Vector2)player.position).magnitude < radiusFromPlayer);
            Instantiate(portal, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            isOnScene = false;
            transform.position = new Vector2(100,100);
            yield return new WaitForSeconds(bossMoveTime);
            Instantiate(portal, newPos, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            transform.position = newPos;
            isOnScene = true;
            yield return new WaitForSeconds(bossMoveTime);
        }
    }
    IEnumerator Shoot()
    {
        while (true)
        {
            if (isOnScene)
            {
                Instantiate(bullet, transform.position, transform.rotation);
                yield return new WaitForSeconds(fireTime);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
