using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //animator.SetFloat("Horizontal", x);
        //animator.SetFloat("Vertical", z);

        // 左スティックの情報をもとにキャラの向きの変更と移動
        rb.velocity = new Vector3(x * 10, -3, z * 10);
        if ((x != 0) || (z != 0))
        {
            Vector3 direction = new Vector3(x, 0, z);
            transform.localRotation = Quaternion.LookRotation(direction);
        }
    }
}
