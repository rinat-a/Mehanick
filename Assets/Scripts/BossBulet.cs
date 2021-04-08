using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulet : MonoBehaviour
{
    [SerializeField] float speed = 3.1f;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Vector2.zero, speed * Time.deltaTime);
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
        if (collision.gameObject.tag == "Dron")
        {
            collision.GetComponent<Dron>().Charge();
            Destroy(gameObject);
        }
    }

}
