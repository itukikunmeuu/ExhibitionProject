//-------------------------------------
//�y�ȑI����I������
//-------------------------------------
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SongSelect : MonoBehaviour
{
    //�f�[�^�x�[�X������
    [SerializeField] SongDataBase dataBase;

    //�E�̊y�ȑI����ʂł������
    [SerializeField] TextMeshProUGUI[] songNameText;
    [SerializeField] TextMeshProUGUI[] songLevelText;
    [SerializeField] GameObject[] songObj;

    //�y�Ȃ̃W���P�b�g�̕��ŗ����e�L�X�g
    [SerializeField] TextMeshProUGUI songMainText;
    [SerializeField] TextMeshProUGUI BGMText;
    [SerializeField] TextMeshProUGUI creditName;

    //��Փx�֌W�̃e�L�X�g
    [SerializeField] TextMeshProUGUI songDifficult;
    [SerializeField] TextMeshProUGUI songUpDiff;
    [SerializeField] TextMeshProUGUI songDownDiff;

    //�y�Ȃ��Ƃ̉摜�������
    [SerializeField] Image songImage;

    //�J�����̃I�u�W�F�N�g�����
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
        //������
        select = 0;
        audio = GetComponent<AudioSource>();
        songName = dataBase.songData[select].songName;//new
        Music = (AudioClip)Resources.Load("Musics/" + songName);
        SongUpdateALL();
    }
    void Update()
    {
        //�l��false�ɂȂ������ɓ���
        if (isSpaceFlag == false)
        {
            //���E�œ�Փx���ς��
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
            //�㉺�Ŋy�Ȃ��ς��
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (select < 9)
                {
                    //��Փxeasy����
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
                    //��ՓxNormal�p
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
                    //��ՓxExpert�p
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
                    //��ՓxMaster�p
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

            //��Փx�̃e�L�X�g�ύX
            if (select <= 9)
            {
                songDifficult.text = "Easy";
                songUpDiff.text = "Normal��";
                songDownDiff.text = "��Master";
            }
            else if (select <= 19)
            {
                songDifficult.text = "Normal";
                songUpDiff.text = "Expert��";
                songDownDiff.text = "��Easy";
            }
            else if (select <= 29)
            {
                songDifficult.text = "Expert";
                songUpDiff.text = "Master��";
                songDownDiff.text = "��Normal";

            }
            else if (select <= 39)
            {
                songDifficult.text = "Master";
                songUpDiff.text = "Easy��";
                songDownDiff.text = "��Expert";
            }
            songMainText.text = dataBase.songData[select].songNameopen;
        }

        //�X�y�[�X�������ꂽ�Ƃ�
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
        //�y�Ȃ̃f�[�^�x�[�X���擾���ĕύX����
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