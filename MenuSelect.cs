using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuSelect : MonoBehaviour {
    public Transform bg;
    public Texture titleText;
    public Texture survivalButton;
    public Texture advanceButton;
    public Texture optionsButton;
    public Texture backButton;
    public Font arialRounded;
    public Color textColor = new Color(0.2F, 0.3F, 0.4F, 0.5F);
    public AudioSource sound;
    public AudioClip jingle;
    public AudioClip silence;
    public float bgMovingSpeed = 5;
    public static float endPosX;
    public static float endPosY;
    public static bool endGoesLeft;
    public static bool cameBack;
    public static float playbackTime;
    float realSpeed;
    float styleSize;
    float posX;
    float posY;
    float width;
    float height;
    float scaler;
    bool goesLeft;
    int buttonBlocker;
    // Use this for initialization
    void Start () {
        bg = GetComponent<Transform>();
        sound = GetComponent<AudioSource>();
        width = Screen.width;
        height = Screen.height;
        scaler = width / 1366f;
        styleSize = 30f * scaler;
        posX = MainMenu.endPosX;
        posY = MainMenu.endPosY;
        goesLeft = MainMenu.endGoesLeft;
        realSpeed = bgMovingSpeed / 1000;
        if (MainMenu.settings[0].music == 0)
        {
            sound.clip = MainMenu.menuTracks[MainMenu.menuTrackNum];
        }
        else if (MainMenu.settings[0].music == 1)
        {
            sound.mute = true;
        }
        sound.Play();
        if (MapSelect.cameBack)
        {
            sound.time = MapSelect.playbackTime;
            posX = MapSelect.endPosX;
            posY = MapSelect.endPosY;
            goesLeft = MapSelect.endGoesLeft;
        }
        else if (SurvivalSelect.cameBack)
        {
            sound.time = SurvivalSelect.playbackTime;
            posX = SurvivalSelect.endPosX;
            posY = SurvivalSelect.endPosY;
            goesLeft = SurvivalSelect.endGoesLeft;
        }
        else if (Options.cameBack)
        {
            sound.time = Options.playbackTime;
            posX = Options.endPosX;
            posY = Options.endPosY;
            goesLeft = Options.endGoesLeft;
        }
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
        if (cameBack)
        {
            sound.PlayOneShot(jingle, 2.0f);
        }
        cameBack = false;
    }
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(width / 2 - 200 * scaler, 30 * scaler, 400 * scaler, 200 * scaler), titleText);
        GUIStyle ShadowStyle = GUI.skin.GetStyle("label");
        ShadowStyle.normal.textColor = Color.yellow;
        ShadowStyle.font = arialRounded;
        ShadowStyle.fontSize = (int)styleSize;
        //draw shadows
        //GUI.Label(new Rect(width / 2 - 47.5f * scaler, 302.5f * scaler, 100 * scaler, 600 * scaler), "Here be the menu items", ShadowStyle);
        GUIStyle style = GUI.skin.GetStyle("label");
        style.normal.textColor = textColor;
        style.font = arialRounded;
        style.fontSize = (int)styleSize;
        //draw texts
        //GUI.Label(new Rect(width / 2 - 50f * scaler, 300f * scaler, 100 * scaler, 600 * scaler), "Here be the menu items", style);
        GUI.DrawTexture(new Rect(width / 2 - 135f * scaler, height - 550f * scaler, 270 * scaler, 90 * scaler), advanceButton);
        GUI.DrawTexture(new Rect(width / 2 - 135f * scaler, height - 450f * scaler, 270 * scaler, 90 * scaler), survivalButton);
        GUI.DrawTexture(new Rect(width / 2 - 135f * scaler, height - 350f * scaler, 270 * scaler, 90 * scaler), optionsButton);
        GUI.DrawTexture(new Rect(width / 2 - 90f * scaler, height - 150f * scaler, 180 * scaler, 60 * scaler), backButton);
    }
    // Update is called once per frame
    void Update () {
        //print(sound.time);
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
        Rect advance = new Rect(width / 2 - 135f * scaler, 460f * scaler, 270 * scaler, 90 * scaler);
        Rect survival = new Rect(width / 2 - 135f * scaler, 360f * scaler, 270 * scaler, 90 * scaler);
        Rect options = new Rect(width / 2 - 135f * scaler, 260f * scaler, 270 * scaler, 90 * scaler);
        Rect back = new Rect(width / 2 - 90f * scaler, 90f * scaler, 180 * scaler, 60 * scaler);
        if (buttonBlocker >= 20)
        {
            //advance mode
            if (advance.Contains(Input.mousePosition))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    playbackTime = sound.time;
                    endPosX = posX;
                    endPosY = posY;
                    endGoesLeft = goesLeft;
                    SceneManager.LoadScene("MapSelect");
                }
            }
            if (Input.touchCount > 0)
            {
                if (advance.Contains(Input.touches[0].position))
                {
                    playbackTime = sound.time;
                    endPosX = posX;
                    endPosY = posY;
                    endGoesLeft = goesLeft;
                    SceneManager.LoadScene("MapSelect");
                }
            }
            //survival mode
            if (survival.Contains(Input.mousePosition))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    playbackTime = sound.time;
                    endPosX = posX;
                    endPosY = posY;
                    endGoesLeft = goesLeft;
                    SceneManager.LoadScene("SurvivalSelect");
                }
            }
            if (Input.touchCount > 0)
            {
                if (survival.Contains(Input.touches[0].position))
                {
                    playbackTime = sound.time;
                    endPosX = posX;
                    endPosY = posY;
                    endGoesLeft = goesLeft;
                    SceneManager.LoadScene("SurvivalSelect");
                }
            }
            //options menu
            if (options.Contains(Input.mousePosition))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    playbackTime = sound.time;
                    endPosX = posX;
                    endPosY = posY;
                    endGoesLeft = goesLeft;
                    HighScores.cameBack = false;
                    SceneManager.LoadScene("Options");
                }
            }
            if (Input.touchCount > 0)
            {
                if (options.Contains(Input.touches[0].position))
                {
                    playbackTime = sound.time;
                    endPosX = posX;
                    endPosY = posY;
                    endGoesLeft = goesLeft;
                    HighScores.cameBack = false;
                    SceneManager.LoadScene("Options");
                }
            }
            //back to title screen
            if (back.Contains(Input.mousePosition))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    endPosX = posX;
                    endPosY = posY;
                    endGoesLeft = goesLeft;
                    cameBack = true;
                    SceneManager.LoadScene("MainMenu");
                }
            }
            if (Input.touchCount > 0)
            {
                if (back.Contains(Input.touches[0].position))
                {
                    endPosX = posX;
                    endPosY = posY;
                    endGoesLeft = goesLeft;
                    cameBack = true;
                    SceneManager.LoadScene("MainMenu");
                }
            }
        }
        if (buttonBlocker < 20)
        {
            buttonBlocker++;
        }
        /*if (Input.GetKey(KeyCode.Return))
        {
            endPosX = posX;
            endPosY = posY;
            endGoesLeft = goesLeft;
            SceneManager.LoadScene("MapSelect");
        }*/
    }
}
