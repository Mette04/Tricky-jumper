using UnityEngine;

public class camFollow : MonoBehaviour
{
    public Transform playerPos;
    public int camOffsetz = 10;
    public float camOffsety = 10;
    public float smoother = 1f;
    Transform camT;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPos = GameObject.FindWithTag("Player").transform;
        camT = transform;
        smoother = 0.05f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 tilPos = new Vector3(
            //playerPos.position.x - camOffsetX,
            playerPos.position.x,
            playerPos.position.y + camOffsety,
 
            playerPos.position.z - camOffsetz
        );

        Vector3 velocity = Vector3.zero;
        Vector3 nyPos = Vector3.SmoothDamp(camT.position, tilPos, ref velocity, smoother);
        camT.position = nyPos;
    }
}
