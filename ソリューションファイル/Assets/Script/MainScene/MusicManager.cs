//--------------------------------------
//���y��������X�N���v�g
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
    //�f�[�^�x�[�X���������
    [SerializeField] SongDataBase dataBase;
    //�X�^�[�g����O�ɕ\���������
    [SerializeField] GameObject startObj;
    [SerializeField] GameObject DObjS;
    [SerializeField] GameObject FObjS;
    [SerializeField] GameObject JObjS;
    [SerializeField] GameObject KObjS;
    //�X�^�[�g���Ă���\���������
    [SerializeField] GameObject DObjR;
    [SerializeField] GameObject FObjR;
    [SerializeField] GameObject JObjR;
    [SerializeField] GameObject KObjR;
    //�R���{�̍X�V
    [SerializeField] GameObject comboText;
    //�I�v�V�������o�����Ƃ��ɕ\���������
    [SerializeField] GameObject optionScene;
    [SerializeField] GameObject returnObj;
    [SerializeField] GameObject retryObj;
    [SerializeField] GameObject selectObj;
    //�y�ȏ����o�͂��邽�߂̏���
    [SerializeField] Image songImage;
    [SerializeField] Text musicName;
    [SerializeField] TextMeshProUGUI musicifficult;
    [SerializeField] TextMeshProUGUI musoclevel;

    //�ϐ�
    int count;
    float songTime;
    bool isOptionFlag;
    string songName;
    bool played;
    bool isOpFlag;
    //���y������
    AudioSource audio;
    AudioClip Music;
    
    void Start()
    {
        //������
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
        //�Q�[���J�n���̏���
        if (Input.GetKeyDown(KeyCode.Space) && !played && isOpFlag == false)
        { 
            //�I�u�W�F�N�g�̕\���ݒ�
            startObj.SetActive(false);
            DObjS.SetActive(false);
            FObjS.SetActive(false);
            JObjS.SetActive(false);
            KObjS.SetActive(false);
            DObjR.SetActive(true);
            FObjR.SetActive(true);
            JObjR.SetActive(true);
            KObjR.SetActive(true);
            //�X�^�[�g�����鏈��
            //�X�y�[�X�������܂ł̎��Ԃ�����@�Ȃ̂�����Ȃ���
            GManager.instance.Start = true;
            GManager.instance.StartTime = Time.time;
            played = true;
            isOpFlag = true;
            audio.PlayOneShot(Music);
        }
        //�G�X�P�[�v�{�^���������ꂽ�ۂɂ��̏��������s����
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            GManager.instance.Start = false;
            GManager.instance.StartTime = Time.time;
            startObj.SetActive(false);
            played = false;
            audio.Pause();
        }
        //�R���{����10�������Ƃ��ɕ\��������
        if (GManager.instance.combo >= 10)
        {
            comboText.SetActive(true);
        }
        else
        {
            comboText.SetActive(false);
        }
        //�t���O��true�ɂȂ����玞�Ԃ̉��Z
        if(isOpFlag == true)
        {
            songTime += Time.deltaTime;
        }

        //�I�v�V������ʂ̕\��
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            optionScene.SetActive(true);
            isOptionFlag = true;
        }
        //�t���O��true�ɂȂ�����ȉ��̏���������
        if (isOptionFlag == true)
        {
            //�㉺�ō��ǂ̏ꏊ�ɂ��邩�����
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
            //����
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (count == 0) //0�Ȃ�ĊJ
                {
                    optionScene.SetActive(false);
                    isOptionFlag = false;
                    GManager.instance.Start = true;
                    GManager.instance.StartTime = Time.time;
                    audio.time = songTime;
                    audio.UnPause();
                    played = true;
                }
                else if (count == 1)//1�Ȃ烊�g���C
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
                else if (count == 2)//2�Ȃ�I����ʂ�
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
            //�������ɂ���Ƃ킩��I�u�W�F�N�g��\��������
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