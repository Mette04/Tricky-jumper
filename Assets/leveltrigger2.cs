using UnityEngine;

public class leveltrigger2 : MonoBehaviour
{
    public GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
    }

  
    void OnTriggerEnter(Collider c)
    {
      if (c.tag == "Player")
        {
            gameManager.LoadLevel("WinScreen");
        }
    }
}
