//--------------------------------------
//総括してるクラス　これを基底にして曲のIDとか決めてます
//-------------------------------------


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;
    //スコア系
    public float maxScore;
    public float ratioScore;
    //ユーザデータ系
    public int songID;
    public float noteSpeed;
    public int noteOffset;
    //スタートした際のずれを修正するための処理
    public bool Start;
    public float StartTime;
    //コンボやスコアの情報
    public int combo;
    public int score;
    //各タイミングの情報
    public int perfect;
    public int great;
    public int bad;
    public int miss;

    //インスタンスがない場合にそのオブジェクトを削除する
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    
}