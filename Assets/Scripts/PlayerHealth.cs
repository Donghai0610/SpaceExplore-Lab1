using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public bool shieldActive = false;
    public static PlayerHealth instance;
    public HealthBar healthBar;
    public SpriteRenderer spriteRenderer;
    public bool isGameOver = false;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DealDamage()
    {
        
        currentHealth--;
        StartCoroutine(BloodEffect());
        healthBar.setHealth(currentHealth);
        if( currentHealth <= 0)
        {
            Die();
        }
    }
    public void PlusHealth(int health)
    {
        currentHealth += health;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.setHealth(currentHealth);
    }
    
    void Die()
    {
        GameOver.instance.GameOverNow();
        isGameOver = true;
        

    }

    IEnumerator BloodEffect()
    {
        spriteRenderer.color = new Color(spriteRenderer.color.r,spriteRenderer.color.g,spriteRenderer.color.b,0.2f);
        yield return new WaitForSeconds(1);
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0f);
    }
}
