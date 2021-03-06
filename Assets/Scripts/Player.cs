﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    private float inputH;
    private float inputV;

    private float speed = 8.0f;

    private string carryFood;    // 運んでる商品
    private int score;

    // 音関係
    AudioSource audioSource;
    public AudioClip shopSound;
    public AudioClip clearSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //// 左スティックの情報をもとにキャラの向きの変更と移動
        //rb.velocity = new Vector3(x * 10, -3, z * 10);
        //if ((x != 0) || (z != 0))
        //{
        //    Vector3 direction = new Vector3(x, 0, z);
        //    transform.localRotation = Quaternion.LookRotation(direction);
        //}

        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");

        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * inputV + Camera.main.transform.right * inputH;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rb.velocity = moveForward * speed + new Vector3(0, rb.velocity.y, 0);

        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }

    public void AddScore(int inscore)
    {
        score += inscore;
        Debug.Log("現在のスコア:" + score);
    }

    public void SetCarryFood(string foodname)
    {
        carryFood = foodname;

        Debug.Log("もった食べ物:" + carryFood);
    }

    public string GetCarryFood()
    {
        return carryFood;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Start")
        {
            audioSource.PlayOneShot(shopSound);
        }

        if (collision.gameObject.tag == "Goal" && GetCarryFood() != null)
        {
            audioSource.PlayOneShot(clearSound);
        }
    }
}
