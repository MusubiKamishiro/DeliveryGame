using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotateSpeed = new Vector3(0, 0.5f, 0);  // アイコンの回転速度

    // スタートに必要な情報
    [System.Serializable]
    struct PointData
    {
        [SerializeField]
        string name;    // 何を売っているか
        [SerializeField]
        int img;        // 商品画像
        [SerializeField]
        int money;      // 受取金
    }

    [SerializeField]
    PointData[] pointData;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 自身を回転させて目立たせる
        transform.Rotate(rotateSpeed);
    }
}
