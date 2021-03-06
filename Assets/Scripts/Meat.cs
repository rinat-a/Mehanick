using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour
{
    [SerializeField] int Health = 50;
    [SerializeField] float timeDamage = 0.1f;
    List<Collider2D> enemyList = new List<Collider2D>();

    private void Start()
    {
        enemyList.Clear();
        StartCoroutine(Damage());
    }
    public void IsDamage()
    {
        Health--;
        if (Health <= 0)
            //transform.position = new Vector2(1000, 1000);
            Destroy(gameObject);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!enemyList.Contains(collision) && collision.CompareTag("Enemy"))
        {
            enemyList.Add(collision);
        }
    }
    IEnumerator Damage()
    {
        while (true)
        {
            Debug.Log(enemyList.Count);
            if(enemyList.Count > 0)
            {
                foreach (var e in enemyList)
                {
                    if(e != null)
                    {
                        IsDamage();
                    }
                }
            }
             yield return new WaitForSeconds(timeDamage);
        }
    }
}
