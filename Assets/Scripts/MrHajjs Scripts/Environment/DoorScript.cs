using UnityEngine;

public class DoorScript : MonoBehaviour, IInteractable
{
    public string requiredKey;
    private Inventory inventory;
    
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }


    public void Interacted()
    {   
        Debug.Log("Interacted with door. Checking for key: " + requiredKey);
        if(inventory.HasItem(requiredKey))
        {
            inventory.RemoveItem(requiredKey);
            DoorOpen();
        }
        else
        {
            Debug.Log("You need the " + requiredKey + " to open this door!");
        }
    }

    public void LeverInteracted()
    {
        // Add code to open the door here
        DoorOpen();
    }

    void DoorOpen(){
        gameObject.SetActive(false);
        Debug.Log("Door has been opened!");
    }
}
