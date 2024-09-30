using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody2D rb;
    private float direction;
    private float directionX;
    public float shootDelay = 5f;
    public int bonusHealth = 1;
    public GameObject shield;
    public bool haveShield = false;
    public int shielDuration = 5;
    // Start is called before the first frame update
    public static Player instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shield.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        direction = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, direction * moveSpeed);
        directionX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);

        if (haveShield)
        {
            shield.transform.position = this.transform.position;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bonus")
        {
            Destroy(collision.gameObject);
            StartCoroutine(TimeBetween());
        }
        else if (collision.tag == "BonusHealth")
        {
            Destroy(collision.gameObject);
            PlayerHealth.instance.PlusHealth(bonusHealth);
        }
        else if ( collision.tag == "BonusShield")
        {
            Destroy(collision.gameObject);
           ActiveShield();
        }
    }

    private void ActiveShield()
    {
        shield.SetActive(true);
        haveShield = true;
        StartCoroutine(ShieldDurationCount());
    }
    IEnumerator ShieldDurationCount()
    {
        yield return new WaitForSeconds(shielDuration);
        shield.SetActive(false);
        haveShield = false;
    }

    IEnumerator TimeBetween()
    {
        Shooting.instance.timeBetweenShoot -= 0.5f;
        yield return new WaitForSeconds(shootDelay);
        Shooting.instance.timeBetweenShoot += 0.5f;
    }
}
