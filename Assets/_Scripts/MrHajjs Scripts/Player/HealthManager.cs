using UnityEngine;
using UnityEngine.SceneManagement;
public class HealthManager : MonoBehaviour
{
    public GameObject checkpoint;
    public int maxHealth = 100;
    [SerializeField] private float currentHealth;

    private CharacterController controller;
    
    private void Start(){
        currentHealth = maxHealth;
        controller = GetComponent<CharacterController>();
    }
    
    public void TakeDamage(float damage){
        Debug.Log("Taking damage: " + damage + " | Current health before: " + currentHealth);
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Current health after: " + currentHealth);
        
        if(currentHealth <= 0){
            Respawn();

        }
    }
    
    public void Heal(float healAmount){
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
    
    private void Respawn(){
        
        
        SceneManager.LoadScene("DeathScreen");
        
        
        
        Inventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        inventory.ClearInventory();
        ItemRespawnManager.instance.RespawnAllItems();
    }
}