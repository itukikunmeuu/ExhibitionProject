//--------------------------------------
//�������Ă�N���X�@��������ɂ��ċȂ�ID�Ƃ����߂Ă܂�
//-------------------------------------


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;
    //�X�R�A�n
    public float maxScore;
    public float ratioScore;
    //���[�U�f�[�^�n
    public int songID;
    public float noteSpeed;
    public int noteOffset;
    //�X�^�[�g�����ۂ̂�����C�����邽�߂̏���
    public bool Start;
    public float StartTime;
    //�R���{��X�R�A�̏��
    public int combo;
    public int score;
    //�e�^�C�~���O�̏��
    public int perfect;
    public int great;
    public int bad;
    public int miss;

    //�C���X�^���X���Ȃ��ꍇ�ɂ��̃I�u�W�F�N�g���폜����
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    
}