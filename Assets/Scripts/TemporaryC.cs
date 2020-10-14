using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporaryC : MonoBehaviour
{
    public GameObject player;
    
    private float smoothing = 10.0f;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        var ppos = player.transform.position;
        
        // カメラをターゲットに追従
        Vector3 targetCamPos = player.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, 
                            targetCamPos, Time.deltaTime * smoothing);

        //// プレイヤーがダメージを受けるとフラグがtrueになる
        //// フラグは一定時間が経つと自動的にfalseになる
        //float x = 0;
        //float y = 0;
        //if (ps.shakeFlag)
        //{
        //    x = Random.Range(-5, 5);
        //    y = Random.Range(-5, 5);
        //}
        //// カメラの角度をずらす
        //transform.eulerAngles = new Vector3(46.8f + x, 
        //                    player.GetComponent<Player>().GetAngle + y);
    }
}
