using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DemoCube : MonoBehaviour {
    public Transform followCube;
    public Rigidbody cubeBody;
    public Rigidbody playerBall;
    private GameObject cameraMain;
    public MonoBehaviour smoothFollow;
    public AudioSource sound;
    public AudioClip softLanding;
    public static float sentScore;
    public static int finalScore;
    public static float speed;
    public static int score;
    float width;
    float height;
    float scaler;
    bool isGrounded;
    float fallTimer;
    float demoTimer;
    string scoreList;
    public static bool onFinishArea;
    public static bool onExit;
    float turnMultiplier;
    float exitTimer;
    bool turnLeft;
    float turnCounter;
    // Use this for initialization
    void Start()
    {
        followCube = GetComponent<Transform>();
        PlayerBall playerBall = GetComponent<PlayerBall>();
        cubeBody = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
        sound.Play();
        cubeBody.velocity = new Vector3(cubeBody.velocity.x, -40f, 46f);
        width = Screen.width;
        height = Screen.height;
        scaler = width / 1366f;
        score = 0;
        fallTimer = 0;
        demoTimer = 0;
        exitTimer = 0;
        turnCounter = 0f;
        turnMultiplier = 1;
        onExit = false;
        turnLeft = true;
        cameraMain = GameObject.Find("MainCamera");
        //smoothFollow = cameraMain.GetComponent("SmoothFollow") as MonoBehaviour;
        //smoothFollow.enabled = true;
    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Untagged")
        {
            if (fallTimer > 0.7f)
            {
                sound.PlayOneShot(softLanding, 9.0f);
            }
            else if (fallTimer > 0.3f)
            {
                sound.PlayOneShot(softLanding, 8.0f);
            }
        }
    }
    void OnCollisionStay(Collision coll)
    {
        if (coll.gameObject.tag == "Untagged")
        {
            isGrounded = true;
            fallTimer = 0;
        }
    }
    void OnCollisionExit(Collision coll)
    {
        if (coll.gameObject.tag == "Untagged")
        {
            isGrounded = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        //print(turnLeft);
        if (!onFinishArea & cubeBody.velocity.y > -8.0f)
        {
            cubeBody.velocity = new Vector3(cubeBody.velocity.x, -8.0f, cubeBody.velocity.z);
        }
        //followCube.position = new Vector3(playerBall.position.x, playerBall.position.y, playerBall.position.z);
        if (isGrounded)
        {
            if (-Input.acceleration.x > 0.1f)
            {
                cubeBody.velocity -= transform.right * 0.25f;
                transform.RotateAround(transform.position, transform.up, Time.deltaTime * -48.75f);
                if (-Input.acceleration.x > 0.2f)
                {
                    cubeBody.velocity -= transform.right * 0.3f;
                    transform.RotateAround(transform.position, transform.up, Time.deltaTime * -62.5f);
                    if (-Input.acceleration.x > 0.3f)
                    {
                        cubeBody.velocity -= transform.right * 0.35f;
                        transform.RotateAround(transform.position, transform.up, Time.deltaTime * -76.25f);
                        if (-Input.acceleration.x > 0.4f)
                        {
                            cubeBody.velocity -= transform.right * 0.4f;
                            transform.RotateAround(transform.position, transform.up, Time.deltaTime * -90f);
                        }
                    }
                }
            }
            if (-Input.acceleration.x < -0.1f)
            {
                cubeBody.velocity += transform.right * 0.25f;
                transform.RotateAround(transform.position, transform.up, Time.deltaTime * 48.75f);
                if (-Input.acceleration.x < -0.2f)
                {
                    cubeBody.velocity += transform.right * 0.3f;
                    transform.RotateAround(transform.position, transform.up, Time.deltaTime * 62.5f);
                    if (-Input.acceleration.x < -0.3f)
                    {
                        cubeBody.velocity += transform.right * 0.35f;
                        transform.RotateAround(transform.position, transform.up, Time.deltaTime * 76.25f);
                        if (-Input.acceleration.x < -0.4f)
                        {
                            cubeBody.velocity += transform.right * 0.4f;
                            transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
                        }
                    }
                }
            }
            if (turnLeft & turnCounter >= 0.4f)
            {
                //playerBall.velocity = new Vector3(-12f, playerBall.velocity.y, playerBall.velocity.z);
                cubeBody.velocity -= transform.right * 0.2f;
                //transform.RotateAround(transform.position, transform.up, Time.deltaTime * (-30f * turnMultiplier));
                if (turnCounter >= 1.4f)
                {
                    turnLeft = false;
                    turnCounter = 0f;
                }
            }
            else if (!turnLeft & turnCounter >= 0.4f)
            {
                //playerBall.velocity = new Vector3(-12f, playerBall.velocity.y, playerBall.velocity.z);
                cubeBody.velocity += transform.right * 0.2f;
                //transform.RotateAround(transform.position, transform.up, Time.deltaTime * (30f * turnMultiplier));
                if (turnCounter >= 1.4f)
                {
                    turnLeft = true;
                    turnCounter = 0f;
                }
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                cubeBody.velocity = new Vector3(cubeBody.velocity.x, cubeBody.velocity.y + 11f, cubeBody.velocity.z);
            }
        }
        if (Input.GetKey(KeyCode.Return) | Input.touchCount > 0 | demoTimer >= 45)
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (!isGrounded & fallTimer <= 5f)
        {
            fallTimer += Time.deltaTime;
        }
        demoTimer += Time.deltaTime;
        turnCounter += Time.deltaTime;
    }
}
