//-------------------------------------
//マテリアルに応じたものを入れる
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
    [Tooltip("x軸の回転角度")]
    private float rotateX = 0;

    [SerializeField]
    [Tooltip("y軸の回転角度")]
    private float rotateY = 0;

    [SerializeField]
    [Tooltip("z軸の回転角度")]
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
        // X,Y,Z軸に対してそれぞれ、指定した角度ずつ回転させている。
        // deltaTimeをかけることで、フレームごとではなく、1秒ごとに回転するようにしている。
        gameObject.transform.Rotate(new Vector3(rotateX, rotateY, -rotateZ) * Time.deltaTime);

        if (isStartFlag == false)
        {
            //上下でマテリアルを変更する
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
        //スペースでアニメーション再生する
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

