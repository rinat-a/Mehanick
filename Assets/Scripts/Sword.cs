using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    bool isSkill = true;
    [SerializeField] float reloadTime = 2.0f; 
    Animator anim;
    [SerializeField] int deltaDamage = 10;
    [SerializeField] int damage = 35;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void SwordAttack()
    {
        if (isSkill)
        {
            anim.Play("sword");
            isSkill = false;
            Invoke("Reload", reloadTime);
        }
    }
    void Reload()
    {
        isSkill = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            var dmg = Random.Range(damage - deltaDamage, damage + deltaDamage);
            collision.gameObject.GetComponent<Enemy>().Damage(dmg);
        }
    }
}
