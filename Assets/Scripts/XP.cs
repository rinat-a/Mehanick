using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP : MonoBehaviour
{
    int xpCount = 0;
    [SerializeField] int[] expTable;
    [SerializeField] int currentLevel = 0;
    public int skillPoints = 0;
    public static XP S;
    public Action levelUp;
    private void Awake()
    {
        if (S == null) S = this;
        else Destroy(gameObject);
    }
    public void UpXP(int value)
    {
        xpCount += value;
        if(xpCount > expTable[currentLevel + 1] && currentLevel < expTable.Length)
        {
            currentLevel++;
            skillPoints++;
            levelUp?.Invoke();
        }
    }
}
