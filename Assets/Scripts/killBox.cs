using UnityEngine;
using UnityEngine.SceneManagement;

public class killBox : MonoBehaviour
{
    public Transform spawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int deathCount = PlayerPrefs.GetInt("deathcount", 0);
        deathCount++;
        PlayerPrefs.SetInt("deathcount", deathCount);
        SceneManager.LoadScene(currentLevel);
    }
}
