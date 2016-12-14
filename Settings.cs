using UnityEngine;
using System.Collections;

public class Settings
{
    public int music;
    public int controls;
	// Use this for initialization
	void Start ()
    {
	
	}
	public Settings(int audio, int controls)
    {
        music = audio;
        this.controls = controls;
    }
	// Update is called once per frame
	void Update ()
    {
	
	}
}
