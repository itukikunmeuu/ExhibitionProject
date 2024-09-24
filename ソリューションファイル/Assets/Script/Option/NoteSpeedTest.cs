//--------------------------------------
//�ύX�����I�u�W�F�N�g���Đ�����
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NoteSpeedTest : MonoBehaviour
{
    //�m�[�c�̏�����
    float noteSpeed = 10;
    float noteOffset = 0;
    float gameObj = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //���E�ŃX�s�[�h�̕ύX
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (gameObj == 0)
            {
                if (noteSpeed > 1)
                {
                    noteSpeed -= 1;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (gameObj == 0) 
            {
                if (noteSpeed <100) 
                {
                    noteSpeed += 1;
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(gameObj == 1)
            {
                gameObj = 0;
            }
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (gameObj == 0)
            {
                gameObj = 1;
            }
        }
        //�i���ɃI�u�W�F�N�g�����[�v������
        if (transform.position.y <= -3)
        {
            transform.position = new Vector3(4, 5, -3);
        }

        //���W������������
        transform.position -= new Vector3(0, noteSpeed, 0) * Time.deltaTime;
    }
}
