using UnityEngine;
using System.Collections;

public class PlayerBall : MonoBehaviour {
    public Transform playerBall;
    public Rigidbody cubeBody;
    public MeshRenderer ballRend;
    public Material sticky;
    public Material slippy;
    int rotationForward;
	// Use this for initialization
	void Start () {
        playerBall = GetComponent<Transform>();
        FollowCube cubeBody = GetComponent<FollowCube>();
        ballRend = GetComponent<MeshRenderer>();
        rotationForward = 0;
        if (MainMenu.materialStats[0].music == 1)
        {
            ballRend.material = sticky;
        }
        else if (MainMenu.materialStats[0].music == 2)
        {
            ballRend.material = slippy;
        }
        //playerBall.velocity = new Vector3(playerBall.velocity.x, -16f, 12f);
    }
	
	// Update is called once per frame
	void Update () {
        rotationForward++;
        playerBall.position = new Vector3(cubeBody.position.x, cubeBody.position.y + 0.48f, cubeBody.position.z);
        //playerBall.rotation = new Quaternion(playerBall.rotation.x, cubeBody.rotation.y, playerBall.rotation.z, 0.5f);
        playerBall.Rotate(Time.deltaTime * 420, playerBall.rotation.y, playerBall.rotation.z);
        //playerBall.Rotate(playerBall.rotation.x, cubeBody.rotation.y, playerBall.rotation.z);
        /* if (Input.GetKey(KeyCode.LeftArrow))
         {
             //playerBall.velocity = new Vector3(-12f, playerBall.velocity.y, playerBall.velocity.z);
             playerBall.velocity -= transform.right * 4f;
         }
         if (Input.GetKey(KeyCode.RightArrow))
         {
             playerBall.velocity = new Vector3(12f, playerBall.velocity.y, playerBall.velocity.z);
         }
         if (Input.GetKeyUp(KeyCode.Space))
         {
             playerBall.velocity = new Vector3(playerBall.velocity.x, 1f, playerBall.velocity.z);
         }
         if (Input.GetKey(KeyCode.UpArrow))
         {
             playerBall.velocity = new Vector3(playerBall.velocity.x, playerBall.velocity.y, -7f);
         }
         if (Input.GetKey(KeyCode.UpArrow))
         {
             playerBall.velocity = new Vector3(playerBall.velocity.x, playerBall.velocity.y, 7f);
         }*/
        //playerBall.velocity = new Vector3(playerBall.velocity.x, playerBall.velocity.y - 0.3f, playerBall.velocity.z + 0.05f); //-0.3 & +0.05
    }
}
