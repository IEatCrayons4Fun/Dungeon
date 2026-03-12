using UnityEngine;

public class KeyScript : PickupBase, IInteractable
{
    public string itemName;


    public override void PickupEffect()
    {
        Inventory inventory = player.GetComponent<Inventory>();
        if (inventory != null)
        {
            inventory.AddItem(itemName);
            base.PickupEffect();
        }
    }
    public void Interacted()
    {
        Inventory inventory = player.GetComponent<Inventory>();
        if (inventory != null)
        {
            inventory.AddItem(itemName);
            Destroy(this.gameObject);
        }
        
    }
    
}
