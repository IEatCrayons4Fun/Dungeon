using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class InteractionController : MonoBehaviour
{
    InputAction interact;
    [SerializeField] float interactCooldown;
    [SerializeField] float interactRange;
    private bool canInteract = true;
    public GameObject cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interact = InputSystem.actions.FindAction("Interact");
    }

    // Update is called once per frame
    void Update()
    {
        if(interact.WasPressedThisFrame() && canInteract){
            Interact();
        }
    }

    private void Interact(){
        if(Physics.Raycast(cam.gameObject.transform.position, cam.gameObject.transform.forward, out RaycastHit hitData, interactRange)){
            Debug.DrawLine(cam.gameObject.transform.position, cam.gameObject.transform.forward * interactRange, Color.red, 2f);
            IInteractable interactable  = hitData.transform.gameObject.GetComponent<IInteractable>();
            if(interactable != null){
                interactable.Interacted();
                StartCoroutine(InteractDelay());
            }
        }
    }

    private IEnumerator InteractDelay(){
        canInteract = false;
        yield return new WaitForSeconds(interactCooldown);
        canInteract = true;
    }
}
