using UnityEngine;

public class groundCheck : MonoBehaviour
{

    public bool isTouchingGround;

    private void OnTriggerEnter(Collider collider)
    {
        if (!(collider.tag == "Player"))
        {
            Debug.Log("Jeg ramte jorden");
            isTouchingGround = true;
        }
    }
}
