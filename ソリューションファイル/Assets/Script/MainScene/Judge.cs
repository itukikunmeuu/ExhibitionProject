//-------------------------------------
//判定の処理
//--------------------------------------
using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
public class Judge : MonoBehaviour
{
    //変数の宣言
    [SerializeField] private GameObject[] MessageObj;//プレイヤーに判定を伝えるゲームオブジェクト
    [SerializeField] private GameObject[] FastSlowObj; //プレイヤーに判定の早いか遅いを伝えるゲームオブジェクト
    [SerializeField] NotesManager notesManager;//スクリプト「notesManager」を入れる変数
    //テキストを入れるオブジェクト
    [SerializeField] TextMeshProUGUI comboText;
    [SerializeField] TextMeshProUGUI parfectText;
    [SerializeField] TextMeshProUGUI greatText;
    [SerializeField] TextMeshProUGUI badText;
    [SerializeField] TextMeshProUGUI missText;
    [SerializeField] TextMeshProUGUI scoreText;

    //終わった際にオブジェクトの表示
    [SerializeField] GameObject finish;
    //当たった時にオブジェクトを入れる変数
    [SerializeField] GameObject hitPrefab;
    //曲を入れるオブジェクト
    AudioSource audio;
    //当たった時にサウンドが鳴る
    [SerializeField] AudioClip hitSound;
    //変数
    float endTime = 0;
    int noteNo;
   
