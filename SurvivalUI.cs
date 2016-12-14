using UnityEngine;
using System.Collections;

public class SurvivalUI : MonoBehaviour {
    public Font arialRounded;
    public Color textColor = new Color(0.2F, 0.3F, 0.4F, 0.5F);
    public Color yellow = new Color(0.2F, 0.3F, 0.4F, 0.5F);
    public Texture speedoBG;
    public Texture speedoCol;
    public Texture speedoFG;
    //public Texture jumpRect;
    public Texture starIcon;
    public Texture levelEndBG;
    public Texture health8;
    public Texture health7;
    public Texture health6;
    public Texture health5;
    public Texture health4;
    public Texture health3;
    public Texture health2;
    public Texture health1;
    public Texture health0;
    public Texture uiBg;
    float styleSize;
    float styleSize2;
    float styleSize3;
    int endCounter;
    float blinkTimer;
    float width;
    float height;
    float scaler;
    float speedoMeter;
    // Use this for initialization
    void Start()
    {
        width = Screen.width;
        height = Screen.height;
        scaler = width / 1920f;
        styleSize = 50f * scaler;
        styleSize2 = 40f * scaler;
        styleSize3 = 55f * scaler;
        blinkTimer = 0;
        speedoMeter = SurvivalCube.speed;
        endCounter = 0;
    }
    void OnGUI()
    {
        if (!SurvivalCube.onExit)
        {
            GUI.DrawTexture(new Rect(0, 0, 1920 * scaler, 256 * scaler), uiBg);
            GUIStyle shadowStyle = GUI.skin.GetStyle("label");
            shadowStyle.normal.textColor = textColor;
            shadowStyle.font = arialRounded;
            shadowStyle.fontSize = (int)styleSize;
            GUI.Label(new Rect(53 * scaler, 30 * scaler, 600 * scaler, 150 * scaler), "SCORE" + "  " + Mathf.FloorToInt(SurvivalCube.sentScore));
            GUI.DrawTexture(new Rect(50 * scaler, 90 * scaler, 90 * scaler, 90 * scaler), starIcon);
            GUI.Label(new Rect(53 + (100 * scaler), 103 * scaler, 400 * scaler, 70 * scaler), "X" + " " + Mathf.FloorToInt(SurvivalCollector.stars));
            GUIStyle style = GUI.skin.GetStyle("label");
            style.normal.textColor = yellow;
            style.font = arialRounded;
            style.fontSize = (int)styleSize;
            GUI.Label(new Rect(50 * scaler, 27 * scaler, 600 * scaler, 150 * scaler), "SCORE" + "  " + Mathf.FloorToInt(SurvivalCube.sentScore));
            GUI.Label(new Rect(50 + (100 * scaler), 100 * scaler, 400 * scaler, 70 * scaler), "X" + " " + Mathf.FloorToInt(SurvivalCollector.stars));
            Vector2 pivotPoint = new Vector2(width / 2 + 350 * scaler, 80);
            GUI.DrawTexture(new Rect(width / 2 + 250 * scaler, 40, 659 * scaler, 130 * scaler), speedoBG);
            GUIUtility.RotateAroundPivot(45, pivotPoint);
            Rect speedoRect = new Rect(width / 2 + 245 * scaler, -305 * scaler, speedoMeter * 6.4f * scaler, 540 * scaler);
            GUI.DrawTextureWithTexCoords(speedoRect, speedoCol, new Rect(0, 0, speedoMeter / 83f, 1));//83
            GUI.matrix = Matrix4x4.identity;
            //GUI.DrawTexture(new Rect(width / 2 + 150 * scaler, 40, 507 * scaler, 100 * scaler), speedoCol);
            GUI.DrawTexture(new Rect(width / 2 + 250 * scaler, 40, 659 * scaler, 130 * scaler), speedoFG);
            if (SurvivalCollector.health == 8)
            {
                GUI.DrawTexture(new Rect(width / 2 - 370 * scaler, 45 * scaler, 533 * scaler, 90 * scaler), health8);
            }
            else if (SurvivalCollector.health == 7)
            {
                GUI.DrawTexture(new Rect(width / 2 - 370 * scaler, 45 * scaler, 533 * scaler, 90 * scaler), health7);
            }
            else if (SurvivalCollector.health == 6)
            {
                GUI.DrawTexture(new Rect(width / 2 - 370 * scaler, 45 * scaler, 533 * scaler, 90 * scaler), health6);
            }
            else if (SurvivalCollector.health == 5)
            {
                GUI.DrawTexture(new Rect(width / 2 - 370 * scaler, 45 * scaler, 533 * scaler, 90 * scaler), health5);
            }
            else if (SurvivalCollector.health == 4)
            {
                GUI.DrawTexture(new Rect(width / 2 - 370 * scaler, 45 * scaler, 533 * scaler, 90 * scaler), health4);
            }
            else if (SurvivalCollector.health == 3)
            {
                GUI.DrawTexture(new Rect(width / 2 - 370 * scaler, 45 * scaler, 533 * scaler, 90 * scaler), health3);
            }
            else if (SurvivalCollector.health == 2)
            {
                GUI.DrawTexture(new Rect(width / 2 - 370 * scaler, 45 * scaler, 533 * scaler, 90 * scaler), health2);
            }
            else if (SurvivalCollector.health == 1)
            {
                GUI.DrawTexture(new Rect(width / 2 - 370 * scaler, 45 * scaler, 533 * scaler, 90 * scaler), health1);
            }
            else if (SurvivalCollector.health == 0)
            {
                GUI.DrawTexture(new Rect(width / 2 - 370 * scaler, 45 * scaler, 533 * scaler, 90 * scaler), health0);
            }
            //GUI.DrawTexture(new Rect(width - 250 * scaler, height / 2 - 100 * scaler, 200 * scaler, 200 * scaler), jumpRect);
        }
        else if (SurvivalCube.onExit & endCounter >= 100)
        {
            GUI.DrawTexture(new Rect(width / 2 - 455 * scaler, height / 2 - 420 * scaler, 910 * scaler, 586 * scaler), levelEndBG);
            GUIStyle shadowStyle = GUI.skin.GetStyle("label");
            shadowStyle.normal.textColor = textColor;
            shadowStyle.font = arialRounded;
            shadowStyle.fontSize = (int)styleSize;
            GUI.Label(new Rect(width / 2 - 400 * scaler, height / 2 - 300 * scaler, 700 * scaler, 80 * scaler), "YOUR SCORE" + "  " + Mathf.FloorToInt(SurvivalCube.finalScore));
            GUI.Label(new Rect(width / 2 - 400 * scaler, height / 2 - 200 * scaler, 700 * scaler, 80 * scaler), "COLLECTED STARS" + "  " + Mathf.FloorToInt(SurvivalCollector.stars));
            GUI.Label(new Rect(width / 2 - 400 * scaler, height / 2 - 100 * scaler, 700 * scaler, 80 * scaler), "TOTAL STARS" + "  " + Mathf.FloorToInt(SurvivalCollector.totalStars));
            if (blinkTimer >= 0.75f)
            {
                shadowStyle.fontSize = (int)styleSize3;
                GUI.Label(new Rect(width / 2 - 280 * scaler, height / 2 + 303 * scaler, 560 * scaler, 80 * scaler), "TAP TO CONTINUE");
            }
            GUIStyle style = GUI.skin.GetStyle("label");
            style.normal.textColor = yellow;
            style.font = arialRounded;
            style.fontSize = (int)styleSize;
            GUI.Label(new Rect(width / 2 - 403 * scaler, height / 2 - 303 * scaler, 700 * scaler, 80 * scaler), "YOUR SCORE" + "  " + Mathf.FloorToInt(SurvivalCube.finalScore));
            GUI.Label(new Rect(width / 2 - 403 * scaler, height / 2 - 203 * scaler, 700 * scaler, 80 * scaler), "COLLECTED STARS" + "  " + Mathf.FloorToInt(SurvivalCollector.stars));
            GUI.Label(new Rect(width / 2 - 403 * scaler, height / 2 - 103 * scaler, 700 * scaler, 80 * scaler), "TOTAL STARS" + "  " + Mathf.FloorToInt(SurvivalCollector.totalStars));
            if (blinkTimer >= 0.75f)
            {
                style.fontSize = (int)styleSize3;
                GUI.Label(new Rect(width / 2 - 283 * scaler, height / 2 + 300 * scaler, 560 * scaler, 80 * scaler), "TAP TO CONTINUE");
            }
            /* if (Input.touchCount > 0 & FollowCube.onExit | Input.GetKey(KeyCode.Return) & FollowCube.onExit)
             {
                 for (int i = 0; i < MainMenu.scores.Length; i++)
                 {
                     GUI.Label(new Rect(width / 2 - 180 * scaler, (125 + i * 22) * scaler, 300 * scaler, 60 * scaler), MainMenu.scores[i].name);
                     GUI.Label(new Rect(width / 2 - 20 * scaler, (125 + i * 22) * scaler, 300 * scaler, 60 * scaler), MainMenu.scores[i].scoreNum.ToString());
                 }
             }*/
        }
    }
    // Update is called once per frame
    void Update()
    {
        speedoMeter = SurvivalCube.speed;
        if (speedoMeter > 80)
        {
            speedoMeter = 80;
        }
        else if (speedoMeter < 0)
        {
            speedoMeter = 0;
        }
        if (SurvivalCube.onExit)
        {
            endCounter++;
            blinkTimer += Time.deltaTime;
            if (blinkTimer >= 1.5f)
            {
                blinkTimer = 0;
            }
        }

    }
}
