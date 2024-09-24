using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeI : MonoBehaviour
{
    //�ϐ��̐錾
    [SerializeField] private GameObject[] CubeObj;

    //�ϐ��̍ő�l�ƍŏ��l�����߂�
    public float MaxInstance = 7;
    public float MinInstance = 0;
    //�C���X�^���X�̐�������
    public float instance;

    // Update is called once per frame
    void Update()
    {
        //�e�L�[�������ꂽ�Ƃ��ɃC���X�^���X�N���X���Ăяo��
        if (Input.GetKeyDown(KeyCode.D))
        {
            Instance();
            Message(instance);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instance();
            Message(instance);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Instance();
            Message(instance);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Instance();
            Message(instance);
        }
    }

    //�K�v�ȍۂɃ����_���֐����Ăяo���ă����_���ɃI�u�W�F�N�g��\��������
    private void Instance()
    {
        //�K�v�Ȏ��ɌĂяo��
        instance = Random.Range(MinInstance, MaxInstance);
    }
    //�I�u�W�F�N�g�𐶐�����
    void Message(float cube)
    {
        Instantiate(CubeObj[(int)cube]);
    }
}
