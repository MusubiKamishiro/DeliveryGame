using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] shopObjects;      // スタート地点のオブジェクト群
    [SerializeField]
    GameObject[] goalObjects;       // ゴール地点のオブジェクト群

    [SerializeField]
    const int courseMax = 3;        // フィールド上に出現するコースの最大数

    [SerializeField]
    const int foodMax = 3;          // 客が注文する料理の最大品数 

    // コース作成に必要なデータ
    struct courseData
    {
        public GameObject[] shopObjects;
        public GameObject goalObject;
        int foodCount;
	}

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
            for(int j = 0; j < courses[i].shopObjects.Length; ++j)
            {
                Debug.Log("スタート位置[" + j + "]：" + courses[i].shopObjects[j].name);
            }

            Debug.Log("ゴール位置：" + courses[i].goalObject.name);
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
        courses[courseCount].goalObject = goalObjects[p];

        // 客の頼む商品の決定
        int foodCount = UnityEngine.Random.Range(1, foodMax);


        // 商品を売ってる位置をスタートとする
        courses[courseCount].shopObjects = new GameObject[foodCount];
        for(int i = 0; i < foodCount; ++i)
        {
            p = SelectPoint(ref shopObjects);
            courses[courseCount].shopObjects[i] = shopObjects[p];
        }
                
        ++courseCount;
    }
}
