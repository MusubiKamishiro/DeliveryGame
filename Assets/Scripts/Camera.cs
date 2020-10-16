using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject player;
    private Vector3 oldPlayerPos;

    private float rotateSpeed = 0.5f;       //  回転スピード

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("unitychan");
        
    }

    // Update is called once per frame
    void Update()
    {
        //float angle = Input.GetAxis("Horizontal") * rotateSpeed;
        Vector3 pPos = player.transform.position;
        //transform.position = pPos + offset;
        //transform.RotateAround(pPos, Vector3.up, angle);
    }
}
