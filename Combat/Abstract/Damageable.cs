using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    [SerializeField]
    float startHealth;

    float maxHealth = 100;
    [SerializeField]
    float currentHealth;
    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = startHealth;
    }
    void OnEnable()
    {
       
        currentHealth = startHealth;
    }
    private void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public virtual void IncrementHealth(float amount)
    {
        currentHealth += amount;
    }
    public virtual void DecrementHealth(float amount)
    {
        currentHealth -= amount;

    }
    public virtual void Die()
    {
        Destroy(this.gameObject);
    }
}
