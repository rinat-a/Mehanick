using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDamage : MonoBehaviour
{
    [SerializeField] Text text;
    public void Init(string value, Color color)
    {
        text.color = color;
        text.text = value;
    }
}
