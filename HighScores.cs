using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HighScores : MonoBehaviour
{
    public Transform bg;
    //public Texture titleText;
    public Texture backButton;
    public Texture scoreBG;
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
    int selectedLevel;
    int buttonBlocker;
    // Use this for initialization
    void Start()
    {
        bg = GetComponent<Transform>();
        width = Screen.width;
        height = Screen.height;
        scaler = width / 1366f;
        styleSize = 30f * scaler;
        styleSize2 = 21f * scaler;
        styleSize3 = 35f * scaler;
        posX = Options.endPosX;
        posY = Options.endPosY;
        selectedLevel = 1;
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
        GUI.Label(new Rect(width / 2 - 117.5f * scaler, 32.5f * scaler, 240 * scaler, 100 * scaler), "HIGH SCORES", ShadowStyle);
        ShadowStyle.fontSize = (int)styleSize3;
        if (selectedLevel == 1)
        {
            GUI.Label(new Rect(width / 2 - 57.5f * scaler, 62.5f * scaler, 120 * scaler, 100 * scaler), "EASY", ShadowStyle);
        }
        else if (selectedLevel == 2)
        {
            GUI.Label(new Rect(width / 2 - 77.5f * scaler, 62.5f * scaler, 160 * scaler, 100 * scaler), "MEDIUM", ShadowStyle);
        }
        else if (selectedLevel == 3)
        {
            GUI.Label(new Rect(width / 2 - 57.5f * scaler, 62.5f * scaler, 120 * scaler, 100 * scaler), "HARD", ShadowStyle);
        }
        else if (selectedLevel == 4)
        {
            GUI.Label(new Rect(width / 2 - 92.5f * scaler, 62.5f * scaler, 190 * scaler, 100 * scaler), "SURVIVAL", ShadowStyle);
        }
        GUI.DrawTexture(new Rect(width / 2 - 230f * scaler, 120f * scaler, 460 * scaler, 460 * scaler), scoreBG);
        GUIStyle scoreStyle = GUI.skin.GetStyle("label");
        scoreStyle.normal.textColor = Color.yellow;
        scoreStyle.font = arialRounded;
        scoreStyle.fontSize = (int)styleSize2;
        if (selectedLevel == 1)
        {
            for (int i = 0; i < MainMenu.scores.Length; i++)
            {
                GUI.Label(new Rect(width / 2 - 180 * scaler, (125 + i * 22) * scaler, 300 * scaler, 60 * scaler), MainMenu.scores[i].name);
                GUI.Label(new Rect(width / 2 - 20 * scaler, (125 + i * 22) * scaler, 300 * scaler, 60 * scaler), MainMenu.scores[i].scoreNum.ToString());
            }
        }
        else if (selectedLevel == 2)
        {
            for (int i = 0; i < MainMenu.scores2.Length; i++)
            {
                GUI.Label(new Rect(width / 2 - 180 * scaler, (125 + i * 22) * scaler, 300 * scaler, 60 * scaler), MainMenu.scores2[i].name);
                GUI.Label(new Rect(width / 2 - 20 * scaler, (125 + i * 22) * scaler, 300 * scaler, 60 * scaler), MainMenu.scores2[i].scoreNum.ToString());
            }
        }
        else if (selectedLevel == 3)
        {
            for (int i = 0; i < MainMenu.scores3.Length; i++)
            {
                GUI.Label(new Rect(width / 2 - 180 * scaler, (125 + i * 22) * scaler, 300 * scaler, 60 * scaler), MainMenu.scores3[i].name);
                GUI.Label(new Rect(width / 2 - 20 * scaler, (125 + i * 22) * scaler, 300 * scaler, 60 * scaler), MainMenu.scores3[i].scoreNum.ToString());
            }
        }
        else if (selectedLevel == 4)
        {
            for (int i = 0; i < MainMenu.survivalScores.Length; i++)
            {
                GUI.Label(new Rect(width / 2 - 180 * scaler, (125 + i * 22) * scaler, 300 * scaler, 60 * scaler), MainMenu.survivalScores[i].name);
                GUI.Label(new Rect(width / 2 - 20 * scaler, (125 + i * 22) * scaler, 300 * scaler, 60 * scaler), MainMenu.survivalScores[i].scoreNum.ToString());
            }
        }
        GUIStyle style = GUI.skin.GetStyle("label");
        style.normal.textColor = textColor;
        style.font = arialRounded;
        style.fontSize = (int)styleSize;
        //draw texts
        GUI.Label(new Rect(width / 2 - 120f * scaler, 30f * scaler, 240 * scaler, 100 * scaler), "HIGH SCORES", style);
        style.fontSize = (int)styleSize3;
        GUI.DrawTexture(new Rect(width / 2 - 90f * scaler, height - 150f * scaler, 180 * scaler, 60 * scaler), backButton);
        if (selectedLevel == 1)
        {
            GUI.Label(new Rect(width / 2 - 60f * scaler, 60f * scaler, 120 * scaler, 100 * scaler), "EASY", style);
            GUI.DrawTexture(new Rect(width - 310f * scaler, height / 2 - (90 * scaler), 90 * scaler, 90 * scaler), rightButton);
        }
        else if (selectedLevel == 2)
        {
            GUI.Label(new Rect(width / 2 - 80f * scaler, 60f * scaler, 160 * scaler, 100 * scaler), "MEDIUM", style);
            GUI.DrawTexture(new Rect(220f * scaler, height / 2 - (90 * scaler), 90 * scaler, 90 * scaler), leftButton);
            GUI.DrawTexture(new Rect(width - 310f * scaler, height / 2 - (90 * scaler), 90 * scaler, 90 * scaler), rightButton);
        }
        else if (selectedLevel == 3)
        {
            GUI.Label(new Rect(width / 2 - 60f * scaler, 60f * scaler, 120 * scaler, 100 * scaler), "HARD", style);
            GUI.DrawTexture(new Rect(220f * scaler, height / 2 - (90 * scaler), 90 * scaler, 90 * scaler), leftButton);
            GUI.DrawTexture(new Rect(width - 310f * scaler, height / 2 - (90 * scaler), 90 * scaler, 90 * scaler), rightButton);
        }
        else if (selectedLevel == 4)
        {
            GUI.Label(new Rect(width / 2 - 95f * scaler, 60f * scaler, 190 * scaler, 100 * scaler), "SURVIVAL", style);
            GUI.DrawTexture(new Rect(220f * scaler, height / 2 - (90 * scaler), 90 * scaler, 90 * scaler), leftButton);
        }
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
                BallSelect.cameBack = false;
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
                BallSelect.cameBack = false;
                SceneManager.LoadScene("Options");
            }
        }
            if (buttonBlocker < 20)
            {
                buttonBlocker++;
            }
        }
}