using UnityEngine;
using System.Collections;

public class DemoUI : MonoBehaviour
{
    public Font arialRounded;
    public Color textColor = new Color(0.2F, 0.3F, 0.4F, 0.5F);
    public Color yellow = new Color(0.2F, 0.3F, 0.4F, 0.5F);
    public Texture scoreBG;
    public Texture logo;
    float styleSize;
    float styleSize2;
    float styleSize3;
    float styleSize4;
    float blinkTimer;
    float sequencer;
    float width;
    float height;
    float scaler;
    // Use this for initialization
    void Start()
    {
        width = Screen.width;
        height = Screen.height;
        scaler = width / 1920f;
        blinkTimer = 0;
        sequencer = 0;
        styleSize = 45f * scaler;
        styleSize2 = 33f * scaler;
        styleSize3 = 50f * scaler;
        styleSize4 = 55f * scaler;
    }
    void OnGUI()
    {
        GUIStyle ShadowStyle = GUI.skin.GetStyle("label");
        ShadowStyle.normal.textColor = textColor;
        ShadowStyle.font = arialRounded;
        ShadowStyle.fontSize = (int)styleSize4;
        if (sequencer < 15f | sequencer >= 35f)
        {
            GUI.DrawTexture(new Rect(width / 2 - 300 * scaler, 30 * scaler, 600 * scaler, 300 * scaler), logo);
            if (blinkTimer >= 0.75f)
            {
                GUI.Label(new Rect(width / 2 - 197f * scaler, 703f * scaler, 400 * scaler, 90 * scaler), "TAP TO START", ShadowStyle);
            }
        }
        ShadowStyle.fontSize = (int)styleSize;
        if (sequencer >= 15f & sequencer < 20f)
        {
            GUI.Label(new Rect(width / 2 - 157.5f * scaler, 32.5f * scaler, 320 * scaler, 100 * scaler), "HIGH SCORES", ShadowStyle);
            ShadowStyle.fontSize = (int)styleSize3;
            GUI.Label(new Rect(width / 2 - 67.5f * scaler, 72.5f * scaler, 140 * scaler, 100 * scaler), "EASY", ShadowStyle);
            GUI.DrawTexture(new Rect(width / 2 - 335f * scaler, 140f * scaler, 670 * scaler, 670 * scaler), scoreBG);
        }
        else if (sequencer >= 20f & sequencer < 25f)
        {
            GUI.Label(new Rect(width / 2 - 157.5f * scaler, 32.5f * scaler, 320 * scaler, 100 * scaler), "HIGH SCORES", ShadowStyle);
            ShadowStyle.fontSize = (int)styleSize3;
            GUI.Label(new Rect(width / 2 - 107.5f * scaler, 72.5f * scaler, 220 * scaler, 100 * scaler), "MEDIUM", ShadowStyle);
            GUI.DrawTexture(new Rect(width / 2 - 335f * scaler, 140f * scaler, 670 * scaler, 670 * scaler), scoreBG);
        }
        else if (sequencer >= 25f & sequencer < 30f)
        {
            GUI.Label(new Rect(width / 2 - 157.5f * scaler, 32.5f * scaler, 320 * scaler, 100 * scaler), "HIGH SCORES", ShadowStyle);
            ShadowStyle.fontSize = (int)styleSize3;
            GUI.Label(new Rect(width / 2 - 72.5f * scaler, 72.5f * scaler, 150 * scaler, 100 * scaler), "HARD", ShadowStyle);
            GUI.DrawTexture(new Rect(width / 2 - 335f * scaler, 140f * scaler, 670 * scaler, 670 * scaler), scoreBG);
        }
        else if (sequencer >= 30f & sequencer < 35f)
        {
            GUI.Label(new Rect(width / 2 - 157.5f * scaler, 32.5f * scaler, 320 * scaler, 100 * scaler), "HIGH SCORES", ShadowStyle);
            ShadowStyle.fontSize = (int)styleSize3;
            GUI.Label(new Rect(width / 2 - 127.5f * scaler, 72.5f * scaler, 260 * scaler, 100 * scaler), "SURVIVAL", ShadowStyle);
            GUI.DrawTexture(new Rect(width / 2 - 335f * scaler, 140f * scaler, 670 * scaler, 670 * scaler), scoreBG);
        }
        GUIStyle scoreStyle = GUI.skin.GetStyle("label");
        scoreStyle.normal.textColor = yellow;
        scoreStyle.font = arialRounded;
        scoreStyle.fontSize = (int)styleSize2;
        if (sequencer >= 15f & sequencer < 20f)
        {
            for (int i = 0; i < MainMenu.scores.Length; i++)
            {
                GUI.Label(new Rect(width / 2 - 280 * scaler, (145 + i * 32) * scaler, 500 * scaler, 60 * scaler), MainMenu.scores[i].name);
                GUI.Label(new Rect(width / 2 - 40 * scaler, (145 + i * 32) * scaler, 500 * scaler, 60 * scaler), MainMenu.scores[i].scoreNum.ToString());
            }
        }
        else if (sequencer >= 20f & sequencer < 25f)
        {
            for (int i = 0; i < MainMenu.scores2.Length; i++)
            {
                GUI.Label(new Rect(width / 2 - 280 * scaler, (145 + i * 32) * scaler, 500 * scaler, 60 * scaler), MainMenu.scores2[i].name);
                GUI.Label(new Rect(width / 2 - 40 * scaler, (145 + i * 32) * scaler, 500 * scaler, 60 * scaler), MainMenu.scores2[i].scoreNum.ToString());
            }
        }
        else if (sequencer >= 25f & sequencer < 30f)
        {
            for (int i = 0; i < MainMenu.scores3.Length; i++)
            {
                GUI.Label(new Rect(width / 2 - 280 * scaler, (145 + i * 32) * scaler, 500 * scaler, 60 * scaler), MainMenu.scores3[i].name);
                GUI.Label(new Rect(width / 2 - 40 * scaler, (145 + i * 32) * scaler, 500 * scaler, 60 * scaler), MainMenu.scores3[i].scoreNum.ToString());
            }
        }
        else if (sequencer >= 30f & sequencer < 35f)
        {
            for (int i = 0; i < MainMenu.survivalScores.Length; i++)
            {
                GUI.Label(new Rect(width / 2 - 280 * scaler, (145 + i * 32) * scaler, 500 * scaler, 60 * scaler), MainMenu.survivalScores[i].name);
                GUI.Label(new Rect(width / 2 - 40 * scaler, (145 + i * 32) * scaler, 500 * scaler, 60 * scaler), MainMenu.survivalScores[i].scoreNum.ToString());
            }
        }
        GUIStyle style = GUI.skin.GetStyle("label");
        style.normal.textColor = yellow;
        style.font = arialRounded;
        //draw texts
        if (sequencer < 15f | sequencer >= 35f)
        {
            if (blinkTimer >= 0.75f)
            {
                style.fontSize = (int)styleSize4;
                GUI.Label(new Rect(width / 2 - 200 * scaler, 700 * scaler, 400 * scaler, 90 * scaler), "TAP TO START", style);
            }
        }
        style.fontSize = (int)styleSize;
        if (sequencer >= 15f & sequencer < 20f)
        {
            GUI.Label(new Rect(width / 2 - 160f * scaler, 30f * scaler, 320 * scaler, 100 * scaler), "HIGH SCORES", style);
            style.fontSize = (int)styleSize3;
            GUI.Label(new Rect(width / 2 - 70f * scaler, 70f * scaler, 140 * scaler, 100 * scaler), "EASY", style);
        }
        else if (sequencer >= 20f & sequencer < 25f)
        {
            GUI.Label(new Rect(width / 2 - 160f * scaler, 30f * scaler, 320 * scaler, 100 * scaler), "HIGH SCORES", style);
            style.fontSize = (int)styleSize3;
            GUI.Label(new Rect(width / 2 - 110f * scaler, 70f * scaler, 220 * scaler, 100 * scaler), "MEDIUM", style);
        }
        else if (sequencer >= 25f & sequencer < 30f)
        {
            GUI.Label(new Rect(width / 2 - 160f * scaler, 30f * scaler, 320 * scaler, 100 * scaler), "HIGH SCORES", style);
            style.fontSize = (int)styleSize3;
            GUI.Label(new Rect(width / 2 - 75f * scaler, 70f * scaler, 150 * scaler, 100 * scaler), "HARD", style);
        }
        else if (sequencer >= 30f & sequencer < 35f)
        {
            GUI.Label(new Rect(width / 2 - 160f * scaler, 30f * scaler, 320 * scaler, 100 * scaler), "HIGH SCORES", style);
            style.fontSize = (int)styleSize3;
            GUI.Label(new Rect(width / 2 - 130f * scaler, 70f * scaler, 260 * scaler, 100 * scaler), "SURVIVAL", style);
        }
    }
    // Update is called once per frame
    void Update()
    {
        blinkTimer += Time.deltaTime;
        sequencer += Time.deltaTime;
        if (blinkTimer >= 1.5f)
        {
            blinkTimer = 0;
        }
    }
}



