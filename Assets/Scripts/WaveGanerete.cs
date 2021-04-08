using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveGanerete : MonoBehaviour
{

    [SerializeField] int[] enemyCount;

    [SerializeField] float timeToBorn = 0.1f;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject enemyHard;
    [SerializeField] BossScr bossPref;
    [SerializeField] float Radius = 5f;
    [SerializeField] TextMeshProUGUI textWave;

    [SerializeField] float timeToNext = 3f;
    [SerializeField] Transform enemyRoot;
    [SerializeField] GameObject ShoopPanel;
    bool isBossLife = true;

    int currentEnemy = 0;
    int currentWave = 1;
    [SerializeField] float hardProcent = 2.0f;

    void Start()
    {
        StartCoroutine(Wave());
        CloseMenu();
    }
    IEnumerator Wave()
    {
        if (currentWave != enemyCount.Length)
            while (currentEnemy < enemyCount[currentWave - 1])
            {
                yield return new WaitForSeconds(timeToBorn - currentWave / hardProcent);
                if ((Random.Range(1, 4) == 2))
                    Instantiate(enemyHard, randOnCircle(Radius), transform.rotation, enemyRoot);
                else
                    Instantiate(enemy, randOnCircle(Radius), transform.rotation, enemyRoot);
                currentEnemy++;
            }
        else
        {
            var boss = Instantiate(bossPref, randOnCircle(Radius), transform.rotation, enemyRoot);
            boss.OnBossDef += ()=> isBossLife = false;
            while (isBossLife)
            {
                yield return new WaitForSeconds(timeToBorn * currentWave);
                if ((Random.Range(1, 4) == 2))
                    Instantiate(enemyHard, randOnCircle(Radius), transform.rotation, enemyRoot);
                else
                    Instantiate(enemy, randOnCircle(Radius), transform.rotation, enemyRoot);
            }
        }
        StartCoroutine(NextWave());
    }
    IEnumerator NextWave()
    {
        while (enemyRoot.childCount != 0)
        {
            Debug.Log(enemyRoot.childCount);
            yield return new WaitForEndOfFrame();
        }
        textWave.text = "Wave: " + (currentWave + 1);
        textWave.gameObject.SetActive(true);
        OpenMenu();
        yield return new WaitForSeconds(timeToNext);
        CloseMenu();
        textWave.gameObject.SetActive(false);

        currentEnemy = 0;
        if (currentWave < enemyCount.Length)
        {
            currentWave++;
            StartCoroutine(Wave());
        }
        else
        {

        }
    }
    Vector2 randOnCircle(float radius)
    {
        float randAng = Random.Range(0, Mathf.PI * 2);
        return new Vector2(Mathf.Cos(randAng) * radius, Mathf.Sin(randAng) * radius);
    }
    public void OpenMenu()
    {
        ShoopPanel.SetActive(true);
    }
    public void CloseMenu()
    {
        ShoopPanel.SetActive(false);
    }
}
