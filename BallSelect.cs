using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BallSelect : MonoBehaviour
{
    public Transform bg;
    public Texture backButton;
    public Texture yesButton;
    public Font arialRounded;
    public Texture leftButton;
    public Texture rightButton;
    public Color textColor = new Color(0.2F, 0.3F, 0.4F, 0.5F);
    public float bgMovingSpeed = 5;
    public AudioSource sound;
    public AudioClip silence;
    public static float endPosX;
    public static float endPosY;
    public static bool endGoesLeft;
    public static bool cameBack;
    public static float playbackTime;
    float realSpeed;
    float styleSize;
    float styleSize2;
    float styleSize3;
    float posX;
    float posY;
    float width;
    float height;
    float scaler;
    bool goesLeft;
    public static bool zeroToOne;
    public static bool oneToTwo;
    public static bool twoToOne;
    public static bool oneToZero;
    int selectedBall;
    int buttonBlocker;
    // Use this for initialization
    void Start()
    {
        bg = GetComponent<Transform>();
        width = Screen.width;
        height = Screen.height;
        scaler = width / 1366f;
        styleSize = 35f * scaler;
        styleSize2 = 21f * scaler;
        styleSize3 = 40f * scaler;
        posX = Options.endPosX;
        posY = Options.endPosY;
        selectedBall = 0;
        buttonBlocker = 0;
        goesLeft = Options.endGoesLeft;
        realSpeed = bgMovingSpeed / 1000;
        if (goesLeft)
        {
            posX = posX + realSpeed;
            posY = posY + realSpeed;
        }
        else
        {
            posX = posX - realSpeed;
            posY = posY - realSpeed;
        }
        if (Options.selectedAudio == 0)
        {
            sound.clip = MainMenu.menuTracks[MainMenu.menuTrackNum];
        }
        else if (Options.selectedAudio == 1)
        {
            sound.mute = true;
        }
        sound.Play();
        sound.time = Options.playbackTime;
        if (MainMenu.materialStats[0].music == 1)
        {
            selectedBall = 1;
        }
        else if (MainMenu.materialStats[0].music == 2)
        {
            selectedBall = 2;
        }
        cameBack = false;
        zeroToOne = false;
        oneToTwo = false;
        twoToOne = false;
        oneToZero = false;
    }
    void OnGUI()
    {
        //GUI.DrawTexture(new Rect(width / 2 - 150 * scaler, 30 * scaler, 300 * scaler, 150 * scaler), titleText);
        GUIStyle ShadowStyle = GUI.skin.GetStyle("label");
        ShadowStyle.normal.textColor = Color.yellow;
        ShadowStyle.font = arialRounded;
        ShadowStyle.fontSize = (int)styleSize;
        //draw shadows
        GUI.Label(new Rect(width / 2 - 177.5f * scaler, 32.5f * scaler, 360 * scaler, 100 * scaler), "SELECT YOUR BALL", ShadowStyle);
        ShadowStyle.fontSize = (int)styleSize3;
        if (selectedBall == 0)
        {
            GUI.Label(new Rect(width / 2 - 87f * scaler, 83f * scaler, 180 * scaler, 100 * scaler), "NORMAL", ShadowStyle);
        }
        else if (selectedBall == 1)
        {
            GUI.Label(new Rect(width / 2 - 87f * scaler, 83f * scaler, 180 * scaler, 100 * scaler), "STICKY", ShadowStyle);
        }
        else if (selectedBall == 2)
        {
            GUI.Label(new Rect(width / 2 - 97f * scaler, 83f * scaler, 200 * scaler, 100 * scaler), "SLIPPERY", ShadowStyle);
        }
        //GUI.DrawTexture(new Rect(width / 2 - 230f * scaler, 120f * scaler, 460 * scaler, 460 * scaler), scoreBG);
        GUIStyle style = GUI.skin.GetStyle("label");
        style.normal.textColor = textColor;
        style.font = arialRounded;
        style.fontSize = (int)styleSize;
        //draw texts
        GUI.Label(new Rect(width / 2 - 180f * scaler, 30f * scaler, 360 * scaler, 100 * scaler), "SELECT YOUR BALL", style);
        style.fontSize = (int)styleSize3;
        GUI.DrawTexture(new Rect(width / 2 - 90f * scaler, height - 230f * scaler, 180 * scaler, 60 * scaler), yesButton);
        GUI.DrawTexture(new Rect(width / 2 - 90f * scaler, height - 150f * scaler, 180 * scaler, 60 * scaler), backButton);
        if (selectedBall == 0)
        {
            GUI.Label(new Rect(width / 2 - 90f * scaler, 80f * scaler, 180 * scaler, 100 * scaler), "NORMAL", style);
            GUI.DrawTexture(new Rect(width - 310f * scaler, height / 2 - (90 * scaler), 90 * scaler, 90 * scaler), rightButton);
        }
        else if (selectedBall == 1)
        {
            GUI.Label(new Rect(width / 2 - 90f * scaler, 80f * scaler, 180 * scaler, 100 * scaler), "STICKY", style);
            GUI.DrawTexture(new Rect(220f * scaler, height / 2 - (90 * scaler), 90 * scaler, 90 * scaler), leftButton);
            GUI.DrawTexture(new Rect(width - 310f * scaler, height / 2 - (90 * scaler), 90 * scaler, 90 * scaler), rightButton);
        }
        else if (selectedBall == 2)
        {
            GUI.Label(new Rect(width / 2 - 100f * scaler, 80f * scaler, 200 * scaler, 100 * scaler), "SLIPPERY", style);
            GUI.DrawTexture(new Rect(220f * scaler, height / 2 - (90 * scaler), 90 * scaler, 90 * scaler), leftButton);
        }
    }
    // Update is called once per frame
    void Update()
    {
        //sceneCam.rotation = Quaternion.Euler(Vector3.zero);
        if (goesLeft)
        {
            posX = posX + realSpeed;
            posY = posY + realSpeed;
        }
        else
        {
            posX = posX - realSpeed;
            posY = posY - realSpeed;
        }
        bg.position = new Vector3(posX, posY, bg.position.z);
        if (posX >= 4f)
        {
            goesLeft = false;
        }
        else if (posX <= -4f)
        {
            goesLeft = true;
        }
        Rect yes = new Rect(width / 2 - 90f * scaler, 170f * scaler, 180 * scaler, 60 * scaler);
        Rect back = new Rect(width / 2 - 90f * scaler, 90f * scaler, 180 * scaler, 60 * scaler);
        if (buttonBlocker >= 20)
        {
            if (selectedBall == 0)
            {
                Rect right = new Rect(width - 310f * scaler, height / 2, 90 * scaler, 90 * scaler);
                //to next ball
                if (right.Contains(Input.mousePosition))
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        zeroToOne = true;
                        selectedBall = 1;
                        buttonBlocker = 0;
                    }
                }
                if (Input.touchCount > 0)
                {
                    if (right.Contains(Input.touches[0].position))
                    {
                        zeroToOne = true;
                        selectedBall = 1;
                        buttonBlocker = 0;
                    }
                }
            }
            else if (selectedBall == 1)
            {
                Rect left = new Rect(220f * scaler, height / 2, 90 * scaler, 90 * scaler);
                Rect right = new Rect(width - 310f * scaler, height / 2, 90 * scaler, 90 * scaler);
                //to next ball
                if (right.Contains(Input.mousePosition))
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        oneToTwo = true;
                        selectedBall = 2;
                        buttonBlocker = 0;
                    }
                }
                if (Input.touchCount > 0)
                {
                    if (right.Contains(Input.touches[0].position))
                    {
                        oneToTwo = true;
                        selectedBall = 2;
                        buttonBlocker = 0;
                    }
                }
                //to previous ball
                if (left.Contains(Input.mousePosition))
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        oneToZero = true;
                        selectedBall = 0;
                        buttonBlocker = 0;
                    }
                }
                if (Input.touchCount > 0)
                {
                    if (left.Contains(Input.touches[0].position))
                    {
                        oneToZero = true;
                        selectedBall = 0;
                        buttonBlocker = 0;
                    }
                }
            }
            else if (selectedBall == 2)
            {
                Rect left = new Rect(220f * scaler, height / 2, 90 * scaler, 90 * scaler);
                //to previous ball
                if (left.Contains(Input.mousePosition))
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        twoToOne = true;
                        selectedBall = 1;
                        buttonBlocker = 0;
                    }
                }
                if (Input.touchCount > 0)
                {
                    if (left.Contains(Input.touches[0].position))
                    {
                        twoToOne = true;
                        selectedBall = 1;
                        buttonBlocker = 0;
                    }
                }
            }
        }
        //cancel selection
        if (back.Contains(Input.mousePosition))
        {
            if (Input.GetMouseButtonDown(0))
            {
                playbackTime = sound.time;
                endPosX = posX;
                endPosY = posY;
                endGoesLeft = goesLeft;
                cameBack = true;
                HighScores.cameBack = false;
                SceneManager.LoadScene("Options");
            }
        }
        if (Input.touchCount > 0)
        {
            if (back.Contains(Input.touches[0].position))
            {
                playbackTime = sound.time;
                endPosX = posX;
                endPosY = posY;
                endGoesLeft = goesLeft;
                cameBack = true;
                HighScores.cameBack = false;
                SceneManager.LoadScene("Options");
            }
        }
        //confirm change
        if (yes.Contains(Input.mousePosition))
        {
            if (Input.GetMouseButtonDown(0))
            {
                playbackTime = sound.time;
                endPosX = posX;
                endPosY = posY;
                endGoesLeft = goesLeft;
                cameBack = true;
                HighScores.cameBack = false;
                PlayerPrefs.SetInt("ballNumber", selectedBall);
                PlayerPrefs.SetInt("owned", 1);
                MainMenu.materialStats[0].music = PlayerPrefs.GetInt("ballNumber");
                MainMenu.materialStats[0].controls = PlayerPrefs.GetInt("owned");
                SceneManager.LoadScene("Options");
            }
        }
        if (Input.touchCount > 0)
        {
            if (yes.Contains(Input.touches[0].position))
            {
                playbackTime = sound.time;
                endPosX = posX;
                endPosY = posY;
                endGoesLeft = goesLeft;
                cameBack = true;
                HighScores.cameBack = false;
                PlayerPrefs.SetInt("ballNumber", selectedBall);
                PlayerPrefs.SetInt("owned", 1);
                MainMenu.materialStats[0].music = PlayerPrefs.GetInt("ballNumber");
                MainMenu.materialStats[0].controls = PlayerPrefs.GetInt("owned");
                SceneManager.LoadScene("Options");
            }
        }
        if (buttonBlocker < 20)
        {
            buttonBlocker++;
        }
    }
}