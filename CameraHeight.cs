using UnityEngine;
using System.Collections;

public class CameraHeight : MonoBehaviour {
    public Transform cameraBody;
    public Rigidbody camRigidBdy;
    public Rigidbody playerBall;
	// Use this for initialization
	void Start () {
        cameraBody = GetComponent<Transform>();
        PlayerBall playerBall = GetComponent<PlayerBall>();
        camRigidBdy = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!FollowCube.onFinishArea & !FollowCube.onExit)
        {
            cameraBody.position = new Vector3(cameraBody.position.x, playerBall.position.y + 4f, cameraBody.position.z);
        }
        else if(FollowCube.onFinishArea & !FollowCube.onExit)
        {
            cameraBody.position = new Vector3(playerBall.position.x + 8f, playerBall.position.y + 2.5f, playerBall.position.z + 16f);
        }
        else if (FollowCube.onExit & !FollowCube.onFinishArea)
        {
            camRigidBdy.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }
        //print(playerBall.position.y);
	}
}
