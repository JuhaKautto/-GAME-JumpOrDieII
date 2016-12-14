using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SurvivalCube : MonoBehaviour
{
    public Transform followCube;
    public Rigidbody cubeBody;
    public Rigidbody playerBall;
    private GameObject cameraMain;
    public MonoBehaviour smoothFollow;
    public Collider cubeColl;
    public AudioSource sound;
    //public AudioClip endJingle;
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
    string scoreList;
    public static bool onFinishArea;
    public static bool onExit;
    float turnMultiplier;
    float exitTimer;
    // Use this for initialization
    void Start()
    {
        followCube = GetComponent<Transform>();
        PlayerBall playerBall = GetComponent<PlayerBall>();
        cubeBody = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
        cubeColl = GetComponent<Collider>();
        sound.Play();
        cubeBody.velocity = new Vector3(cubeBody.velocity.x, -30f, 34f);
        width = Screen.width;
        height = Screen.height;
        scaler = width / 1366f;
        score = 0;
        fallTimer = 0;
        exitTimer = 0;
        turnMultiplier = 1;
        onFinishArea = false;
        onExit = false;
        cameraMain = GameObject.Find("MainCamera");
        //cubeColl.material = 
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
    void OnTriggerEnter(Collider c)
    {
        //what happens when you hit finish area
        if (c.gameObject.tag == "FinishTrigger")
        {
            //print("OnFinishArea");
            onFinishArea = !onFinishArea;
        }
        if (c.gameObject.tag == "Finish")
        {
            //print("Exiting");
            smoothFollow.enabled = false;
            onExit = true;
            onFinishArea = false;
            finalScore = score;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!onFinishArea)
        {
            turnMultiplier = 1;
            //print(speed);
        }
        else if (onFinishArea)
        {
            turnMultiplier = 1.6f;
            //print(onExit);
        }
        if (!onExit & cubeBody.velocity.y <= -70f & fallTimer >= 4f | SurvivalCollector.health == 0)
        {
            //print("Exiting");
            finalScore = score;
            smoothFollow.enabled = false;
            onExit = true;
            onFinishArea = false;
        }
        Rect jump = new Rect(width - 250 * scaler, height / 2 - 100 * scaler, 190 * scaler, 200 * scaler);
        Rect exit = new Rect(0, 0, 100 * scaler, 100 * scaler);
        if (!onExit)
        {
            score = score + Mathf.FloorToInt(transform.InverseTransformDirection(cubeBody.velocity).z / 5);
        }
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
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //playerBall.velocity = new Vector3(-12f, playerBall.velocity.y, playerBall.velocity.z);
                cubeBody.velocity -= transform.right * 0.4f;
                transform.RotateAround(transform.position, transform.up, Time.deltaTime * (-130f * turnMultiplier));
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //playerBall.velocity = new Vector3(-12f, playerBall.velocity.y, playerBall.velocity.z);
                cubeBody.velocity += transform.right * 0.4f;
                transform.RotateAround(transform.position, transform.up, Time.deltaTime * (130f * turnMultiplier));
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                cubeBody.velocity = new Vector3(cubeBody.velocity.x, cubeBody.velocity.y + 11f, cubeBody.velocity.z);
            }
            if (Input.touchCount > 0)
            {
                if (jump.Contains(Input.touches[0].position))
                {
                    cubeBody.velocity = new Vector3(cubeBody.velocity.x, cubeBody.velocity.y + 5f, cubeBody.velocity.z);
                }
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (Input.touchCount > 0)
        {
            if (exit.Contains(Input.touches[0].position))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
        if (Input.touchCount > 0 & onExit | Input.GetKey(KeyCode.Return) & onExit)
        {
            int index = 0;
                    while (true)
                    {
                        //print ("Saving Score...");
                        if (MainMenu.survivalScores[index].scoreNum < finalScore)
                        {
                            for (int i = 19; i > index; i--)
                            {
                                //print("Going Through HighScores...");
                                MainMenu.survivalScores[i] = MainMenu.survivalScores[i - 1];
                            }
                            //print("Saving Score...");
                            MainMenu.survivalScores[index] = new Score(finalScore, MainMenu.playerStats[0].name);
                            break;
                        }

                        index++;

                        if (index == 20)
                            break;
                    }
                    for (int i = 0; i < MainMenu.survivalScores.Length; i++)
                    {
                        PlayerPrefs.SetInt("survivalScore" + i, MainMenu.survivalScores[i].scoreNum);
                        PlayerPrefs.SetString("survivalName" + i, MainMenu.survivalScores[i].name);
                        //print("Saving HighScores...");
                    }
            /*if (Input.touchCount > 0 & onExit | Input.GetKey(KeyCode.Return) & onExit)
            {
                exitTimer++;
                if (Input.touchCount > 0 & onExit & exitTimer >= 60 | Input.GetKey(KeyCode.Return) & onExit & exitTimer >= 60)
                {*/
            PlayerPrefs.SetInt("totalStars", Mathf.FloorToInt(SurvivalCollector.totalStars));
            PlayerPrefs.SetString("playerName", MainMenu.playerStats[0].name);
            PlayerPrefs.Save();
            SceneManager.LoadScene("MainMenu");
            // }
            // }
        }
        if (!isGrounded & fallTimer <= 5f)
        {
            fallTimer += Time.deltaTime;
        }
        sentScore = score;
        speed = transform.InverseTransformDirection(cubeBody.velocity).z;
    }
}
