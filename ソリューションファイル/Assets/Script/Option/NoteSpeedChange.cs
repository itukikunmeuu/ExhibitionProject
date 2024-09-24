//--------------------------------------
//ノーツスピードを変更する処理
//--------------------------------------
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoteSpeedChange : MonoBehaviour
{
    //テキストを入れる
    [SerializeField] private TextMeshProUGUI noteNumText;
    [SerializeField] private TextMeshProUGUI noteOffsetText;
    //ノーツのオブジェクトを入れる
    [SerializeField] private GameObject noteSpeedObj;
    [SerializeField] private GameObject noteOffsetObj;
    //変数入れる
    int noteSpeed;
    int noteOffset;
    int gameObj;

    // Start is called before the first frame update
    void Start()
    {
        //初期化
        noteSpeed = 10;
        noteOffset = 0;
        gameObj = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //左右で値の変更
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (gameObj == 0)
            {
                if (noteSpeed > 1)
                {
                    noteSpeed -= 1;
                }
            }
            else if (gameObj == 1)
            {
                if (noteOffset > -30)
                {
                    noteOffset -= 1;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (gameObj == 0)
            {
                if (noteSpeed < 100)
                {
                    noteSpeed += 1;
                }
            }
            else if (gameObj == 1)
            {
                if (noteOffset < 30)
                {
                    noteOffset += 1;
                }
            }
        }

        //上下でタイミングとスピードの変更値を変更する
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (gameObj == 1)
            {
                gameObj = 0;
                noteOffsetObj.SetActive(false);
                noteSpeedObj.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (gameObj == 0)
            {
                noteOffsetObj.SetActive(true);
                noteSpeedObj.SetActive(false);
                gameObj = 1;
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("OptionScene");
        }
        //変更した値を入れる
        GManager.instance.noteSpeed = noteSpeed;
        GManager.instance.noteOffset = noteOffset;
        noteNumText.text = "" + noteSpeed;
        noteOffsetText.text = "" + noteOffset;
    }
}
