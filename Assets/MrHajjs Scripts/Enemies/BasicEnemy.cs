using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicEnemy : BaseEnemy
{
    [SerializeField] float damage;
    [SerializeField] float attackRate;
    [SerializeField] float maxHealth;
    private float currentHealth;

    private bool attackCooldown;

    void Start(){
        maxHealth = currentHealth;
    }

    public void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Player") && !attackCooldown){
            StartCoroutine(AttackCooldown());
            other.gameObject.GetComponent<HealthManager>().TakeDamage(damage);
            Debug.Log("Dealt " + damage + " damage to player");
        }
    }

    private IEnumerator AttackCooldown(){
        attackCooldown = true;
        Debug.Log("Attack Cooldown Started");
        yield return new WaitForSeconds(attackRate);
        attackCooldown = false;
        Debug.Log("Can attack again");
    }

    public void TakeDamage(float damageAmount){
        currentHealth -= damageAmount;
        Debug.Log("Enemy took " + damageAmount + " damage");
        if(currentHealth <= 0){
            Die();
        }
    }
    
    private void Die(){
        Debug.Log("Enemy Died");
        Destroy(this.gameObject);
    }
}
