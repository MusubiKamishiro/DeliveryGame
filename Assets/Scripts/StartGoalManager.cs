using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGoalManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] startObjects;      // スタート地点のオブジェクト群
    [SerializeField]
    GameObject[] goalObjects;       // ゴール地点のオブジェクト群

    [SerializeField]
    int courseMax = 3;              // フィールド上に出現するコースの最大数

    private int courseCount = 0;    // フィールド上に出現しているコース数

    private bool startFlag = true;  // ゲーム開始時にスタート地点を設定する際に使用

    // Start is called before the first frame update
    void Start()
    {
        // ステージに設置されてあるスタート地点、ゴール地点を非アクティブ状態にする
        InitPoints(ref startObjects, "Start");
        InitPoints(ref goalObjects, "Goal");
        //InitObjects(startObjects, "Start");
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
        if(Time.time >= 5.0f && startFlag)
		{
            for(int i = 0;  i < courseMax; ++i)
			{
                AppearStartPoint();
            }

            startFlag = false;
        }



        Debug.Log("経過時間" + Time.time);
	}

    // ランダムにスタート地点を出現させる
    void AppearStartPoint()
	{
        while(true)
		{
            int p = Random.Range(0, startObjects.Length);

            if (startObjects[p].activeInHierarchy == false)
            {
                startObjects[p].SetActive(true);
                ++courseCount;

                break;
            }
        }
    }
}
