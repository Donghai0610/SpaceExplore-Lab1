using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projecttile : MonoBehaviour
{
    public float bulletSpeed;
    private Rigidbody2D rb;
    public GameObject explosionEffect;
    private void Awake()
    {
        Destroy(gameObject, 2f);
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if ( collision.gameObject.tag == "Enemy")
        {
            AudioManagement.instance.PlaySfx(0);
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
