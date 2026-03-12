using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScript : PickupBase, IInteractable
{

    public void Interacted()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public override void PickupEffect()
    {
        base.PickupEffect();
        SceneManager.LoadScene("MainMenu");
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
