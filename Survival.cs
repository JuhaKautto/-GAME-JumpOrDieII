using UnityEngine;
using System.Collections;

public class Survival : MonoBehaviour {
    public Transform platform;
    public GameObject platformObj;
    public Transform star;
    public GameObject starObj;
    public Transform ex;
    public GameObject exObj;
    public Transform brake;
    public GameObject brakeObj;
    public Transform followCube;
    float platformY;
    float platformX;
    float platformZ;
    float collX;
    float collY;
    float midX;
    float midY;
    float highX;
    float highY;
    float shiftX;
    float platformTimer;
    float pickupNumber;
    bool pickupRand;
    // Use this for initialization
    void Start () {
        platform = GetComponent<Transform>();
        star = GetComponent<Transform>();
        ex = GetComponent<Transform>();
        FollowCube followCube = GetComponent<FollowCube>();
        platformY = platform.position.y;
        platformX = platform.position.x;
        platformZ = platform.position.z;
        platformTimer = 0;
    }
	
	// Update is called once per frame
	void Update () {
        //print(platformZ + ", " + followCube.position.z + ", " + platformTimer);
        //creates new platforms
        if (platformZ - followCube.position.z < 30f & !SurvivalCube.onExit)
        {
            /*float pickupNumber;
            //one left, one right
            if (even)
                x = Random.Range(-10f, -1f);

            else
                x = Random.Range(1f, 10f);

            even = !even;
            */
            platformZ = platformZ + 188;
            platformY = platformY - 75;
            Instantiate(platformObj, new Vector3(platformX, platformY, platformZ), platform.rotation);
            //creates collectibles on top of the platform
            collX = platformX - 3f;
            collY = platformY - 10f;
            midX = collX - 6f;
            shiftX = 2f;
            midY = collY + 0.5f;
            pickupNumber = Random.Range(1f, 50f);
            if (pickupNumber < 15f | pickupNumber > 40f)
            {
                midX = collX + 6f;
                shiftX = -2f;
            }
            if (pickupNumber < 30f & pickupNumber > 10f | pickupNumber > 35f & pickupNumber < 45f)
            {
                collX = midX + collX;
                midX = collX - midX;
                collX = collX - midX;

                collY = midY + collY;
                midY = collY - midY;
                collY = collY - midY;
            }
            if (pickupNumber < 15f)
                pickupRand = false;

            else if (pickupNumber >= 15f)
                pickupRand = true;

            pickupRand = !pickupRand;

            if (pickupRand)
            {
                Instantiate(starObj, new Vector3(collX, collY, platformZ), star.rotation);
                Instantiate(starObj, new Vector3(collX, collY - 4, platformZ + 10), star.rotation);
                Instantiate(brakeObj, new Vector3(collX, collY - 8, platformZ + 20), brake.rotation);
            }
            else
            {
                Instantiate(exObj, new Vector3(midX, midY, platformZ), ex.rotation);
                Instantiate(exObj, new Vector3(midX + shiftX, midY - 4, platformZ + 10), ex.rotation);
                Instantiate(exObj, new Vector3(midX + shiftX * 2, midY - 8, platformZ + 20), ex.rotation);
            }
        }
        if (platformTimer <= 6.5f)
        {
            platformTimer += Time.deltaTime;
        }
        else
        {
            platformTimer = 0;
        }
    }
}
