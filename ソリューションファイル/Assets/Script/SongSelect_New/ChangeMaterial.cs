//-------------------------------------
//�}�e���A���ɉ��������̂�����
//-------------------------------------

using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    [SerializeField] Material[] materialArray = new Material[3];
    Material cubeMaterial;
    private int count;
    private int select;
    private bool isStartFlag = false;
    private float start;
    private float a;

    [SerializeField]
    [Tooltip("x���̉�]�p�x")]
    private float rotateX = 0;

    [SerializeField]
    [Tooltip("y���̉�]�p�x")]
    private float rotateY = 0;

    [SerializeField]
    [Tooltip("z���̉�]�p�x")]
    private float rotateZ = 0;

    Animation animator;


    void Start()
    {
        count = 0;
        select = 0;
        animator = GetComponent<Animation>();
    }

    void Update()
    {
        // X,Y,Z���ɑ΂��Ă��ꂼ��A�w�肵���p�x����]�����Ă���B
        // deltaTime�������邱�ƂŁA�t���[�����Ƃł͂Ȃ��A1�b���Ƃɉ�]����悤�ɂ��Ă���B
        gameObject.transform.Rotate(new Vector3(rotateX, rotateY, -rotateZ) * Time.deltaTime);

        if (isStartFlag == false)
        {
            //�㉺�Ń}�e���A����ύX����
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                animator.Rewind();
                animator.Play();
                if (count < 3)
                {
                    count++;
                }
                else
                {
                    animator.Rewind();
                    animator.Play();
                    count = 0;
                }
            }
            else
            {
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (count > 0)
                {
                    count--;
                    animator.Rewind();
                    animator.Play();
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (select > 0)
                {
                    select--;
                }
                else
                {
                    animator.Rewind();
                    animator.Play();
                    count = 0;
                    select = 3;
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (select < 3)
                {
                    select++;
                }
                else
                {
                    count = 0;
                    select = 0;
                }
            }
        }
        //�X�y�[�X�ŃA�j���[�V�����Đ�����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isStartFlag = true;
        }
        if (isStartFlag == true)
        {
            start += Time.deltaTime;
            if (start > 2)
            {
                rotateZ += start;
            }
        }

        GetComponent<MeshRenderer>().material = materialArray[count];
    }
}

