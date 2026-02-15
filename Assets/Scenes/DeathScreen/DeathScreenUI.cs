using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenUI : MonoBehaviour
{
    void Start(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void RestartGame(){
        SceneManager.LoadScene("Dungeon");
    }

    public void QuitToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }



}
