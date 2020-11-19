﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private GameObject mainCamera;
    private float offset = 3.0f;                 //  キャラクターとカメラとのオフセット
    private Vector3 playerPos;
    private float rotateSpeed = 3.0f;



    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("unitychan");
        playerPos = player.transform.position;
        transform.position = playerPos - transform.rotation * Vector3.forward * offset;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += player.transform.position - playerPos;
        playerPos = player.transform.position;

        if(Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.X) || (Input.GetAxis("Horizontal2") != 0))
        {
            AngleUpdate();
        }
    }

    void AngleUpdate()
    {
        //  右スティックの横の傾き
        float inputH = Input.GetAxis("Horizontal2");

        //  左に向ける
        if (Input.GetKey(KeyCode.Z) || inputH < 0)
        {
            transform.RotateAround(playerPos, Vector3.up,-rotateSpeed);
        }
        //  右に向ける
        if (Input.GetKey(KeyCode.X) || inputH > 0)
        {
            transform.RotateAround(playerPos, Vector3.up, rotateSpeed);
        }

        //  プレイヤーが向いている方向にカメラを合わせる
        if (Input.GetKey(KeyCode.C))
        {

        }
    }
}
