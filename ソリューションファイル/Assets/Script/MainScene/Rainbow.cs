//-------------------------------------
//���F�ɂ���X�N���v�g
//-------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainbow : MonoBehaviour
{
    public GameObject tile;
    // Start is called before the first frame update
    void Start()
    {
        float count = 0;

        for (int i = 0; i <= 30; i++)
        {
            GameObject obj = Instantiate(tile, new Vector3(0f, 0f, -1f * i), Quaternion.identity);
            //obj.GetComponent<ColorChange>().initial = count;
            //�C���X�^���X�������I�u�W�F�N�g��ColorChange�X�N���v�g���ɂ���ϐ�initial��count����
            count += 0.1f;
            //count�̒l��0.1���ς���
            //count�̑�����������������قǁA�^�C���Ԃ̐F�����Ȃ߂炩�ɕω����܂�
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
