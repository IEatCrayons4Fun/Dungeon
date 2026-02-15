using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            Debug.Log("Checkpoint reached!");
            other.GetComponent<HealthManager>().checkpoint = this.gameObject;
        }
    }
}

