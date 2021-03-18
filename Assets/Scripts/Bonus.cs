using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] protected float bonusBuff = 2.0f;
    protected void ToPlayer(string name ,float value)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScr>().DeltaWhat(name, value);
        Destroy(gameObject);
    }    
}
