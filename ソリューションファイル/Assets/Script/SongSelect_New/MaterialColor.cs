//--------------------------------------
//�}�e���A���̐F��ύX����
//-------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialColor : MonoBehaviour
{
    //�ύX
    int color = 0;
    bool isStartFlag = false;
    // Update is called once per frame
    void Update()
    {
        //Flag���ς������ȉ��̏����ɓ���
        if (isStartFlag == false)
        {
            //���E�ŃJ���[�̐F��ύX����
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (color > 0)
                {
                    color -= 1;
                }
                else
                {
                    color = 3;
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (color < 3)
                {
                    color += 1;
                }
                else
                {
                    color = 0;
                }
            }
        }
        //�X�y�[�X�Ō���
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isStartFlag = true;
        }
        //�J���[�̐F��ύX����
        if (color == 0)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else if (color == 1)
        {
            GetComponent<Renderer>().material.color = Color.cyan;
        }
        else if (color == 2)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else if (color == 3)
        {
            GetComponent<Renderer>().material.color = Color.magenta;
        }
    }
}
