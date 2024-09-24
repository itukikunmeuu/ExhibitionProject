//-------------------------------------
//����̏���
//--------------------------------------
using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
public class Judge : MonoBehaviour
{
    //�ϐ��̐錾
    [SerializeField] private GameObject[] MessageObj;//�v���C���[�ɔ����`����Q�[���I�u�W�F�N�g
    [SerializeField] private GameObject[] FastSlowObj; //�v���C���[�ɔ���̑������x����`����Q�[���I�u�W�F�N�g
    [SerializeField] NotesManager notesManager;//�X�N���v�g�unotesManager�v������ϐ�
    //�e�L�X�g������I�u�W�F�N�g
    [SerializeField] TextMeshProUGUI comboText;
    [SerializeField] TextMeshProUGUI parfectText;
    [SerializeField] TextMeshProUGUI greatText;
    [SerializeField] TextMeshProUGUI badText;
    [SerializeField] TextMeshProUGUI missText;
    [SerializeField] TextMeshProUGUI scoreText;

    //�I������ۂɃI�u�W�F�N�g�̕\��
    [SerializeField] GameObject finish;
    //�����������ɃI�u�W�F�N�g������ϐ�
    [SerializeField] GameObject hitPrefab;
    //�Ȃ�����I�u�W�F�N�g
    AudioSource audio;
    //�����������ɃT�E���h����
    [SerializeField] AudioClip hitSound;
    //�ϐ�
    float endTime = 0;
    int noteNo;
   
    void Start()
    {
        //������
        audio = GetComponent<AudioSource>();
        endTime = notesManager.NotesTime[notesManager.NotesTime.Count - 1];
    }
    void Update()
    {
        //GManager��Start���ύX���ꂽ��ȉ��̏���������
        if (GManager.instance.Start)
        {
            if (Input.GetKeyDown(KeyCode.D))//D�L�[�������ꂽ�Ƃ�
            {
                if (notesManager.LaneNum[0] == 0)//�����ꂽ�{�^���̓��[���̔ԍ��Ƃ����Ă��邩�H
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
            if (Input.GetKeyDown(KeyCode.F))//F�L�[�������ꂽ�Ƃ�
            {
                if (notesManager.LaneNum[0] == 1)//�����ꂽ�{�^���̓��[���̔ԍ��Ƃ����Ă��邩�H
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
            if (Input.GetKeyDown(KeyCode.J))//J�L�[�������ꂽ�Ƃ�
            {
                if (notesManager.LaneNum[0] == 2)//�����ꂽ�{�^���̓��[���̔ԍ��Ƃ����Ă��邩�H
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
            if (Input.GetKeyDown(KeyCode.K))//K�L�[�������ꂽ�Ƃ�
            {
                if (notesManager.LaneNum[0] == 3)//�����ꂽ�{�^���̓��[���̔ԍ��Ƃ����Ă��邩�H
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
            //�I�����ɍs������
            if (Time.time > endTime + GManager.instance.StartTime)
            {
                finish.SetActive(true);
                Invoke("ResultScene", 6f);
                return;
            }

            if (Time.time > notesManager.NotesTime[0] + 0.2f + GManager.instance.StartTime)//�{���m�[�c���������ׂ����Ԃ���0.2�b�����Ă����͂��Ȃ������ꍇ
            {
                message(3);
                deleteData(0);
                Debug.Log("Miss");
                GManager.instance.miss++;
                GManager.instance.combo = 0;
                //�~�X
            }
        }
    }
    void Judgement(float timeLag, int numOffset)
    {
        
        if (timeLag <= 0.05)//�{���m�[�c���������ׂ����ԂƎ��ۂɃm�[�c�������������Ԃ̌덷��0.1�b�ȉ���������
        {
            Debug.Log("Perfect");
            message(0);
            hit();
            GManager.instance.ratioScore += 5;
            GManager.instance.perfect++;
            GManager.instance.combo++;
            deleteData(numOffset);
            audio.PlayOneShot(hitSound);
            //�p�[�t�F�N�g
        }
        else
        {
            if (timeLag <= 0.10)//�{���m�[�c���������ׂ����ԂƎ��ۂɃm�[�c�������������Ԃ̌덷��0.15�b�ȉ���������
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
                //�O���[�g
            }
            else
            {
                if (timeLag <= 0.13)//�{���m�[�c���������ׂ����ԂƎ��ۂɃm�[�c�������������Ԃ̌덷��0.2�b�ȉ���������
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
                    //�o�b�g
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
                        //�~�X
                    }
                }
            }
        }
    }
    float GetABS(float num)//�����̐�Βl��Ԃ��֐�
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
    void deleteData(int numOffset)//���łɂ��������m�[�c���폜����֐�
    {
        //�m�[�c�^�C���Ƃ��Ƃ����̑��̏����폜���Ď��̃m�[�c�̏����擾������
        notesManager.NotesTime.RemoveAt(numOffset);
        notesManager.LaneNum.RemoveAt(numOffset);
        notesManager.NoteType.RemoveAt(numOffset);
        //���������I�u�W�F���폜������
        Destroy(notesManager.NotesObj[numOffset + noteNo]);
        noteNo++;
        //�X�R�A���Z
        GManager.instance.score = (int)Math.Round(1000000 * Math.Floor(GManager.instance.ratioScore / GManager.instance.maxScore * 1000000) / 1000000);
        //�X�R�A���ƃR���{�����X�V����
        comboText.text = GManager.instance.combo.ToString();
        parfectText.text = GManager.instance.perfect.ToString();
        greatText.text = GManager.instance.great.ToString();
        badText.text = GManager.instance.bad.ToString();
        missText.text = GManager.instance.miss.ToString();
        scoreText.text = GManager.instance.score.ToString();
    }

    void message(int judge)//�����\������
    {
        //Instantiate(MessageObj[judge], new Vector3(notesManager.LaneNum[0] - 1.5f, 0.76f, 0.15f), Quaternion.Euler(45, 0, 0));
        Instantiate(MessageObj[judge], new Vector3(0f, 0.66f, 0.15f), Quaternion.Euler(45, 0, 0));
    }

    //void fastSlow(int fast)//����̑������x�����̕\��
    //{
    //    Instantiate(FastSlowObj[fast], new Vector3(0, 1.20f, 0.15f), Quaternion.Euler(45, 0, 0));
    //}

    void hit()//�����������ɓ����������[���ɂ��̃G�t�F�N�g������
    {
        Instantiate(hitPrefab, new Vector3(notesManager.LaneNum[0] - 1.5f, 0.60f, 0.05f), Quaternion.Euler(45, 0, 0));
    }

    void ResultScene()//���̎��Ԃ��o�߂����烊�U���g�V�[���Ɉڍs����
    {
        SceneManager.LoadScene("Result");
    }
}
