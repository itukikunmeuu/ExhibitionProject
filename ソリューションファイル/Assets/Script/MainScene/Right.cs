//-------------------------------------
//���C�g������X�N���v�g
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : MonoBehaviour
{
    //�X�s�[�h�̑���������X�N���v�g
    [SerializeField] private float Speed = 3;
    [SerializeField] private int   num = 0;
    //�����_�����O�̒l������
    private Renderer rend;
    private float alfa = 0;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //�{�^������������F���ς�鏈��
        if(!(rend.material.color.a <= 0))
        {
            rend.material.color = new Color(rend.material.color.r, rend.material.color.g,rend.material.color.b,alfa);
        }
        if(num == 1)
        {
            if(Input.GetKeyDown(KeyCode.D))
            {
                ColorChange();
            }
        }
        if (num == 2)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                ColorChange();
            }
        }
        if (num == 3)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                ColorChange();
            }
        }
        if (num == 4)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                ColorChange();
            }
        }
        alfa -= Speed * Time.deltaTime;
    }
    //�F��ύX����
    void ColorChange()
    {
        alfa = 0.3f;
        rend.material.color = new Color(rend.material.color.r, rend.material.color.g,rend.material.color.b,alfa);
    }
}
