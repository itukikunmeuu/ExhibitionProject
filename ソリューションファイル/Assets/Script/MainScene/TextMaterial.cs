//--------------------------------------
//テキストの色変更
//--------------------------------------

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextMaterial : MonoBehaviour
{
    //テキストを入れる
    TextMesh text;

    // Update is called once per frame
    void Update()
    {
        //色の変更
        if (GManager.instance.combo >= 10)
        {
            text.color = Color.green;
        }
        else if (GManager.instance.combo >= 20)
        {
            text.color = Color.yellow;
        }
    }
}
