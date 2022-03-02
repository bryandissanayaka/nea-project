using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public void OnReturnToMenuPressed() {
        SceneManager.LoadScene(0); //index of start menu
        Time.timeScale = 1;
    }

    public void OnRestartPressed() {
        Time.timeScale = 1;
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }
}
