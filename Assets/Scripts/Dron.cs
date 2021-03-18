using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dron : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    [SerializeField] float speed = 5;
    [SerializeField] Camera cam;
    Vector2 camBorder;

    void Start()
    {
        camBorder = cam.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Update()
    {
        Vector2 newPos = transform.position + new Vector3(joystick.Horizontal * speed * Time.deltaTime, joystick.Vertical * speed * Time.deltaTime, 0);
        newPos.x = Mathf.Clamp(newPos.x, -camBorder.x, camBorder.x);
        newPos.y = Mathf.Clamp(newPos.y, -camBorder.y, camBorder.y);
        transform.position = newPos;
    }
}
