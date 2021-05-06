using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dron : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    [SerializeField] float speed = 5;
    [Space]
    [SerializeField] Camera cam;
    [SerializeField] int maxCharge = 5;
    [SerializeField] int damg = 20;
    [SerializeField] GameObject dronBulett;
    [SerializeField] GameObject meatPref;
    [SerializeField] int countBullet = 500;
    bool isSkill = true;
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
        if (joystick.Direction != Vector2.zero)
            //transform.right = Vector2.Lerp(transform.right, joystick.Direction, Time.deltaTime * 1);
            transform.right = Vector2.Lerp(transform.right, joystick.Direction, 1);
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
    public void Meat()
    {
        Instantiate(meatPref, transform.position,Quaternion.identity);
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(6);
        isSkill = true;
    }
    IEnumerator dronFire()
    {
        for (int i = 0; i < countBullet; i++)
        {
            var bullet = Instantiate(dronBulett, transform.position, Quaternion.identity);
            bullet.transform.right = transform.position - ((Vector3)Random.insideUnitCircle.normalized + transform.position);
            yield return new WaitForSeconds(0.05f);
        }
        StartCoroutine(Delay());
    }
    public void stCorutine()
    {
        if (isSkill)
        {
            StartCoroutine(dronFire());
            isSkill = false;
        }
    }
}
