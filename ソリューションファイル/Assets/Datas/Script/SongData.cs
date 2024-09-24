using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SongData", menuName = "�y�ȃf�[�^���쐬")]

public class SongData : ScriptableObject
{
    [SerializeField] public string songID;          //�y��ID������@
    [SerializeField] public string songName;        //�y�Ȗ�������
    [SerializeField] public string songDifficult;   //��Փx������
    [SerializeField] public string songNameopen;    //�\������y�Ȗ�����͂���
    [SerializeField] public string selectSongName;  //�y�ȑI�𒆂ɗ���
    [SerializeField] public string creditName;      //����҂̖��O������
    [SerializeField] public string BPM;             //BPM����͂���
    [SerializeField] public float musicLength;      //�Ȃ̒���������
    [SerializeField] public int songLevel;          //�y�Ȃ̃��x��������
    [SerializeField] public Sprite songImage;       //�y�Ȃ̃C���[�W�摜������
}
