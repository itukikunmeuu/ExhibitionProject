//------------------------------------------------------
//�ŏI�R���{���ɉ����ĕ\������I�u�W�F�N�g��ύX���鏈��
//------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboText : MonoBehaviour
{
    //�I�u�W�F�N�g������
    [SerializeField] GameObject crearComboObj;
    [SerializeField] GameObject fullComboObj;
    [SerializeField] GameObject allParfect;
    // Update is called once per frame
    void Update()
    {
        //GManager��miss��0�Ȃ玟��
        if(GManager.instance.miss == 0)
        {
            //GManager��bad��0�Ȃ玟��
            if(GManager.instance.bad == 0)
            {
                //����Ȃ�FullCombo��\������
                fullComboObj.SetActive(true);
                if(GManager.instance.great == 0)
                {
                    allParfect.SetActive(true);
                    fullComboObj.SetActive(false);
                }
            }
        }
        else
        {
            crearComboObj.SetActive(true);
        }
    }
}
