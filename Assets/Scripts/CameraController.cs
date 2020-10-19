using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private GameObject mainCamera;
    private Vector3 offset;                 //  キャラクターとカメラとのオフセット
    private Vector3 playerPos;
    private float rotateSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("unitychan");
        offset = new Vector3(0, 3, -3);
        playerPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += player.transform.position - playerPos;
        playerPos = player.transform.position;

        if(Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.X))
        {
            AngleUpdate();
        }
    }

    void AngleUpdate()
    {
        if(Input.GetKey(KeyCode.Z))
        {
            transform.RotateAround(playerPos, Vector3.up,rotateSpeed);
        }
        if (Input.GetKey(KeyCode.X))
        {
            transform.RotateAround(playerPos, Vector3.up, -rotateSpeed);
        }
    }
}
