using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dron")
        {
            Destroy(gameObject);
            Shoop.S.moneyUp();
        }
    }
}
