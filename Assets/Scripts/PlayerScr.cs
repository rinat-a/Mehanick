using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScr : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Joystick joystick;
    [SerializeField] Transform ShotPoint;
    [SerializeField] float SpeedBuff = 1;

    [SerializeField] float startTimeBtwShoot;
    [SerializeField] float offset;

    public float timeBtwShots = 5f;
    private float rotZ;
    //private PlayerScr player;
    public static PlayerScr P;

    bool isShoot = false;

    private void Awake()
    {
        if (P == null) P = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        timeBtwShots = startTimeBtwShoot;
    }

  
    private void Update()
    {
        if(Mathf.Abs(joystick.Horizontal) > 0.3f || Mathf.Abs(joystick.Vertical) > 0.3f)
            rotZ = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if ((joystick.Horizontal != 0 || joystick.Vertical != 0))
        {
            if (!isShoot)
            {
                StartCoroutine(Shoot());
                isShoot = true;
            }
        }
        else
        {
                        StopAllCoroutines(); 
        isShoot = false;
        }
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
            yield return new WaitForSeconds(timeBtwShots);
            Instantiate(bullet, ShotPoint.position, transform.rotation);
        }
    }
    #region Bufs
    public void upSpeedBuff()
    {
        timeBtwShots -= SpeedBuff;
    }
    #endregion
}
