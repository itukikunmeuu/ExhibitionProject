//--------------------------------------
//�T�E���h�̒������擾����@����g�p�̒ǉ������Ă��Ȃ����߂Ȃ�
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SoundLength : MonoBehaviour
{
    //hp�o�[������
    Slider hpSlider;

    [SerializeField] SongDataBase dataBase;
    string songName;

    // Start is called before the first frame update
    void Start()
    {
        //������
        hpSlider = GetComponent<Slider>();
        float maxLength = dataBase.songData[GManager.instance.songID].musicLength;
        float nowLength = 0;

        Debug.Log(maxLength);
        hpSlider.value = nowLength;
    }

    // Update is called once per frame
    void Update()
    {
        //�Ȃ̒������擾���Ă���ɉ����đ����Ă���
        hpSlider.value ++;
    }
}
