using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Directions : MonoBehaviour
{
    [SerializeField]
    Transform target;       // 目的地

    [SerializeField]
    Transform cursor;       // 目的地へ向かうために見る矢印

    [SerializeField]
    NavMeshAgent agent;     // ナビメッシュを敷いたステージ


    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(target.position);  // 目的地を設定
        agent.updateRotation = false;
        agent.updatePosition = false;
    }

    // Update is called once per frame
    void Update()
    {
        // カーソルの角度を目的地の方角へ向ける
        cursor.rotation = Quaternion.LookRotation(agent.steeringTarget - transform.position, Vector3.right);
        agent.nextPosition = transform.position;
    }
}
