using UnityEngine;

public class Roll : MonoBehaviour
{
    Rigidbody rb;

    public int fallAccelleration = 10;
    public bool updateHeleTiden = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = Vector3.down * fallAccelleration;
    }

    void FixedUpdate()
    {
        if (updateHeleTiden)
        {
            Physics.gravity = Vector3.down * fallAccelleration;
        }

    }
}