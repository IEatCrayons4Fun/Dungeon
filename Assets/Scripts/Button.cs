using UnityEngine;

public class Button : MonoBehaviour, IInteractable
{
    public void Interacted(){
        Debug.Log("Button Pressed");
    }
}
