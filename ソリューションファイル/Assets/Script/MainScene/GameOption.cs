//-------------------------------------
//オプションの際に表示する処理
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOption : MonoBehaviour
{
    //オプションシーンに移行した際に表示するオブジェクトを入れる
    [SerializeField] GameObject optionScene;
    [SerializeField] GameObject startObj;
    [SerializeField] GameObject retryObj;
    [SerializeField] GameObject selectObj;

    //変数の設定
    int count;
    bool isOptionFlag;
    bool played;

    // Start is called before the first frame update
    void Start()
    {
        //初期化
        count = 0;   
        isOptionFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        //エスケープキーが押されたらboolをtrueにしてオプション画面を表示する
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            optionScene.SetActive(true);
            isOptionFlag = true;
        }
        //オプションフラグがtrueになったら以下の処理を開始
        if(isOptionFlag == true)
        {
            //上下でカウントを増やす
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (count < 2)
                {
                    count++;
                }
            }
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                if(count > 0)
                {
                    count--;
                }
            }
            //スペースを押したら決定
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //0の場合は再開で曲の途中から再開する
                if(count == 0)
                {
                    optionScene.SetActive(false);
                    isOptionFlag = false;
                    GManager.instance.Start = true;
                    GManager.instance.StartTime = Time.time;
                    played = true;
                }
                //1の場合は初めから
                else if(count == 1)
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
                //2の場合は曲選択画面に移行する
                else if(count == 2)
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
            //各オブジェクトの時にわかるような画面を入れる
            if(count == 0)
            {
                startObj.SetActive(true);
                retryObj.SetActive(false);
                selectObj.SetActive(false);
            }
            else if(count == 1)
            {
                startObj.SetActive(false);
                retryObj.SetActive(true);
                selectObj.SetActive(false);
            }
            else if(count == 2)
            {
                startObj.SetActive(false);
                retryObj.SetActive(false);
                selectObj.SetActive(true);
            }
        }
    }
}
