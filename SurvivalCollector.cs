using UnityEngine;
using System.Collections;

public class SurvivalCollector : MonoBehaviour {
    public Rigidbody cubeBody;
    public AudioSource sound;
    public AudioClip brake;
    public AudioClip star;
    public AudioClip boost;
    public AudioClip error;
    public AudioClip endJingle;
    public AudioClip silence;
    public static float stars;
    public static float totalStars;
    public static int health;
    // Use this for initialization
    void Start()
    {
        cubeBody = GetComponent<Rigidbody>();
        sound = GetComponent<AudioSource>();
        if (MainMenu.settings[0].music == 0)
        {
            sound.clip = MainMenu.levelTracks[MainMenu.trackNum];
        }
        else if (MainMenu.settings[0].music == 1)
        {
            sound.clip = silence;
        }
        sound.Play();
        sound.loop = true;
        stars = 0;
        health = 8;
        totalStars = PlayerPrefs.GetInt("totalStars");
    }
    void OnTriggerEnter(Collider c)
    {
        //what happens when you collect the token
        if (c.gameObject.tag == "Collectable")
        {
            //print("Yessss");
            sound.PlayOneShot(star, 2.2f);
            SurvivalCube.score = SurvivalCube.score + 6000;
            stars++;
            totalStars++;
            Destroy(c.gameObject);
        }
        if (c.gameObject.tag == "Bad")
        {
            //print("Ouch");
            sound.PlayOneShot(error, 2.3f);
            health--;
            SurvivalCube.score = SurvivalCube.score - 10000;
            Destroy(c.gameObject);
        }
        if (c.gameObject.tag == "Boost")
        {
            //print("BOOST");
            sound.PlayOneShot(boost, 2.3f);
            cubeBody.velocity += transform.forward * 5.5f;
            cubeBody.velocity -= transform.up * 2.5f;
            Destroy(c.gameObject);
        }
        if (c.gameObject.tag == "Brake")
        {
            //print("BRAKE");
            sound.PlayOneShot(brake, 2.3f);
            cubeBody.velocity -= transform.forward * 8f;
            cubeBody.velocity += transform.up * 3.5f;
            Destroy(c.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        /*if (SurvivalCube.onExit)
        {
            sound.Stop();
            sound.clip = silence;
            sound.Play();
            sound.PlayOneShot(endJingle, 2.8f);
        }*/
    }
}
