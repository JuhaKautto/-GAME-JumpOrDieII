using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MapSelect : MonoBehaviour {
    public Transform bg;
    //public Texture titleText;
    public Texture backButton;
    public Texture yesButton;
    public Texture leftButton;
    public Texture rightButton;
    public Texture level1;
    public Texture level2;
    public Texture level3;
    public Texture level4;
    public Font arialRounded;
    public Color textColor = new Color(0.2F, 0.3F, 0.4F, 0.5F);
    public AudioSource sound;
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
    bool hasBonus;
    int selectedLevel;
    public static int levelNumber;
    bool goesLeft;
    int buttonBlocker;
    // Use this for initialization
    void Start () {
        selectedLevel = 1;
        bg = GetComponent<Transform>();
        width = Screen.width;
        height = Screen.height;
        scaler = width / 1366f;
        styleSize = 35f * scaler;
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
        sound.time = MenuSelect.playbackTime;
        sound.Play();
        hasBonus = false;
        if (MainMenu.playerStats[0].scoreNum >= 300)
        {
            hasBonus = true;
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
        GUI.Label(new Rect(width / 2 - 147.5f * scaler, 62.5f * scaler, 300 * scaler, 200 * scaler), "SELECT A LEVEL", ShadowStyle);
        GUIStyle style = GUI.skin.GetStyle("label");
        style.normal.textColor = textColor;
        style.font = arialRounded;
        style.fontSize = (int)styleSize;
        //draw texts
        GUI.Label(new Rect(width / 2 - 150f * scaler, 60f * scaler, 300 * scaler, 200 * scaler), "SELECT A LEVEL", style);
        if (selectedLevel == 1)
        {
            GUI.DrawTexture(new Rect(width / 2 - 300f * scaler, height / 2 - (200 * scaler), 600 * scaler, 300 * scaler), level1);
            GUI.DrawTexture(new Rect(width - 310f * scaler, height / 2 - (90 * scaler), 90 * scaler, 90 * scaler), rightButton);
        }
        else if (selectedLevel == 2)
        {
            GUI.DrawTexture(new Rect(220f * scaler, height / 2 - (90 * scaler), 90 * scaler, 90 * scaler), leftButton);
            GUI.DrawTexture(new Rect(width / 2 - 300f * scaler, height / 2 - (200 * scaler), 600 * scaler, 300 * scaler), level2);
            GUI.DrawTexture(new Rect(width - 310f * scaler, height / 2 - (90 * scaler), 90 * scaler, 90 * scaler), rightButton);
        }
        else if (selectedLevel == 3)
        {
            GUI.DrawTexture(new Rect(220f * scaler, height / 2 - (90 * scaler), 90 * scaler, 90 * scaler), leftButton);
            GUI.DrawTexture(new Rect(width / 2 - 300f * scaler, height / 2 - (200 * scaler), 600 * scaler, 300 * scaler), level3);
            if (hasBonus)
            {
                GUI.DrawTexture(new Rect(width - 310f * scaler, height / 2 - (90 * scaler), 90 * scaler, 90 * scaler), rightButton);
            }
        }
        else if (selectedLevel == 4)
        {
            GUI.DrawTexture(new Rect(220f * scaler, height / 2 - (90 * scaler), 90 * scaler, 90 * scaler), leftButton);
            GUI.DrawTexture(new Rect(width / 2 - 300f * scaler, height / 2 - (200 * scaler), 600 * scaler, 300 * scaler), level4);
        }
        GUI.DrawTexture(new Rect(width / 2 - 90f * scaler, height - 230f * scaler, 180 * scaler, 60 * scaler), yesButton);
        GUI.DrawTexture(new Rect(width / 2 - 90f * scaler, height - 150f * scaler, 180 * scaler, 60 * scaler), backButton);
    }
    // Update is called once per frame
    void Update () {
        //print(sound.time + " " + MenuSelect.playbackTime);
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
            if (selectedLevel == 1)
            {
                Rect right = new Rect(width - 310f * scaler, height / 2, 90 * scaler, 90 * scaler);
                //to next level
                if (right.Contains(Input.mousePosition))
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        selectedLevel = 2;
                        buttonBlocker = 0;
                    }
                }
                if (Input.touchCount > 0)
                {
                    if (right.Contains(Input.touches[0].position))
                    {
                        selectedLevel = 2;
                        buttonBlocker = 0;
                    }
                }
            }
            else if (selectedLevel == 2)
            {
                Rect left = new Rect(220f * scaler, height / 2, 90 * scaler, 90 * scaler);
                Rect right = new Rect(width - 310f * scaler, height / 2, 90 * scaler, 90 * scaler);
                //to next level
                if (right.Contains(Input.mousePosition))
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        selectedLevel = 3;
                        buttonBlocker = 0;
                    }
                }
                if (Input.touchCount > 0)
                {
                    if (right.Contains(Input.touches[0].position))
                    {
                        selectedLevel = 3;
                        buttonBlocker = 0;
                    }
                }
                //to previous level
                if (left.Contains(Input.mousePosition))
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        selectedLevel = 1;
                        buttonBlocker = 0;
                    }
                }
                if (Input.touchCount > 0)
                {
                    if (left.Contains(Input.touches[0].position))
                    {
                        selectedLevel = 1;
                        buttonBlocker = 0;
                    }
                }
            }
            else if (selectedLevel == 3)
            {
                Rect left = new Rect(220f * scaler, height / 2, 90 * scaler, 90 * scaler);
                if (hasBonus)
                {
                    Rect right = new Rect(width - 310f * scaler, height / 2, 90 * scaler, 90 * scaler);
                    //to next level
                    if (right.Contains(Input.mousePosition))
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            selectedLevel = 4;
                            buttonBlocker = 0;
                        }
                    }
                    if (Input.touchCount > 0)
                    {
                        if (right.Contains(Input.touches[0].position))
                        {
                            selectedLevel = 4;
                            buttonBlocker = 0;
                        }
                    }
                }
                //to previous level
                if (left.Contains(Input.mousePosition))
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        selectedLevel = 2;
                        buttonBlocker = 0;
                    }
                }
                if (Input.touchCount > 0)
                {
                    if (left.Contains(Input.touches[0].position))
                    {
                        selectedLevel = 2;
                        buttonBlocker = 0;
                    }
                }
            }
            else if (selectedLevel == 4)
            {
                Rect left = new Rect(220f * scaler, height / 2, 90 * scaler, 90 * scaler);
                //to previous level
                if (left.Contains(Input.mousePosition))
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        selectedLevel = 3;
                        buttonBlocker = 0;
                    }
                }
                if (Input.touchCount > 0)
                {
                    if (left.Contains(Input.touches[0].position))
                    {
                        selectedLevel = 3;
                        buttonBlocker = 0;
                    }
                }
            }
            //back to title screen
            if (yes.Contains(Input.mousePosition))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    endPosX = posX;
                    endPosY = posY;
                    levelNumber = selectedLevel;
                    if (selectedLevel == 1)
                    {
                        SceneManager.LoadScene("MainScene");
                    }
                    else if (selectedLevel == 2)
                    {
                        SceneManager.LoadScene("MainScene2");
                    }
                    else if (selectedLevel == 3)
                    {
                        SceneManager.LoadScene("MainScene3");
                    }
                    else if (selectedLevel == 4)
                    {
                        SceneManager.LoadScene("Bonus");
                    }
                }
            }
            if (Input.touchCount > 0)
            {
                if (yes.Contains(Input.touches[0].position))
                {
                    endPosX = posX;
                    endPosY = posY;
                    if (selectedLevel == 1)
                    {
                        SceneManager.LoadScene("MainScene");
                    }
                    else if (selectedLevel == 2)
                    {
                        SceneManager.LoadScene("MainScene2");
                    }
                    else if (selectedLevel == 3)
                    {
                        SceneManager.LoadScene("MainScene3");
                    }
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
