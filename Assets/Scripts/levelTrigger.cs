using UnityEngine;

public class levelTrigger : MonoBehaviour
{
    public GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider c)
    {
       if (c.tag == "Player")
        {
            gameManager.LoadLevel("Level_2");
        }
    }

}
