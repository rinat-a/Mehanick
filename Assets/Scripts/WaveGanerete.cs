using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGanerete : MonoBehaviour
{
    [SerializeField] float timeToBorn = 0.1f;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject enemyHard;
    [SerializeField] float Radius = 5f;
    void Start()
    {
        StartCoroutine(Wave());
    }
    IEnumerator Wave()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToBorn);
            if((Random.Range(1, 4)==2))
                Instantiate(enemyHard, randOnCircle(Radius), transform.rotation);
            else
                Instantiate(enemy, randOnCircle(Radius), transform.rotation);
        }
    }
    Vector2 randOnCircle(float radius)
    {
        float randAng = Random.Range(0, Mathf.PI * 2);
        return new Vector2(Mathf.Cos(randAng) * radius, Mathf.Sin(randAng) * radius);
    }

}
