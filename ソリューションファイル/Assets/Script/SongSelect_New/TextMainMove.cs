//-------------------------------------
//テキストを横に動かす処理
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMainMove : MonoBehaviour
{
    //スピードを決める処理
    float speed = 10.0f;
    void Update()
    {
        transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        if (transform.position.x <= -25)
        {
            Destroy(gameObject);
        }
    }
}
