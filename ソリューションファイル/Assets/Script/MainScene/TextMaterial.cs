//--------------------------------------
//�e�L�X�g�̐F�ύX
//--------------------------------------

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextMaterial : MonoBehaviour
{
    //�e�L�X�g������
    TextMesh text;

    // Update is called once per frame
    void Update()
    {
        //�F�̕ύX
        if (GManager.instance.combo >= 10)
        {
            text.color = Color.green;
        }
        else if (GManager.instance.combo >= 20)
        {
            text.color = Color.yellow;
        }
    }
}
