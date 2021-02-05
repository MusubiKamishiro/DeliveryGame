using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPoint : MonoBehaviour
{
    [SerializeField]
    GameObject courseManager;

    [SerializeField]
    string houseName;   // 家(マンション)の名前

    // Start is called before the first frame update
    void Start()
    {
        courseManager = GameObject.Find("GameObject");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter(Collision collision)
	{
        // プレイヤーと接触したらプレイヤーから商品情報を受け取ってスコアを加算
        if (collision.gameObject.tag == "Player")
        {
            if(collision.gameObject.GetComponent<Player>().GetCarryFood() != null)
            {
                collision.gameObject.GetComponent<Player>().SetCarryFood(null);
                collision.gameObject.GetComponent<Player>().AddScore(100);

                gameObject.SetActive(false);

                courseManager.GetComponent<CourseManager>().CreateCourse(0);
            }
        }
    }
}
