//-------------------------------------
//ノーツの処理
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    //ノーツのスピードを設定
    float NoteSpeed = 8;
    bool start;

    void Start()
    {
        NoteSpeed = GManager.instance.noteSpeed;
    }
    void Update()
    {
        //スペースが押されたらtrueにする
        if (Input.GetKeyDown(KeyCode.Space))
        {
            start = true;
        }
        //ノーツを加算しておろす処理
        if (start)
        {
            transform.position -= transform.forward * Time.deltaTime * NoteSpeed;
        }
        //エスケープボタンで止める
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            start = false;
        }
    }
}