using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    private void Awake()
    {
        Destroy(gameObject,2f);
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
      transform.Translate(Vector2.left * speed * Time.deltaTime);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "SpaceShip")
        {
            AudioManagement.instance.PlaySfx(2);
            PlayerHealth.instance.DealDamage();
            Destroy(gameObject);
        }
    }
}
