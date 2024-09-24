//-------------------------------------
//�X�^�[�g�����Ƃ��Ɉړ�����I�u�W�F�N�g
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class StartMoveObj : MonoBehaviour
{
    //�����̑����Ă������̃I�u�W�F�N�g
    [SerializeField] GameObject select0;
    [SerializeField] GameObject select1;
    [SerializeField] GameObject select2;
    [SerializeField] GameObject select3;
    [SerializeField] GameObject select4;

    //�E���̈����Ă������̃I�u�W�F�N�g
    [SerializeField] GameObject titleObj;
    [SerializeField] GameObject optionObj;
    [SerializeField] GameObject logoObj;
    [SerializeField] GameObject jacketObj;
    [SerializeField] GameObject creditObj;
    [SerializeField] GameObject BPMObj;
    [SerializeField] GameObject nameObj;
    [SerializeField] GameObject difficultObj;
    [SerializeField] GameObject startObj;

    [SerializeField] GameObject CD;

    bool isMoveFlag;

    // Start is called before the first frame update
    void Start()
    {
        isMoveFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoveFlag = true;
        }

        if(isMoveFlag == true)
        {
            //�����Ɋ񂹂鏈��
            if (select0.transform.position.x > -30)
            {
                select0.transform.position -= new Vector3(5, 0, 0) * Time.deltaTime;
            }
            if (select1.transform.position.x > -30)
            {
                select1.transform.position -= new Vector3(5, 0, 0) * Time.deltaTime;
            }
            if (select2.transform.position.x > -30)
            {
                select2.transform.position -= new Vector3(5, 0, 0) * Time.deltaTime;
            }
            if (select3.transform.position.x > -30)
            {
                select3.transform.position -= new Vector3(5, 0, 0) * Time.deltaTime;
            }
            if (select4.transform.position.x > -30)
            {
                select4.transform.position -= new Vector3(5, 0, 0) * Time.deltaTime;
            }

            //�E���Ɋ񂹂鏈��
            if (titleObj.transform.position.x < 30)
            {
                titleObj.transform.position -= new Vector3(-5, 0, 0) * Time.deltaTime;
                optionObj.transform.position -= new Vector3(-5, 0, 0) * Time.deltaTime;
                logoObj.transform.position -= new Vector3(-5, 0, 0) * Time.deltaTime;
                jacketObj.transform.position -= new Vector3(-5, 0, 0) * Time.deltaTime;
                creditObj.transform.position -= new Vector3(-5, 0, 0) * Time.deltaTime;
                BPMObj.transform.position -= new Vector3(-5, 0, 0) * Time.deltaTime;
                nameObj.transform.position -= new Vector3(-7, 0, 0) * Time.deltaTime;
                difficultObj.transform.position -= new Vector3(-7, 0, 0) * Time.deltaTime;
                startObj.transform.position -= new Vector3(-5, 0, 0) * Time.deltaTime;
            }

            //�^�񒆂Ɋ񂹂鏈��
            if(CD.transform.position.x < 0)
            {
                CD.transform.position -= new Vector3(-5, 0, 0) * Time.deltaTime;
            }

        }
    }
}
