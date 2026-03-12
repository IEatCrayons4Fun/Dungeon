using UnityEngine;

public class Trap : MonoBehaviour
{
    public float damageAmount;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<HealthManager>().TakeDamage(damageAmount);
            Debug.Log("Player hit a trap! Damage taken: " + damageAmount);
        }
    }
}
