using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private GameObject mainCamera;
    private Vector3 offset;                 //  キャラクターとカメラとのオフセット

    private Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("unitychan");
        offset = new Vector3(0, 1, -2);

        playerPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Transform _transform = player.transform;
        //Vector3 forward = _transform.forward;

        //Debug.Log(forward);

        //transform.position = offset + player.transform.position;
        //if(forward.z > 2)
        //{

        //}

        //transform.rotation = player.transform.rotation;

        transform.position += _transform.position - playerPos;
        playerPos = _transform.position;
    }
}
