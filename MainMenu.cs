using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {
    public Transform bg;
    public Texture titleText;
    public Font arialRounded;
    public static Score[] scores = new Score[20];
    public static Score[] scores2 = new Score[20];
    public static Score[] scores3 = new Score[20];
    public static Score[] survivalScores = new Score[20];
    public static Score[] playerStats = new Score[1];
    public static Settings[] settings = new Settings[1];
    public static Settings[] materialStats = new Settings[1];
    public static AudioClip[] levelTracks = new AudioClip[6];
    public static AudioClip[] menuTracks = new AudioClip[2];
    public static PhysicMaterial[] materials = new PhysicMaterial[3];
    public Color textColor = new Color(0.2F, 0.3F, 0.4F, 0.5F);
    public AudioClip track1;
    public AudioClip track2;
    public AudioClip track3;
    public AudioClip track4;
    public AudioClip track5;
    public AudioClip track6;
    public AudioClip track7;
    public AudioClip track8;
    public PhysicMaterial sticky;
    public PhysicMaterial ball;
    public PhysicMaterial slippy;
    public float bgMovingSpeed = 5;
    public static float endPosX;
    public static float endPosY;
    public static bool endGoesLeft;
    float realSpeed;
    float styleSize;
    float blinkTimer;
    float demoTimeout;
    float posX;
    float posY;
    float width;
    float height;
    float scaler;
    bool goesLeft;
    int buttonBlocker;
    public static int trackNum;
    public static int menuTrackNum;
    static int prevTrack;
    static int prevMenuTrack;
    void Awake()
    {
        Application.targetFrameRate = 60;
    }
    // Use this for initialization
    void Start () {
        bg = GetComponent<Transform>();
        width = Screen.width;
        height = Screen.height;
        scaler = width / 1920f;
        blinkTimer = 0;
        trackNum = Mathf.FloorToInt(Random.Range(0f, 5.9f));
        if (trackNum == prevTrack)
        {
            trackNum = Mathf.FloorToInt(Random.Range(0f, 5.9f));
        }
        prevTrack = trackNum;
        menuTrackNum = 0;
        if (prevMenuTrack == 0)
        {
            menuTrackNum = 1;
        }
        prevMenuTrack = menuTrackNum;
        posX = 0;
        posY = 0;
        realSpeed = bgMovingSpeed / 1000;
        if (MenuSelect.cameBack)
        {
            posX = MenuSelect.endPosX;
            posY = MenuSelect.endPosY;
            goesLeft = MenuSelect.endGoesLeft;
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
        }
        SurvivalCube.onExit = false;
        FollowCube.onExit = false;
        //goesLeft = true;
        styleSize = 55f * scaler;
        //easy scores
        for (int i = 0; i < scores.Length; i++)
        {
            scores[i] = new Score(60000 - i * 2000, "Player");
        }
        for (int i = 0; i < scores.Length; i++)
        {
            scores[i].scoreNum = PlayerPrefs.GetInt("score" + i);
            scores[i].name = PlayerPrefs.GetString("scorename" + i);
        }
        //medium scores
        for (int i = 0; i < scores2.Length; i++)
        {
            scores2[i] = new Score(60000 - i * 2000, "Player");
        }
        for (int i = 0; i < scores2.Length; i++)
        {
            scores2[i].scoreNum = PlayerPrefs.GetInt("score2" + i);
            scores2[i].name = PlayerPrefs.GetString("scorename2" + i);
        }
        //hard scores
        for (int i = 0; i < scores3.Length; i++)
        {
            scores3[i] = new Score(60000 - i * 2000, "Player");
        }
        for (int i = 0; i < scores3.Length; i++)
        {
            scores3[i].scoreNum = PlayerPrefs.GetInt("score3" + i);
            scores3[i].name = PlayerPrefs.GetString("scorename3" + i);
        }
        //survival scores
        for (int i = 0; i < survivalScores.Length; i++)
        {
            survivalScores[i] = new Score(60000 - i * 2000, "Player");
        }
        for (int i = 0; i < survivalScores.Length; i++)
        {
            survivalScores[i].scoreNum = PlayerPrefs.GetInt("survivalScore" + i);
            survivalScores[i].name = PlayerPrefs.GetString("survivalName" + i);
        }
        //player name and stars
        playerStats[0] = new Score(0, "Player");
        playerStats[0].scoreNum = PlayerPrefs.GetInt("totalStars");
        playerStats[0].name = PlayerPrefs.GetString("playerName");
        //game settings
        settings[0] = new Settings(0, 0);
        settings[0].music = PlayerPrefs.GetInt("selectedAudio");
        settings[0].controls = PlayerPrefs.GetInt("selectedControls");
        //player ball stats (purchased balls)
        /*for (int i = 0; i < materialStats.Length; i++)
        {
            materialStats[i] = new Settings(i, 0);
        }
        for (int i = 0; i < materialStats.Length; i++)
        {*/
        materialStats[0] = new Settings(0, 0);
        materialStats[0].music = PlayerPrefs.GetInt("ballNumber"); //number of ball, 0=normal, 1= sticky, 2= slippy
        materialStats[0].controls = PlayerPrefs.GetInt("owned"); // 0= doesn't have, 1= has
        //}
        //levels soundtrack
        levelTracks[0] = track1;
        levelTracks[1] = track2;
        levelTracks[2] = track3;
        levelTracks[3] = track4;
        levelTracks[4] = track5;
        levelTracks[5] = track6;
        //menu soundtrck
        menuTracks[0] = track7;
        menuTracks[1] = track8;
        //ball materials
        materials[0] = ball;
        materials[1] = sticky;
        materials[2] = slippy;
    }
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(width / 2 - 500 * scaler, 40 * scaler, 1000 * scaler, 500 * scaler), titleText);
        if (blinkTimer >= 0.75f)
        {
            GUIStyle ShadowStyle = GUI.skin.GetStyle("label");
            ShadowStyle.normal.textColor = Color.yellow;
            ShadowStyle.font = arialRounded;
            ShadowStyle.fontSize = (int)styleSize;
            GUI.Label(new Rect(width / 2 - 197f * scaler, 703f * scaler, 400 * scaler, 90 * scaler), "TAP TO START", ShadowStyle);
            GUIStyle style = GUI.skin.GetStyle("label");
            style.normal.textColor = textColor;
            style.font = arialRounded;
            style.fontSize = (int)styleSize;
            GUI.Label(new Rect(width / 2 - 200 * scaler, 700 * scaler, 400 * scaler, 90 * scaler), "TAP TO START", style);
        }
    }
    // Update is called once per frame
    void Update () {
        //print(prevTrack + " " + trackNum);
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
        if (buttonBlocker >= 20)
        {
            if (Input.touchCount > 0 || Input.GetKey(KeyCode.Return))
            {
                endPosX = posX;
                endPosY = posY;
                endGoesLeft = goesLeft;
                //print(goesLeft);
                SceneManager.LoadScene("MenuSelect");
            }
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
        if (demoTimeout >= 20)
        {
            endPosX = posX;
            endPosY = posY;
            endGoesLeft = goesLeft;
            //print(goesLeft);
            SceneManager.LoadScene("DemoScene");
        }
        if (buttonBlocker < 20)
        {
            buttonBlocker++;
        }
        blinkTimer += Time.deltaTime;
        demoTimeout += Time.deltaTime;
        if (blinkTimer >= 1.5f)
        {
            blinkTimer = 0;
        }
    }
}
