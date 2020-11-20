using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotateSpeed = new Vector3(0, 0.5f, 0);  // アイコンの回転速度

    [SerializeField]
    private string shopName;    // 店名
    [SerializeField]
    int shippingCharges;        // 配送手数料

    // 商品情報
    [System.Serializable]
    struct MenuData
    {
        [SerializeField]
        string name;            // 商品名
        [SerializeField]
        int img;                // 商品画像
        [SerializeField]
        int price;              // 販売値段
        [SerializeField]
        int maxBuyCount;        // 最大購入数
    }

    [SerializeField]
    MenuData[] menuData;

    
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

    string GetShopName()
    {
        return shopName;
	}
}
