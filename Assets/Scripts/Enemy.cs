using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePos;
    public float TimeBetweenShots;
    public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Shoot()
    {
        Instantiate(bulletPrefab,firePos.position,firePos.rotation);
    }
    IEnumerator ShootRoutine()
    {
        while (true)
        {
            Shoot();
            yield return new  WaitForSeconds(TimeBetweenShots);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "SpaceShip")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameOver.instance.GameOverNow();
            isDead = true;
        }
        

    }
}
