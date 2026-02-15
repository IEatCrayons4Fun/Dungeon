using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Dungeon");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame(){
        SceneManager.LoadScene("MainMenu");
    }
}
