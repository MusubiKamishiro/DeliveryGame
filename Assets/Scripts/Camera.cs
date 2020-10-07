using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;         //  キャラクターとカメラとのオフセット

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("unitychan");
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z - 2);
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offset + player.transform.position;
    }
}
