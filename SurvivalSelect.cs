using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SurvivalSelect : MonoBehaviour {
    public Transform bg;
    //public Texture titleText;
    public Texture backButton;
    public Texture yesButton;
    public Texture survivalLevel;
    public Font arialRounded;
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
    float posX;
    float posY;
    float width;
    float height;
    float scaler;
    bool goesLeft;
    int buttonBlocker;
    // Use this for initialization
    void Start()
    {
        bg = GetComponent<Transform>();
        width = Screen.width;
        height = Screen.height;
        scaler = width / 1366f;
        styleSize = 35f * scaler;
        styleSize2 = 25f * scaler;
        posX = MenuSelect.endPosX;
        posY = MenuSelect.endPosY;
        goesLeft = MenuSelect.endGoesLeft;
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
        if (MainMenu.settings[0].music == 0)
        {
            sound.clip = MainMenu.menuTracks[MainMenu.menuTrackNum];
        }
        else if (MainMenu.settings[0].music == 1)
        {
            sound.mute = true;
        }
        sound.Play();
        sound.time = MenuSelect.playbackTime;
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
        GUI.Label(new Rect(width / 2 - 157.5f * scaler, 62.5f * scaler, 320 * scaler, 200 * scaler), "SURVIVAL MODE", ShadowStyle);
        ShadowStyle.fontSize = (int)styleSize2;
        GUI.Label(new Rect(width / 2 - 217.5f * scaler, 122.5f * scaler, 440 * scaler, 200 * scaler), "INFINITE LEVEL, LIMITED HEALTH", ShadowStyle);
        GUIStyle style = GUI.skin.GetStyle("label");
        style.normal.textColor = textColor;
        style.font = arialRounded;
        style.fontSize = (int)styleSize;
        //draw texts
        GUI.Label(new Rect(width / 2 - 160f * scaler, 60f * scaler, 320 * scaler, 200 * scaler), "SURVIVAL MODE", style);
        style.fontSize = (int)styleSize2;
        GUI.Label(new Rect(width / 2 - 220f * scaler, 120f * scaler, 440 * scaler, 200 * scaler), "INFINITE LEVEL, LIMITED HEALTH", style);
        GUI.DrawTexture(new Rect(width / 2 - 300f * scaler, height / 2 - (200 * scaler), 600 * scaler, 300 * scaler), survivalLevel);
        GUI.DrawTexture(new Rect(width / 2 - 90f * scaler, height - 230f * scaler, 180 * scaler, 60 * scaler), yesButton);
        GUI.DrawTexture(new Rect(width / 2 - 90f * scaler, height - 150f * scaler, 180 * scaler, 60 * scaler), backButton);
    }
    // Update is called once per frame
    void Update()
    {
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
        Rect yes = new Rect(width / 2 - 90f * scaler, 170f * scaler, 180 * scaler, 60 * scaler);
        Rect back = new Rect(width / 2 - 90f * scaler, 90f * scaler, 180 * scaler, 60 * scaler);
        if (buttonBlocker >= 20)
        {
            //to level
            if (yes.Contains(Input.mousePosition))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    endPosX = posX;
                    endPosY = posY;
                    SceneManager.LoadScene("MainSceneSurvival");
                }
            }
            if (Input.touchCount > 0)
            {
                if (yes.Contains(Input.touches[0].position))
                {
                    endPosX = posX;
                    endPosY = posY;
                    SceneManager.LoadScene("MainSceneSurvival");
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
                    MapSelect.cameBack = false;
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
                    MapSelect.cameBack = false;
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
