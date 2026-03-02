using UnityEngine;

public class KeyScript : PickupBase
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
    
}
