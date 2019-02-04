using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Restart()
    {
        PlayerController.score = 0;
        PlayerController.lives = 3;
        PlayerController.isGameOver = false;
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Resume()
    {
        this.GetComponent<PauseMenu>().Invoke("TogglePause", 0);
    }
}
