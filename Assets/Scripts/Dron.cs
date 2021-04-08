using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dron : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    [SerializeField] float speed = 5;
    [SerializeField] Camera cam;
    [SerializeField] int maxCharge = 5;
    [SerializeField] int damg = 20;
    int charge = 0;
    Vector2 camBorder;

    [SerializeField] Slider slider;

    void Start()
    {
        camBorder = cam.ViewportToWorldPoint(new Vector2(1, 1));
        slider.value = slider.maxValue = maxCharge;
        slider.value = 0;
    }

    void Update()
    {
        Vector2 newPos = transform.position + new Vector3(joystick.Horizontal * speed * Time.deltaTime, joystick.Vertical * speed * Time.deltaTime, 0);
        newPos.x = Mathf.Clamp(newPos.x, -camBorder.x, camBorder.x);
        newPos.y = Mathf.Clamp(newPos.y, -camBorder.y, camBorder.y);
        transform.position = newPos;
    }
    public void Charge()
    {
        if (charge != maxCharge)
        {
            charge++;
            slider.value = charge;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(charge == maxCharge && collision.gameObject.tag == "Boss")
        {
            collision.GetComponent<BossScr>().Damage(damg);
            charge = 0;
            slider.value = 0;
        }
    }
}
