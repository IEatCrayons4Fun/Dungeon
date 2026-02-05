using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public float damage;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided with Enemy");
            BasicEnemy enemy = collision.gameObject.GetComponent<BasicEnemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
