using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScr : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Joystick joystick;
    [SerializeField] Transform ShotPoint;

    #region BufsPeremen
    [SerializeField] float SpeedBuff = 1;
    [SerializeField] float upReloadTime = 1.0f;
    #endregion

    [SerializeField] float startTimeBtwShoot;
    [SerializeField] float offset;
    [SerializeField] int bulletCount = 10;
    [SerializeField] Slider slider;
    [SerializeField] float reloadTime = 2;

    [SerializeField] GameObject particle;

    int bulets;
    bool isReload = false;

    public float timeBtwShots = 5f;
    private float rotZ;
    //private PlayerScr player;
    public static PlayerScr P;

    public bool isShoot = false;


    private void Awake()
    {
        if (P == null) P = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        timeBtwShots = startTimeBtwShoot;
        bulets = bulletCount;
        slider.maxValue = bulletCount;
        slider.value = bulets;
        StartCoroutine(Shoot());
        Animator anim;
        anim = GetComponent<Animator>();
    }

  
    private void Update()
    {
        if(Mathf.Abs(joystick.Horizontal) > 0.3f || Mathf.Abs(joystick.Vertical) > 0.3f)
            rotZ = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (joystick.Direction != Vector2.zero && Time.timeScale != 0)
            if (!isShoot)
                isShoot = true;
        if(joystick.Direction == Vector2.zero)
            isShoot = false;
    }
    public void DeltaWhat(string name, float value)
    {
        switch (name)
        {
            case "speed":
                timeBtwShots = timeBtwShots - value;
                break;
        }
    }
    IEnumerator Shoot()
    {
        while (true)
        {
            if (isShoot)
            {
                if (bulets > 0 && !isReload) 
                {
                    Instantiate(bullet, ShotPoint.position, transform.rotation);
                    var part = Instantiate(particle, ShotPoint.position, transform.rotation);
                    AudioManager.S.Play("shoot");
                    Destroy(part, 0.2f);
                    slider.value = bulets;
                    bulets--;
                }
                    else if (!isReload)
                    {
                        isReload = true;
                        StartCoroutine(Reload());
                    }
                yield return new WaitForSeconds(timeBtwShots);
            }
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator Reload()
    {
        slider.fillRect.GetComponent<Image>().color = Color.red;
        while(bulets < bulletCount)
        {
            bulets++;
            slider.value = bulets;
            yield return new WaitForSeconds(reloadTime/bulletCount);
        }
        AudioManager.S.Play("reload");
        slider.fillRect.GetComponent<Image>().color = Color.white;
        isReload = false;
    }
    #region Bufs
    public void upSpeedBuff()
    {
        timeBtwShots -= SpeedBuff;
    }
    public void upReload()
    {
        reloadTime -= upReloadTime;
    }
    #endregion
}
