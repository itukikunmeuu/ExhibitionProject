//-------------------------------------
//リザルトシーンでの処理
//-------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    //オブジェクトをいれる
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI perfectText;
    [SerializeField] TextMeshProUGUI greatText;
    [SerializeField] TextMeshProUGUI badText;
    [SerializeField] TextMeshProUGUI missText;
    [SerializeField] SongDataBase dataBase;
    [SerializeField] Image songImage;

    [SerializeField] GameObject selectObj;
    [SerializeField] GameObject retryObj;
    //変数の設定
    int select;
    int objCount;
    private void Start()
    {
        //初期化
        select = GManager.instance.songID;
        objCount = 0;
    }
    private void OnEnable()
    {
        //ゲームシーンで更新したテキストを入れる
        scoreText.text = GManager.instance.score.ToString();
        perfectText.text = GManager.instance.perfect.ToString();
        greatText.text = GManager.instance.great.ToString();
        badText.text = GManager.instance.bad.ToString();
        missText.text = GManager.instance.miss.ToString();
 
    }

    private void Update()
    { 
        //楽曲のイメージ画像を入れる
        songImage.sprite = dataBase.songData[select].songImage;
        //左右で値に応じて画像が切り替わる
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(objCount == 0)
            {
                objCount = 1;
                retryObj.SetActive(false);
                selectObj.SetActive(true);
            }
            else
            {
                objCount = 0;
                retryObj.SetActive(true);
                selectObj.SetActive(false);
            }
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(objCount == 1)
            {
                objCount = 0;
                retryObj.SetActive(true);
                selectObj.SetActive(false);
            }
            else
            {
                objCount = 1;
                retryObj.SetActive(false);
                selectObj.SetActive(true);
            }
        }
        //スペースで1なら選曲画面へ、2ならゲームシーンへ行く
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(objCount == 1)
            {
                Close();
            }
            else if(objCount == 0)
            {
                Retry();
            }
        }
        Debug.Log(objCount);
    }

    public void Retry()
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
    public void Close()
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