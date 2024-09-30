using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePos;
    public GameObject bullet;
    public float timeBetweenShoot;
    private bool canShoot = true;
    public static Shooting instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(!PauseMenu.instance.isPaused)
        {
            if (canShoot)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Shoot();
                    AudioManagement.instance.PlaySfx(3);
                }
            }
        }
        else
        {
            return;
        }

    }

    public void Shoot()
    {
        Instantiate(bullet,firePos.position,firePos.rotation);
        StartCoroutine(ShootDelay());
    }
    IEnumerator ShootDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(timeBetweenShoot);
        canShoot=true;
    }
}
