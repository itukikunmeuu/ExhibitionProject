//--------------------------------------
//サウンドの長さを取得する　現状使用の追加をしていないためなし
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SoundLength : MonoBehaviour
{
    //hpバーを入れる
    Slider hpSlider;

    [SerializeField] SongDataBase dataBase;
    string songName;

    // Start is called before the first frame update
    void Start()
    {
        //初期か
        hpSlider = GetComponent<Slider>();
        float maxLength = dataBase.songData[GManager.instance.songID].musicLength;
        float nowLength = 0;

        Debug.Log(maxLength);
        hpSlider.value = nowLength;
    }

    // Update is called once per frame
    void Update()
    {
        //曲の長さを取得してそれに応じて足していく
        hpSlider.value ++;
    }
}
