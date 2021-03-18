using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baricad : MonoBehaviour
{
    [SerializeField] int Health = 3;
    public void IsDamage()
    {
        Health--;
        if (Health <= 0)
            Destroy(gameObject);
    }
}
