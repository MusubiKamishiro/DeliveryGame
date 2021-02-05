using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
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
        int calorie;            // カロリー
        [SerializeField]
        int maxBuyCount;        // 最大購入数
    }

    [SerializeField]
    private MenuData[] menuData;

    [SerializeField]
    string foodName;

    GameObject directions;

    // Start is called before the first frame update
    void Start()
    {
        directions = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter(Collision collision)
	{
        // プレイヤーと接触したらプレイヤーに商品情報を渡す
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().SetCarryFood(foodName);
            directions.GetComponentInChildren<Directions>().ChangeTarget();
            gameObject.SetActive(false);
        }
    }


	string GetShopName()
    {
        return shopName;
	}
}
