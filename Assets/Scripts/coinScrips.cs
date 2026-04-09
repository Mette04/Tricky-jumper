using UnityEngine;

public class coinScrips : MonoBehaviour
{
    public playerController player;
    public int rotateSpeed = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<playerController>();
            player.AddCoin();
            Debug.Log("Coins: " + player.coins);
            this.gameObject.SetActive(false);
        }
       
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward, rotateSpeed);
    }
}
