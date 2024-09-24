//-------------------------------------
//�m�[�c�̏���
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    //�m�[�c�̃X�s�[�h��ݒ�
    float NoteSpeed = 8;
    bool start;

    void Start()
    {
        NoteSpeed = GManager.instance.noteSpeed;
    }
    void Update()
    {
        //�X�y�[�X�������ꂽ��true�ɂ���
        if (Input.GetKeyDown(KeyCode.Space))
        {
            start = true;
        }
        //�m�[�c�����Z���Ă��낷����
        if (start)
        {
            transform.position -= transform.forward * Time.deltaTime * NoteSpeed;
        }
        //�G�X�P�[�v�{�^���Ŏ~�߂�
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            start = false;
        }
    }
}