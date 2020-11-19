﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseManager : MonoBehaviour
{
    // コース作成に必要なデータ
    struct courseData
    {
        public GameObject shopObject;   // スタート地点(店)
        public GameObject houseObject;  // ゴール地点(家)
        // 客名
        // 店名
        // 注文料理[複数形]
        // 距離
    }

    [SerializeField]
    GameObject[] shopObjects;       // スタート地点のオブジェクト群
    [SerializeField]
    GameObject[] goalObjects;       // ゴール地点のオブジェクト群

    [SerializeField]
    const int courseMax = 3;        // フィールド上に出現するコースの最大数

    [SerializeField]
    const int foodMax = 3;          // 客が注文する料理の最大品数 

    private courseData[] courses = new courseData[courseMax];   // フィールド上に出現しているコースデータ
    private int courseCount = 0;    // フィールド上に出現しているコース数

    private bool startFlag = true;  // ゲーム開始時にスタート地点を設定する際に使用

    // Start is called before the first frame update
    void Start()
    {
        // ステージに設置されてあるスタート地点、ゴール地点を非アクティブ状態にする
        InitPoints(ref shopObjects, "Start");
        InitPoints(ref goalObjects, "Goal");
    }


    // ステージに設置してあるポイントを探し、非アクティブ状態にする
    //@param objects    探すオブジェクト群
    //@param tagName    オブジェクトにつけてるタグの名前
    void InitPoints(ref GameObject[] objects, string tagName)
	{
        objects = GameObject.FindGameObjectsWithTag(tagName);
        Debug.Log("ステージに設置されてある" + tagName + "Point：" + objects.Length);
        for (int i = 0; i < objects.Length; ++i)
        {
            objects[i].SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        // 開始5秒後にランダムにスタート地点を出現させる
        if(/*Time.time >= 5.0f &&*/ startFlag)
		{
            for(int i = 0;  i < courseMax; ++i)
			{
                if(courseCount < courseMax)
                {
                    CreateCourse();
                }
                
            }

            startFlag = false;
        }

        // 出現しているコースのデバッグ表示用
        for (int i = 0; i < courses.Length; ++i)
        {
            Debug.Log("コース" + i);
            Debug.Log("スタート位置：" + courses[i].shopObject.name);
            Debug.Log("ゴール位置：" + courses[i].houseObject.name);
            //Debug.Log("店名：" + courses[i].shopObject.GetComponentInChildren<StartPoint>.get);
        }
	}

    // ランダムにスタートやゴール地点を選ぶ
    // すでに出現している場合は別の場所を選択させる
    int SelectPoint(ref GameObject[] objects)
	{
        while (true)
		{
            int p = UnityEngine.Random.Range(0, objects.Length);

            if (objects[p].activeInHierarchy == false)
            {
                objects[p].SetActive(true);

                return p;
            }
        }
    }

    // コースの作成
    void CreateCourse()
    {
        // ゴールの位置を決定
        int p = SelectPoint(ref goalObjects);
        courses[courseCount].houseObject = goalObjects[p];

        // 客の頼む商品の決定
        


        // 商品を売ってる位置をスタートとする
        p = SelectPoint(ref shopObjects);
        courses[courseCount].shopObject = shopObjects[p];
        
        // コースが完成したのでカウントを増やす
        ++courseCount;
    }
}
