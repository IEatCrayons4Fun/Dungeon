using UnityEngine;

public class Button : MonoBehaviour, IInteractable
{

    [SerializeField] private Animator doorAnimator;
    public void Interacted(){
        Debug.Log("Button Pressed");
        doorAnimator.SetTrigger("Open");

    }
}
