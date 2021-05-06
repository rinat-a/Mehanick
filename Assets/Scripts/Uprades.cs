using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uprades : MonoBehaviour
{
    [SerializeField] UpgradeBase[] upgrade;
    void Start()
    {
        XP.S.levelUp += UpdateUpgrade;
    }

    void Update()
    {
        
    }
    void UpdateUpgrade()
    {
        foreach(var u in upgrade)
        {
            if(XP.S.skillPoints >= u.SP)
            {

            }
        }
    }
}
