using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    public InputAction action;

    Vector3 moveDirection;

   public Rigidbody playerBody;

    public int hastighed = 2;
    public int force = 2;
    public int jumpForce = 50;

    public int jumps = 3;

    public int jumpsLeft;

    public int coins = 0;

    AudioSource audioSource;

    public AudioClip coinsound;

    public AudioClip jumpSound;

    GameManager gm;

    GameObject ct;
    
    TextMeshProUGUI coinText;
    public bool useAddForce = false;
    public float maxSpeed = 30f;
    public int deaths = 0;


    public void AddCoin()
    {
        coins++;
        coinText.text = "Coins: " + coins;
        audioSource.clip = coinsound;
        audioSource.Play();

        if (coins >= 10)
        {
            gm.LoadLevel("Level_3");
        }
    }
    private void Awake()
    {
        jumpSound = Resources.Load<AudioClip>("jumpSound");
    }
    void OnEnable()
    {
        action.Enable();
    }

    void OnDisable()
    {
        action.Disable();
    }


    void Start()
    {
        deaths = PlayerPrefs.GetInt("deathcount", 0);
        audioSource = this.GetComponent<AudioSource>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        ct = GameObject.Find("CT");
        coinText = ct.GetComponent<TextMeshProUGUI>();
        coinText.text = "Coins: " + coins;
    }
    public void Jump()
    {

        bool isGrounded = Physics.Raycast(new Ray(transform.position, UnityEngine.Vector3.down), 1);


        if (isGrounded)
        {
            jumpsLeft = jumps;
        }

        if (jumpsLeft > 0)
        {
            Debug.Log("Jumping");
            //playerBody.AddForce(0, jumpForce, 0);
            playerBody.linearVelocity = new UnityEngine.Vector3(playerBody.linearVelocity.x, jumpForce, playerBody.linearVelocity.z);
            jumpsLeft--;
            audioSource.clip = jumpSound;
            audioSource.Play();
        }

        else
        {
            Debug.Log("not touching ground");
        }
        //Physics.gravity = new Vector3(0, 0, 0);
    }

    private void FixedUpdate()
    {

        // when space is pressed jump
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Jump();
        //}
        moveDirection = action.ReadValue<UnityEngine.Vector2>();
        // playerBody.AddForce(new UnityEngine.Vector3(moveDirection.y * hastighed, 0, moveDirection.x * -hastighed));

        if (useAddForce == true)
        {
            playerBody.AddForce(new UnityEngine.Vector3(moveDirection.x * force, playerBody.linearVelocity.y, moveDirection.y * force)); //fjern minuset
        }
        else
        {
            playerBody.linearVelocity = new UnityEngine.Vector3(moveDirection.x * hastighed, playerBody.linearVelocity.y, moveDirection.y * hastighed);
        }
        Debug.Log("Speed: " + playerBody.linearVelocity.magnitude);
        // Clamp the velocity to a maximum of 300
        if (playerBody.linearVelocity.magnitude > maxSpeed)
        {
            playerBody.linearVelocity = playerBody.linearVelocity.normalized * maxSpeed;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        bool isGrounded = Physics.Raycast(new Ray(transform.position, UnityEngine.Vector3.down), 1);


        if (isGrounded)
        {
            Debug.Log("Refreshing jumps");
            jumpsLeft = jumps;
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
}