    void Start()
    {
        //初期化
        audio = GetComponent<AudioSource>();
        endTime = notesManager.NotesTime[notesManager.NotesTime.Count - 1];
    }
    void Update()
    {
        //GManagerのStartが変更されたら以下の処理をする
        if (GManager.instance.Start)
        {
            if (Input.GetKeyDown(KeyCode.D))//Dキーが押されたとき
            {
                if (notesManager.LaneNum[0] == 0)//押されたボタンはレーンの番号とあっているか？
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 0);
                }
                else
                {
                    if (notesManager.LaneNum[1] == 0)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)), 1);
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.F))//Fキーが押されたとき
            {
                if (notesManager.LaneNum[0] == 1)//押されたボタンはレーンの番号とあっているか？
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 0);
                }
                else
                {
                    if (notesManager.LaneNum[1] == 1)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)), 1);
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.J))//Jキーが押されたとき
            {
                if (notesManager.LaneNum[0] == 2)//押されたボタンはレーンの番号とあっているか？
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 0);
                }
                else
                {
                    if (notesManager.LaneNum[1] == 2)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)), 1);
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.K))//Kキーが押されたとき
            {
                if (notesManager.LaneNum[0] == 3)//押されたボタンはレーンの番号とあっているか？
                {
                    Judgement(GetABS(Time.time - (notesManager.NotesTime[0] + GManager.instance.StartTime)), 0);
                }
                else
                {
                    if (notesManager.LaneNum[1] == 3)
                    {
                        Judgement(GetABS(Time.time - (notesManager.NotesTime[1] + GManager.instance.StartTime)), 1);
                    }
                }
            }
            //終了時に行う処理
            if (Time.time > endTime + GManager.instance.StartTime)
            {
                finish.SetActive(true);
                Invoke("ResultScene", 6f);
                return;
            }

            if (Time.time > notesManager.NotesTime[0] + 0.2f + GManager.instance.StartTime)//本来ノーツをたたくべき時間から0.2秒たっても入力がなかった場合
            {
                message(3);
                deleteData(0);
                Debug.Log("Miss");
                GManager.instance.miss++;
                GManager.instance.combo = 0;
                //ミス
            }
        }
    }
    void Judgement(float timeLag, int numOffset)
    {
        
        if (timeLag <= 0.05)//本来ノーツをたたくべき時間と実際にノーツをたたいた時間の誤差が0.1秒以下だったら
        {
            Debug.Log("Perfect");
            message(0);
            hit();
            GManager.instance.ratioScore += 5;
            GManager.instance.perfect++;
            GManager.instance.combo++;
            deleteData(numOffset);
            audio.PlayOneShot(hitSound);
            //パーフェクト
        }
        else
        {
            if (timeLag <= 0.10)//本来ノーツをたたくべき時間と実際にノーツをたたいた時間の誤差が0.15秒以下だったら
            {
                Debug.Log("Great");
                message(1);
                hit();
                GManager.instance.ratioScore += 3;
                GManager.instance.great++;
                GManager.instance.combo++;
                deleteData(numOffset);
                audio.PlayOneShot(hitSound);

                //if(timeLag <= 0.08)
                //{
                //    fastSlow(0);
                //}
                //else
                //{
                //    fastSlow(1);
                //}
                //グレート
            }
            else
            {
                if (timeLag <= 0.13)//本来ノーツをたたくべき時間と実際にノーツをたたいた時間の誤差が0.2秒以下だったら
                {
                    Debug.Log("Bad");
                    message(2);
                    hit();
                    GManager.instance.ratioScore += 1;
                    GManager.instance.bad++;
                    GManager.instance.combo = 0;
                    deleteData(numOffset);
                    audio.PlayOneShot(hitSound);
                    //if (timeLag <= -0.11)
                    //{
                    //    fastSlow(0);
                    //}
                    //else
                    //{
                    //    fastSlow(1);
                    //}
                    //バット
                }
                else
                {
                    if(timeLag <= 0.15)
                    {
                        message(3);
                        deleteData(0);
                        Debug.Log("Miss");
                        GManager.instance.miss++;
                        GManager.instance.combo = 0;
                        //ミス
                    }
                }
            }
        }
    }
    float GetABS(float num)//引数の絶対値を返す関数
    {
        if (num >= 0)
        {
            return num;
        }
        else
        {
            return -num;
        }
    }
    void deleteData(int numOffset)//すでにたたいたノーツを削除する関数
    {
        //ノーツタイムとかとかその他の情報を削除して次のノーツの情報を取得させる
        notesManager.NotesTime.RemoveAt(numOffset);
        notesManager.LaneNum.RemoveAt(numOffset);
        notesManager.NoteType.RemoveAt(numOffset);
        //たたいたオブジェを削除させる
        Destroy(notesManager.NotesObj[numOffset + noteNo]);
        noteNo++;
        //スコア加算
        GManager.instance.score = (int)Math.Round(1000000 * Math.Floor(GManager.instance.ratioScore / GManager.instance.maxScore * 1000000) / 1000000);
        //スコア情報とコンボ情報を更新する
        comboText.text = GManager.instance.combo.ToString();
        parfectText.text = GManager.instance.perfect.ToString();
        greatText.text = GManager.instance.great.ToString();
        badText.text = GManager.instance.bad.ToString();
        missText.text = GManager.instance.miss.ToString();
        scoreText.text = GManager.instance.score.ToString();
    }

    void message(int judge)//判定を表示する
    {
        //Instantiate(MessageObj[judge], new Vector3(notesManager.LaneNum[0] - 1.5f, 0.76f, 0.15f), Quaternion.Euler(45, 0, 0));
        Instantiate(MessageObj[judge], new Vector3(0f, 0.66f, 0.15f), Quaternion.Euler(45, 0, 0));
    }

    //void fastSlow(int fast)//判定の早いか遅いかの表示
    //{
    //    Instantiate(FastSlowObj[fast], new Vector3(0, 1.20f, 0.15f), Quaternion.Euler(45, 0, 0));
    //}

    void hit()//当たった時に当たったレーンにそのエフェクトを入れる
    {
        Instantiate(hitPrefab, new Vector3(notesManager.LaneNum[0] - 1.5f, 0.60f, 0.05f), Quaternion.Euler(45, 0, 0));
    }

    void ResultScene()//一定の時間が経過したらリザルトシーンに移行する
    {
        SceneManager.LoadScene("Result");
    }
}
