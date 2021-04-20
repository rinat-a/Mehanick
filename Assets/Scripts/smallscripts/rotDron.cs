using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotDron : MonoBehaviour
{
    [SerializeField] int speedRot = 5;
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, speedRot * Time.fixedDeltaTime));
    }
}
