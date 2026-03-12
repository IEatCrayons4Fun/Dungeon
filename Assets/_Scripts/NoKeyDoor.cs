using UnityEngine;

public class NoKeyDoor : MonoBehaviour, IInteractable
{

    [SerializeField] private Animator doorAnimator;


    public void Interacted()
    {
        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger("Open");
        }
        
    }

    void NoKeyDoorOpen(){
        gameObject.SetActive(false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
