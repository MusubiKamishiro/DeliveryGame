using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGoalManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] startObjects;      // スタート地点のオブジェクト


    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        // ステージに設置されてあるスタート地点を検索し、非アクティブ状態にする
        startObjects = GameObject.FindGameObjectsWithTag("Start");
        for(int i = 0; i < startObjects.Length; ++i)
		{
            startObjects[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown("joystick button 0"))
		{
			startObjects[count].SetActive(true);
            count++;
		}
	}
}
