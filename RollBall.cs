using UnityEngine;
using System.Collections;

public class RollBall : MonoBehaviour {
    public Transform playerBall;
    public Rigidbody cubeBody;
    int rotationForward;
    // Use this for initialization
    void Start () {
        playerBall = GetComponent<Transform>();
        FollowCube cubeBody = GetComponent<FollowCube>();
        rotationForward = 20;
    }
	
	// Update is called once per frame
	void Update () {
        //rotationForward++;
        //print(rotationForward);
        //playerBall.rotation = new Quaternion(rotationForward, playerBall.rotation.y, playerBall.rotation.z, -0.5f);
    }
}
