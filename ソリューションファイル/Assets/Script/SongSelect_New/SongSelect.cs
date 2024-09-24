//-------------------------------------
//楽曲選択を選択する
//-------------------------------------
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SongSelect : MonoBehaviour
{
    //データベースを入れる
    [SerializeField] SongDataBase dataBase;

    //右の楽曲選択画面でいれるやつ
    [SerializeField] TextMeshProUGUI[] songNameText;
    [SerializeField] TextMeshProUGUI[] songLevelText;
    [SerializeField] GameObject[] songObj;

    //楽曲のジャケットの方で流すテキスト
    [SerializeField] TextMeshProUGUI songMainText;
    [SerializeField] TextMeshProUGUI BGMText;
    [SerializeField] TextMeshProUGUI creditName;

    //難易度関係のテキスト
    [SerializeField] TextMeshProUGUI songDifficult;
    [SerializeField] TextMeshProUGUI songUpDiff;
    [SerializeField] TextMeshProUGUI songDownDiff;

    //楽曲ごとの画像をいれる
    [SerializeField] Image songImage;

    //カメラのオブジェクト入れる
    [SerializeField] GameObject cameraObj;

    AudioSource audio;
    AudioClip Music;
    string songName;
    bool isSpaceFlag = false;
    bool isStartFlag = false;
    float start = 0;

    int select;
    private void Start()
    {
        //初期化
        select = 0;
        audio = GetComponent<AudioSource>();
        songName = dataBase.songData[select].songName;//new
        Music = (AudioClip)Resources.Load("Musics/" + songName);
        SongUpdateALL();
    }
    void Update()
    {
        //値がfalseになった時に入る
        if (isSpaceFlag == false)
        {
            //左右で難易度が変わる
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (select > 9)
                {
                    select -= 10;
                    SongUpdateALL();
                }
                else
                {
                    select = 30;
                    SongUpdateALL();
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (select < 30)
                {
                    select += 10;
                    SongUpdateALL();
                }
                else
                {
                    select = 0;
                    SongUpdateALL();
                }
            }
            //上下で楽曲が変わる
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (select < 9)
                {
                    //難易度easy譜面
                    if (select < 3)
                    {
                        select++;
                        SongUpdateALL();
                        Debug.Log(select);

                    }
                    else
                    {
                        select = 0;
                        SongUpdateALL();
                        Debug.Log("select");
                    }
                }
                else if (select < 19)
                {
                    //難易度Normal用
                    if (select < 13)
                    {
                        select++;
                        SongUpdateALL();
                        Debug.Log(select);

                    }
                    else
                    {
                        select = 10;
                        SongUpdateALL();
                        Debug.Log("select");
                    }
                }
                else if (select < 29)
                {
                    //難易度Expert用
                    if (select < 23)
                    {
                        select++;
                        SongUpdateALL();
                        Debug.Log(select);

                    }
                    else
                    {
                        select = 20;
                        SongUpdateALL();
                        Debug.Log("select");
                    }
                }
                else if (select < 39)
                {
                    //難易度Master用
                    if (select < 33)
                    {
                        select++;
                        SongUpdateALL();

                    }
                    else
                    {
                        select = 30;
                        SongUpdateALL();
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (select < 9)
                {
                    if (select > 0)
                    {
                        select--;
                        SongUpdateALL();
                        Debug.Log(select);
                    }
                }
                else if (select < 19)
                {
                    if (select > 10)
                    {
                        select--;
                        SongUpdateALL();
                    }
                }
                else if (select < 29)
                {
                    if (select > 20)
                    {
                        select--;
                        SongUpdateALL();
                    }
                }
                else if (select < 39)
                {
                    if (select > 30)
                    {
                        select--;
                        SongUpdateALL();
                    }
                }
            }

            //難易度のテキスト変更
            if (select <= 9)
            {
                songDifficult.text = "Easy";
                songUpDiff.text = "Normal→";
                songDownDiff.text = "←Master";
            }
            else if (select <= 19)
            {
                songDifficult.text = "Normal";
                songUpDiff.text = "Expert→";
                songDownDiff.text = "←Easy";
            }
            else if (select <= 29)
            {
                songDifficult.text = "Expert";
                songUpDiff.text = "Master→";
                songDownDiff.text = "←Normal";

            }
            else if (select <= 39)
            {
                songDifficult.text = "Master";
                songUpDiff.text = "Easy→";
                songDownDiff.text = "←Expert";
            }
            songMainText.text = dataBase.songData[select].songNameopen;
        }

        //スペースが押されたとき
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSpaceFlag = true;
            isStartFlag = true;
        }

        if (isStartFlag == true)
        {
            start += Time.deltaTime;
            if (start > 4)
            {
                if (cameraObj.transform.position.z < -4.5)
                {
                    cameraObj.transform.position += new Vector3(0, 0, 8) * Time.deltaTime;
                }

                if (start > 5)
                {
                    SongStart();
                }
            }
        }
    }
    private void SongUpdateALL()
    {
        //楽曲のデータベースを取得して変更する
        songName = dataBase.songData[select].selectSongName;
        creditName.text = dataBase.songData[select].creditName;
        BGMText.text = dataBase.songData[select].BPM;

        Music = (AudioClip)Resources.Load("Musics/" + songName);
        audio.Stop();
        audio.PlayOneShot(Music);
        for (int i = 0; i < 5; i++)
        {
            SongUpdate(i - 2);
        }
    }
    private void SongUpdate(int id)
    {
        try
        {
            songNameText[id + 2].text = dataBase.songData[select + id].songNameopen;
            songLevelText[id + 2].text = "Lv." + dataBase.songData[select + id].songLevel;
            songObj[id + 2].SetActive(true);
        }
        catch
        {
            songNameText[id + 2].text = "";
            songLevelText[id + 2].text = "";
            songObj[id + 2].SetActive(false);
        }
        if (id == 0)
        {
            songImage.sprite = dataBase.songData[select + id].songImage;
        }
    }
    public void SongStart()
    {
        GManager.instance.songID = select;
        SceneManager.LoadScene("GameScene");
    }
}