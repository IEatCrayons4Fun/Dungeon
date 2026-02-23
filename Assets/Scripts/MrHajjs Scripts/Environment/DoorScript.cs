using UnityEngine;

public class DoorScript : MonoBehaviour, IInteractable
{

    public void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            if (!this.gameObject.activeSelf)
            {
                this.gameObject.SetActive(true);
            }
        }
    }
    public void Interacted()
    {
        Unlock();
    }
    public void Unlock(){

        this.gameObject.SetActive(false);
    }
}
