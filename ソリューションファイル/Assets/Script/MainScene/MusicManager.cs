//--------------------------------------
//音楽情報を入れるスクリプト
//--------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    //データベースを入れるもの
    [SerializeField] SongDataBase dataBase;
    //スタートする前に表示するもの
    [SerializeField] GameObject startObj;
    [SerializeField] GameObject DObjS;
    [SerializeField] GameObject FObjS;
    [SerializeField] GameObject JObjS;
    [SerializeField] GameObject KObjS;
    //スタートしてから表示するもの
    [SerializeField] GameObject DObjR;
    [SerializeField] GameObject FObjR;
    [SerializeField] GameObject JObjR;
    [SerializeField] GameObject KObjR;
    //コンボの更新
    [SerializeField] GameObject comboText;
    //オプションを出したときに表示するもの
    [SerializeField] GameObject optionScene;
    [SerializeField] GameObject returnObj;
    [SerializeField] GameObject retryObj;
    [SerializeField] GameObject selectObj;
    //楽曲情報を出力するための処理
    [SerializeField] Image songImage;
    [SerializeField] Text musicName;
    [SerializeField] TextMeshProUGUI musicifficult;
    [SerializeField] TextMeshProUGUI musoclevel;

    //変数
    int count;
    float songTime;
    bool isOptionFlag;
    string songName;
    bool played;
    bool isOpFlag;
    //音楽を入れる
    AudioSource audio;
    AudioClip Music;
    
    void Start()
    {
        //初期化
        GManager.instance.Start = false;
        songName = dataBase.songData[GManager.instance.songID].selectSongName;

        audio = GetComponent<AudioSource>();
        Music = (AudioClip)Resources.Load("Musics/" + songName);
        played = false;

        musicifficult.text = dataBase.songData[GManager.instance.songID].songDifficult;
        musoclevel.text = "" + dataBase.songData[GManager.instance.songID].songLevel;
        songImage.sprite = dataBase.songData[GManager.instance.songID].songImage;
        Debug.Log(musicName);

        count = 0;

        isOptionFlag = false;
        isOpFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        musicName.text = dataBase.songData[GManager.instance.songID].songNameopen;
        //ゲーム開始時の処理
        if (Input.GetKeyDown(KeyCode.Space) && !played && isOpFlag == false)
        { 
            //オブジェクトの表示設定
            startObj.SetActive(false);
            DObjS.SetActive(false);
            FObjS.SetActive(false);
            JObjS.SetActive(false);
            KObjS.SetActive(false);
            DObjR.SetActive(true);
            FObjR.SetActive(true);
            JObjR.SetActive(true);
            KObjR.SetActive(true);
            //スタートさせる処理
            //スペースを押すまでの時間を入れる　曲のずれをなくす
            GManager.instance.Start = true;
            GManager.instance.StartTime = Time.time;
            played = true;
            isOpFlag = true;
            audio.PlayOneShot(Music);
        }
        //エスケープボタンが押された際にこの処理を実行する
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            GManager.instance.Start = false;
            GManager.instance.StartTime = Time.time;
            startObj.SetActive(false);
            played = false;
            audio.Pause();
        }
        //コンボ数が10超えたときに表示させる
        if (GManager.instance.combo >= 10)
        {
            comboText.SetActive(true);
        }
        else
        {
            comboText.SetActive(false);
        }
        //フラグがtrueになったら時間の加算
        if(isOpFlag == true)
        {
            songTime += Time.deltaTime;
        }

        //オプション画面の表示
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            optionScene.SetActive(true);
            isOptionFlag = true;
        }
        //フラグをtrueになったら以下の処理をする
        if (isOptionFlag == true)
        {
            //上下で今どの場所にいるか入れる
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (count < 2)
                {
                    count++;
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (count > 0)
                {
                    count--;
                }
            }
            //決定
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (count == 0) //0なら再開
                {
                    optionScene.SetActive(false);
                    isOptionFlag = false;
                    GManager.instance.Start = true;
                    GManager.instance.StartTime = Time.time;
                    audio.time = songTime;
                    audio.UnPause();
                    played = true;
                }
                else if (count == 1)//1ならリトライ
                {
                    GManager.instance.perfect = 0;
                    GManager.instance.great = 0;
                    GManager.instance.bad = 0;
                    GManager.instance.miss = 0;
                    GManager.instance.maxScore = 0;
                    GManager.instance.ratioScore = 0;
                    GManager.instance.score = 0;
                    GManager.instance.combo = 0;
                    SceneManager.LoadScene("GameScene");
                }
                else if (count == 2)//2なら選択画面へ
                {
                    GManager.instance.perfect = 0;
                    GManager.instance.great = 0;
                    GManager.instance.bad = 0;
                    GManager.instance.miss = 0;
                    GManager.instance.maxScore = 0;
                    GManager.instance.ratioScore = 0;
                    GManager.instance.score = 0;
                    GManager.instance.combo = 0;
                    SceneManager.LoadScene("SelectTest");
                }
            }
            //今そこにいるとわかるオブジェクトを表示させる
            if (count == 0)
            {
                returnObj.SetActive(true);
                retryObj.SetActive(false);
                selectObj.SetActive(false);
            }
            else if (count == 1)
            {
                returnObj.SetActive(false);
                retryObj.SetActive(true);
                selectObj.SetActive(false);
            }
            else if (count == 2)
            { 
                returnObj.SetActive(false);
                retryObj.SetActive(false);
                selectObj.SetActive(true);
            }
        }
    }
}