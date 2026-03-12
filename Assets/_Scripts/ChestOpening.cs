using UnityEngine;

public class ChestOpening : MonoBehaviour, IInteractable
{

    [SerializeField] private Animator chestAnimator;


    public void Interacted()
    {
        chestAnimator.SetTrigger("Open");
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
