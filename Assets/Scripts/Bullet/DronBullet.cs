using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronBullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int deltaDamage = 10;
    [SerializeField] int damage = 35;
    [SerializeField] TextDamage textPref;
    Transform canvasRoot;
    private void Start()
    {
        canvasRoot = GameObject.FindGameObjectWithTag("Canvas").transform;
    }
    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            var dmg = Random.Range(damage - deltaDamage, damage + deltaDamage);
            collision.gameObject.GetComponent<Enemy>().Damage(dmg);
            var pref = Instantiate(textPref, transform.position, Quaternion.identity, canvasRoot);
            pref.Init(dmg.ToString(), Color.gray);
            Destroy(gameObject);

        }
    }
}
