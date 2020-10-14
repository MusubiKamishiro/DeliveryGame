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
        offset = new Vector3(0, 1, 2);
        transform.position = player.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        Transform _transform = player.transform;
        Vector3 forward = _transform.forward;

        //playerPos = player.transform.position;

        //transform.position = offset + playerPos;

        transform.rotation = player.transform.rotation;

        //transform.RotateAround(playerPos,new Vector3(1,0,0),oldPPos.x - playerPos.x * Time.deltaTime);

        //if(playerPos != oldPPos)
        //{
        //    transform.RotateAround(playerPos, new Vector3(0, 1, 0), oldPPos.x - playerPos.x);
        //}

        //Debug.Log(player.transform.forward);

        //oldPPos = playerPos;

        //transform.position += _transform.position - playerPos;
        //playerPos = _transform.position;
    }
}
