//------------------------------------------------------
//最終コンボ数に応じて表示するオブジェクトを変更する処理
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboText : MonoBehaviour
{
    //オブジェクトを入れる
    [SerializeField] GameObject crearComboObj;
    [SerializeField] GameObject fullComboObj;
    [SerializeField] GameObject allParfect;
    // Update is called once per frame
    void Update()
    {
        //GManagerのmissが0なら次へ
        if(GManager.instance.miss == 0)
        {
            //GManagerのbadが0なら次へ
            if(GManager.instance.bad == 0)
            {
                //現状ならFullComboを表示する
                fullComboObj.SetActive(true);
                if(GManager.instance.great == 0)
                {
                    allParfect.SetActive(true);
                    fullComboObj.SetActive(false);
                }
            }
        }
        else
        {
            crearComboObj.SetActive(true);
        }
    }
}
