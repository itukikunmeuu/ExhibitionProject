//--------------------------------------
//マテリアルの色を変更する
//-------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialColor : MonoBehaviour
{
    //変更
    int color = 0;
    bool isStartFlag = false;
    // Update is called once per frame
    void Update()
    {
        //Flagが変わったら以下の処理に入る
        if (isStartFlag == false)
        {
            //左右でカラーの色を変更する
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (color > 0)
                {
                    color -= 1;
                }
                else
                {
                    color = 3;
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (color < 3)
                {
                    color += 1;
                }
                else
                {
                    color = 0;
                }
            }
        }
        //スペースで決定
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isStartFlag = true;
        }
        //カラーの色を変更する
        if (color == 0)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else if (color == 1)
        {
            GetComponent<Renderer>().material.color = Color.cyan;
        }
        else if (color == 2)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else if (color == 3)
        {
            GetComponent<Renderer>().material.color = Color.magenta;
        }
    }
}
