using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Options : MonoBehaviour {
    public Transform bg;
    //public Texture titleText;
    public Texture backButton;
    public Texture yesButton;
    public Texture highScoreButton;
    public Texture buttonsButton;
    public Texture tiltingButton;
    public Texture musicOffButton;
    public Texture musicOnButton;
    public Texture ballButton;
    public Font arialRounded;
    public Color textColor = new Color(0.2F, 0.3F, 0.4F, 0.5F);
    public float bgMovingSpeed = 5;
    public AudioSource sound;
    public AudioClip silence;
    public static string playerName = "Player";
    public static int selectedControls;
    public static int selectedAudio;
    public static float endPosX;
    public static float endPosY;
    public static bool endGoesLeft;
    public static bool cameBack;
    public static float playbackTime;
    float realSpeed;
    float styleSize;
    float styleSize2;
    float posX;
    float posY;
    float width;
    float height;
    float scaler;
    bool goesLeft;
    bool selectedButtons;
    bool musicOn;
    int buttonBlocker;
    // Use this for initialization
    void Start () {
        bg = GetComponent<Transform>();
        width = Screen.width;
        height = Screen.height;
        scaler = width / 1366f;
        styleSize = 35f * scaler;
        if (MainMenu.playerStats[0].name != "")
        {
            playerName = MainMenu.playerStats[0].name;
        }
        styleSize2 = 25f * scaler;
        selectedControls = MainMenu.settings[0].controls;
        selectedAudio = MainMenu.settings[0].music;
        posX = MenuSelect.endPosX;
        posY = MenuSelect.endPosY;
        goesLeft = MenuSelect.endGoesLeft;
        realSpeed = bgMovingSpeed / 1000;
        if (selectedAudio == 0)
        {
            sound.clip = MainMenu.menuTracks[MainMenu.menuTrackNum];
        }
        else if (selectedAudio == 1)
        {
            sound.mute = true;
        }
        sound.Play();
        sound.time = MenuSelect.playbackTime;
        if (HighScores.cameBack)
        {
            sound.time = HighScores.playbackTime;
            posX = HighScores.endPosX;
            posY = HighScores.endPosY;
            goesLeft = HighScores.endGoesLeft;
        }
        else if (BallSelect.cameBack)
        {
            sound.time = BallSelect.playbackTime;
            posX = BallSelect.endPosX;
            posY = BallSelect.endPosY;
            goesLeft = BallSelect.endGoesLeft;
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
        if (selectedControls == 0)
        {
            selectedButtons = true;
        }
        else if (selectedControls == 1)
        {
            selectedButtons = false;
        }
        if (selectedAudio == 0)
        {
            musicOn = true;
        }
        else if (selectedAudio == 1)
        {
            musicOn = false;
        }
        cameBack = false;
    }
    void OnGUI()
    {
        //GUI.DrawTexture(new Rect(width / 2 - 150 * scaler, 30 * scaler, 300 * scaler, 150 * scaler), titleText);
        GUIStyle ShadowStyle = GUI.skin.GetStyle("label");
        ShadowStyle.normal.textColor = Color.yellow;
        ShadowStyle.font = arialRounded;
        ShadowStyle.fontSize = (int)styleSize;
        //draw shadows
        GUI.Label(new Rect(width / 2 - 87.5f * scaler, 62.5f * scaler, 180 * scaler, 150 * scaler), "OPTIONS", ShadowStyle);
        ShadowStyle.fontSize = (int)styleSize2;
        GUI.Label(new Rect(width / 2 - 107.5f * scaler, height - 372.5f * scaler, 220 * scaler, 40 * scaler), "SET YOUR NAME", ShadowStyle);
        GUIStyle style = GUI.skin.GetStyle("label");
        style.normal.textColor = textColor;
        style.font = arialRounded;
        style.fontSize = (int)styleSize;
        //draw texts
        GUI.Label(new Rect(width / 2 - 90f * scaler, 60f * scaler, 180 * scaler, 150 * scaler), "OPTIONS", style);
        ShadowStyle.fontSize = (int)styleSize2;
        GUI.Label(new Rect(width / 2 - 110f * scaler, height - 375f * scaler, 220 * scaler, 40 * scaler), "SET YOUR NAME", style);
        if (selectedButtons)
        {
            GUI.DrawTexture(new Rect(width / 2 - 120f * scaler, height - 550f * scaler, 240 * scaler, 80 * scaler), buttonsButton);
        }
        else
        {
            GUI.DrawTexture(new Rect(width / 2 - 120f * scaler, height - 550f * scaler, 240 * scaler, 80 * scaler), tiltingButton);
        }
        if (musicOn)
        {
            GUI.DrawTexture(new Rect(width / 2 - 120f * scaler, height - 640f * scaler, 240 * scaler, 80 * scaler), musicOnButton);
        }
        else
        {
            GUI.DrawTexture(new Rect(width / 2 - 120f * scaler, height - 640f * scaler, 240 * scaler, 80 * scaler), musicOffButton);
        }
        GUI.DrawTexture(new Rect(width / 2 - 120f * scaler, height - 460f * scaler, 240 * scaler, 80 * scaler), ballButton);
        GUIStyle textField = GUI.skin.GetStyle("textfield");
        textField.normal.textColor = Color.yellow;
        textField.font = arialRounded;
        textField.fontSize = (int)styleSize2;
        playerName = GUI.TextField(new Rect(width / 2 - 120f * scaler, height - 335f * scaler, 240 * scaler, 40 * scaler), playerName, 8);
        GUI.DrawTexture(new Rect(width / 2 - 120f * scaler, height - 280f * scaler, 230 * scaler, 80 * scaler), highScoreButton);
        GUI.DrawTexture(new Rect(width / 2 - 90f * scaler, height - 150f * scaler, 180 * scaler, 60 * scaler), backButton);
    }
    // Update is called once per frame
    void Update ()
    {
        //print(sound.time);
        if (!musicOn)
        {
            sound.Stop();
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
        bg.position = new Vector3(posX, posY, bg.position.z);
        if (posX >= 4f)
        {
            goesLeft = false;
        }
        else if (posX <= -4f)
        {
            goesLeft = true;
        }
        Rect music = new Rect(width / 2 - 120f * scaler, 560f * scaler, 240 * scaler, 80 * scaler);
        Rect controls = new Rect(width / 2 - 120f * scaler, 470f * scaler, 240 * scaler, 80 * scaler);
        Rect ball = new Rect(width / 2 - 120f * scaler, 380f * scaler, 240 * scaler, 80 * scaler);
        Rect scores = new Rect(width / 2 - 120f * scaler, 190f * scaler, 240 * scaler, 80 * scaler);
        Rect back = new Rect(width / 2 - 90f * scaler, 90f * scaler, 180 * scaler, 60 * scaler);
        //toggle music on/off
        if (buttonBlocker >= 20)
        {
            if (music.Contains(Input.mousePosition))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    musicOn = !musicOn;
                    if (musicOn)
                    {
                        selectedAudio = 0;
                        buttonBlocker = 0;
                    }
                    else
                    {
                        selectedAudio = 1;
                        buttonBlocker = 0;
                    }
                }
            }
            if (Input.touchCount > 0)
            {
                if (music.Contains(Input.touches[0].position))
                {
                    musicOn = !musicOn;
                    if (musicOn)
                    {
                        selectedAudio = 0;
                        buttonBlocker = 0;
                    }
                    else
                    {
                        selectedAudio = 1;
                        buttonBlocker = 0;
                    }
                }
            }
            //change control setup
            if (controls.Contains(Input.mousePosition))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    selectedButtons = !selectedButtons;
                    if (selectedButtons)
                    {
                        selectedControls = 0;
                        buttonBlocker = 0;
                    }
                    else
                    {
                        selectedControls = 1;
                        buttonBlocker = 0;
                    }
                }
            }
            if (Input.touchCount > 0)
            {
                if (controls.Contains(Input.touches[0].position))
                {
                    selectedButtons = !selectedButtons;
                    if (selectedButtons)
                    {
                        selectedControls = 0;
                        buttonBlocker = 0;
                    }
                    else
                    {
                        selectedControls = 1;
                        buttonBlocker = 0;
                    }
                }
            }
            //go to ball select
            if (ball.Contains(Input.mousePosition))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    playbackTime = sound.time;
                    endPosX = posX;
                    endPosY = posY;
                    endGoesLeft = goesLeft;
                    PlayerPrefs.SetString("playerName", playerName);
                    MainMenu.playerStats[0].name = PlayerPrefs.GetString("playerName");
                    PlayerPrefs.SetInt("selectedAudio", selectedAudio);
                    PlayerPrefs.SetInt("selectedControls", selectedControls);
                    MainMenu.settings[0].music = PlayerPrefs.GetInt("selectedAudio");
                    MainMenu.settings[0].controls = PlayerPrefs.GetInt("selectedControls");
                    SceneManager.LoadScene("BallSelect");
                }
            }
            if (Input.touchCount > 0)
            {
                if (ball.Contains(Input.touches[0].position))
                {
                    playbackTime = sound.time;
                    endPosX = posX;
                    endPosY = posY;
                    endGoesLeft = goesLeft;
                    PlayerPrefs.SetString("playerName", playerName);
                    MainMenu.playerStats[0].name = PlayerPrefs.GetString("playerName");
                    PlayerPrefs.SetInt("selectedAudio", selectedAudio);
                    PlayerPrefs.SetInt("selectedControls", selectedControls);
                    MainMenu.settings[0].music = PlayerPrefs.GetInt("selectedAudio");
                    MainMenu.settings[0].controls = PlayerPrefs.GetInt("selectedControls");
                    SceneManager.LoadScene("BallSelect");
                }
            }
            //view high scores
            if (scores.Contains(Input.mousePosition))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    playbackTime = sound.time;
                    endPosX = posX;
                    endPosY = posY;
                    endGoesLeft = goesLeft;
                    PlayerPrefs.SetString("playerName", playerName);
                    MainMenu.playerStats[0].name = PlayerPrefs.GetString("playerName");
                    PlayerPrefs.SetInt("selectedAudio", selectedAudio);
                    PlayerPrefs.SetInt("selectedControls", selectedControls);
                    MainMenu.settings[0].music = PlayerPrefs.GetInt("selectedAudio");
                    MainMenu.settings[0].controls = PlayerPrefs.GetInt("selectedControls");
                    SceneManager.LoadScene("HighScores");
                }
            }
            if (Input.touchCount > 0)
            {
                if (scores.Contains(Input.touches[0].position))
                {
                    playbackTime = sound.time;
                    endPosX = posX;
                    endPosY = posY;
                    endGoesLeft = goesLeft;
                    PlayerPrefs.SetString("playerName", playerName);
                    MainMenu.playerStats[0].name = PlayerPrefs.GetString("playerName");
                    PlayerPrefs.SetInt("selectedAudio", selectedAudio);
                    PlayerPrefs.SetInt("selectedControls", selectedControls);
                    MainMenu.settings[0].music = PlayerPrefs.GetInt("selectedAudio");
                    MainMenu.settings[0].controls = PlayerPrefs.GetInt("selectedControls");
                    SceneManager.LoadScene("HighScores");
                }
            }
            //back to title screen
            if (back.Contains(Input.mousePosition))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    playbackTime = sound.time;
                    endPosX = posX;
                    endPosY = posY;
                    endGoesLeft = goesLeft;
                    cameBack = true;
                    SurvivalSelect.cameBack = false;
                    MapSelect.cameBack = false;
                    PlayerPrefs.SetString("playerName", playerName);
                    MainMenu.playerStats[0].name = PlayerPrefs.GetString("playerName");
                    PlayerPrefs.SetInt("selectedAudio", selectedAudio);
                    PlayerPrefs.SetInt("selectedControls", selectedControls);
                    MainMenu.settings[0].music = PlayerPrefs.GetInt("selectedAudio");
                    MainMenu.settings[0].controls = PlayerPrefs.GetInt("selectedControls");
                    SceneManager.LoadScene("MenuSelect");
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
                    SurvivalSelect.cameBack = false;
                    MapSelect.cameBack = false;
                    PlayerPrefs.SetString("playerName", playerName);
                    MainMenu.playerStats[0].name = PlayerPrefs.GetString("playerName");
                    PlayerPrefs.SetInt("selectedAudio", selectedAudio);
                    PlayerPrefs.SetInt("selectedControls", selectedControls);
                    MainMenu.settings[0].music = PlayerPrefs.GetInt("selectedAudio");
                    MainMenu.settings[0].controls = PlayerPrefs.GetInt("selectedControls");
                    SceneManager.LoadScene("MenuSelect");
                }
            }
        }
        if (buttonBlocker < 20)
        {
            buttonBlocker++;
        }
    }
}
