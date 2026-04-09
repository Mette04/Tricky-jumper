using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public void LoadLevel(string levelName)
    {
        PlayerPrefs.SetInt("deathcount", 0);
        SceneManager.LoadScene(levelName);
    }

    public void LoadNextLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel + 1);
    }
}
