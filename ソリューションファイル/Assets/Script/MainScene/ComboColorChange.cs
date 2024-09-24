//--------------------------------------
//�R���{���ɉ����ăe�L�X�g�̐F��ύX����
//--------------------------------------
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComboColorChange : MonoBehaviour
{
    //�e�L�X�g�̃I�u�W�F�N�g�����锠
    [SerializeField]TextMeshProUGUI colorText;
    [SerializeField]TextMeshProUGUI colorTextSum;

    //�A�j���[�V����
    Animation animation;

    //�R���{���m�F�̂��߂̂���
    int combo;

    // Start is called before the first frame update
    void Start()
    {
        //�F�̃^�O��true�ɂ���(�������邱�ƂŃ��l�̕ύX���\�ɂȂ�)
        colorText.overrideColorTags = true;
        colorTextSum.overrideColorTags = true;
        //�F�̕ύX(�����F�͔�)
        colorText.color= new Color(255, 255, 255, 50);
        colorTextSum.color = new Color(255, 255, 255, 50);
        //�A�j���[�V�����̏����ݒ�
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        //GManager����R���{�����擾���Č��݂̃R���{�ɉ����ăA�j���[�V�������Đ�����̂����Ȃ��̂����߂�ϐ�
        if (GManager.instance.combo > combo)
        {
            animation.Rewind();
            animation.Play();
            combo++;
            if(GManager.instance.combo == 0)
            {
                combo = 0;
            }
        }

        //�R���{����10�R���{�ȏゾ�����ꍇ�e�L�X�g�𔒐F�ɂ��鏈��
        if(GManager.instance.combo <= 10)
        {
            colorText.overrideColorTags = true;
            colorTextSum.overrideColorTags = true;
            colorText.color= new Color32(255,255,255,50);
            colorTextSum.color= new Color32(255, 255, 255,50);
        }
        else if(GManager.instance.combo > 50)
        {
            //�R���{����50�R���{�ȏ�ɂȂ����ۂɃI�����W�F�ɕύX���鏈��
            colorText.overrideColorTags = true;
            colorTextSum.overrideColorTags = true;
            colorText.color= new Color32(238, 120, 0,50);
            colorTextSum.color = new Color32(238, 120, 0, 50);
        }
    }
}
