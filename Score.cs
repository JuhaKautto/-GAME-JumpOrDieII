using UnityEngine;
using System.Collections;

public class Score
{
    public int scoreNum;
    public string name;
    // Use this for initialization
    void Start()
    {

    }
    public Score(int score, string name)
    {
        scoreNum = score;
        this.name = name;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
