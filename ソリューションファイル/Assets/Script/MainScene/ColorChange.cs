//�}�e���A������F�ɕύX����X�N���v�g�@����͎g�p���ĂȂ�������K�v�ɂȂ����Ƃ��p
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    //���b�V�����Ԃ�����
    MeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
        //���b�V���R���|�[�l���g���Ԃ�����
        mesh = GetComponent<MeshRenderer>();
        StartCoroutine("Transparent");
    }

    // Update is called once per frame
    IEnumerator Transparent()
    {
        //�F��ύX����
        for (int i = 0; i < 255; i++)
        {
            mesh.material.color = mesh.material.color - new Color32(0, 0, 0, 1);
            yield return new WaitForSeconds(0.01f);
        }
    }
}