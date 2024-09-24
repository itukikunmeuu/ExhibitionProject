//-------------------------------------
//�I�v�V�����̍ۂɕ\�����鏈��
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOption : MonoBehaviour
{
    //�I�v�V�����V�[���Ɉڍs�����ۂɕ\������I�u�W�F�N�g������
    [SerializeField] GameObject optionScene;
    [SerializeField] GameObject startObj;
    [SerializeField] GameObject retryObj;
    [SerializeField] GameObject selectObj;

    //�ϐ��̐ݒ�
    int count;
    bool isOptionFlag;
    bool played;

    // Start is called before the first frame update
    void Start()
    {
        //������
        count = 0;   
        isOptionFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        //�G�X�P�[�v�L�[�������ꂽ��bool��true�ɂ��ăI�v�V������ʂ�\������
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            optionScene.SetActive(true);
            isOptionFlag = true;
        }
        //�I�v�V�����t���O��true�ɂȂ�����ȉ��̏������J�n
        if(isOptionFlag == true)
        {
            //�㉺�ŃJ�E���g�𑝂₷
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (count < 2)
                {
                    count++;
                }
            }
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                if(count > 0)
                {
                    count--;
                }
            }
            //�X�y�[�X���������猈��
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //0�̏ꍇ�͍ĊJ�ŋȂ̓r������ĊJ����
                if(count == 0)
                {
                    optionScene.SetActive(false);
                    isOptionFlag = false;
                    GManager.instance.Start = true;
                    GManager.instance.StartTime = Time.time;
                    played = true;
                }
                //1�̏ꍇ�͏��߂���
                else if(count == 1)
                {
                    GManager.instance.perfect = 0;
                    GManager.instance.great = 0;
                    GManager.instance.bad = 0;
                    GManager.instance.miss = 0;
                    GManager.instance.maxScore = 0;
                    GManager.instance.ratioScore = 0;
                    GManager.instance.score = 0;
                    GManager.instance.combo = 0;
                    SceneManager.LoadScene("GameScene");
                }
                //2�̏ꍇ�͋ȑI����ʂɈڍs����
                else if(count == 2)
                {
                    GManager.instance.perfect = 0;
                    GManager.instance.great = 0;
                    GManager.instance.bad = 0;
                    GManager.instance.miss = 0;
                    GManager.instance.maxScore = 0;
                    GManager.instance.ratioScore = 0;
                    GManager.instance.score = 0;
                    GManager.instance.combo = 0;
                    SceneManager.LoadScene("SelectTest");
                }
            }
            //�e�I�u�W�F�N�g�̎��ɂ킩��悤�ȉ�ʂ�����
            if(count == 0)
            {
                startObj.SetActive(true);
                retryObj.SetActive(false);
                selectObj.SetActive(false);
            }
            else if(count == 1)
            {
                startObj.SetActive(false);
                retryObj.SetActive(true);
                selectObj.SetActive(false);
            }
            else if(count == 2)
            {
                startObj.SetActive(false);
                retryObj.SetActive(false);
                selectObj.SetActive(true);
            }
        }
    }
}
