using UnityEngine;
using System.Collections;

public class ballScript : MonoBehaviour {
    public Transform playerBall;
    public Transform cam;
    float x;
    float x2;
    float x3;
    float x4;
    float part;
    float v;
	// Use this for initialization
	void Start () {
        playerBall = GetComponent<Transform>();
        cam = GetComponent<Transform>();
        x = 0f;
        x2 = 0f;
        x3 = 0f;
        x4 = 0f;
        part = 2f / 3f;
        v = 4f + part;
        if (MainMenu.materialStats[0].music == 1)
        {
            playerBall.localPosition = new Vector3(playerBall.localPosition.x - 7f, playerBall.localPosition.y, playerBall.localPosition.z);
        }
        if (MainMenu.materialStats[0].music == 2)
        {
            playerBall.localPosition = new Vector3(playerBall.localPosition.x - 14f, playerBall.localPosition.y, playerBall.localPosition.z);
        }
    }
	
	// Update is called once per frame
	void Update () {
        playerBall.Rotate(Time.deltaTime * -330, playerBall.rotation.y, playerBall.rotation.z);
        //playerBall.position = new Vector3(cam.position.x, cam.position.y, z);
        //print(part + " " + x + " " + x2 + " " + x3 + " " + x4 + " " + BallSelect.zeroToOne + " " + BallSelect.oneToTwo + " " + BallSelect.twoToOne + " " + BallSelect.oneToZero);
        if (BallSelect.zeroToOne)
        {
            
            if (x < 1.5f)
            {
                x += Time.deltaTime;
                playerBall.localPosition = new Vector3(playerBall.localPosition.x - Time.deltaTime * v, playerBall.localPosition.y, playerBall.localPosition.z);
            }
            else if (x >= 1.5f)
            {
                x = 0f;
                x2 = 0f;
                x3 = 0f;
                x4 = 0f;
                BallSelect.zeroToOne = false;
            }
            
        }
        if (BallSelect.oneToTwo)
        {
            
            if (x2 < 1.5f)
            {
                x2 += Time.deltaTime;
                playerBall.localPosition = new Vector3(playerBall.localPosition.x - Time.deltaTime * v, playerBall.localPosition.y, playerBall.localPosition.z);
            }
            else if (x2 >= 1.5f)
            {
                x = 0f;
                x2 = 0f;
                x3 = 0f;
                x4 = 0f;
                BallSelect.oneToTwo = false;
            }
        }
        if (BallSelect.twoToOne)
        {

            if (x3 < 1.5f)
            {
                x3 += Time.deltaTime;
                playerBall.localPosition = new Vector3(playerBall.localPosition.x + Time.deltaTime * v, playerBall.localPosition.y, playerBall.localPosition.z);
            }
            else if (x3 >= 1.5f)
            {
                x = 0f;
                x2 = 0f;
                x3 = 0f;
                x4 = 0f;
                BallSelect.twoToOne = false;
            }
        }
        if (BallSelect.oneToZero)
        {

            if (x4 < 1.5f)
            {
                x4 += Time.deltaTime;
                playerBall.localPosition = new Vector3(playerBall.localPosition.x + Time.deltaTime * v, playerBall.localPosition.y, playerBall.localPosition.z);
            }
            else if (x4 >= 1.5f)
            {
                x = 0f;
                x2 = 0f;
                x3 = 0f;
                x4 = 0f;
                BallSelect.oneToZero = false;
            }
        }
        if (!BallSelect.zeroToOne)
        {
            x = 0f;
        }
        if (!BallSelect.oneToTwo)
        {
            x2 = 0f;
        }
        if (!BallSelect.twoToOne)
        {
            x3 = 0f;
        }
        if (!BallSelect.oneToZero)
        {
            x4 = 0f;
        }
    }
}
