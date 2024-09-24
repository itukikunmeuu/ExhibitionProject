//--------------------------------------
//�m�[�c�X�s�[�h��ύX���鏈��
//--------------------------------------
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoteSpeedChange : MonoBehaviour
{
    //�e�L�X�g������
    [SerializeField] private TextMeshProUGUI noteNumText;
    [SerializeField] private TextMeshProUGUI noteOffsetText;
    //�m�[�c�̃I�u�W�F�N�g������
    [SerializeField] private GameObject noteSpeedObj;
    [SerializeField] private GameObject noteOffsetObj;
    //�ϐ������
    int noteSpeed;
    int noteOffset;
    int gameObj;

    // Start is called before the first frame update
    void Start()
    {
        //������
        noteSpeed = 10;
        noteOffset = 0;
        gameObj = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //���E�Œl�̕ύX
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (gameObj == 0)
            {
                if (noteSpeed > 1)
                {
                    noteSpeed -= 1;
                }
            }
            else if (gameObj == 1)
            {
                if (noteOffset > -30)
                {
                    noteOffset -= 1;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (gameObj == 0)
            {
                if (noteSpeed < 100)
                {
                    noteSpeed += 1;
                }
            }
            else if (gameObj == 1)
            {
                if (noteOffset < 30)
                {
                    noteOffset += 1;
                }
            }
        }

        //�㉺�Ń^�C�~���O�ƃX�s�[�h�̕ύX�l��ύX����
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (gameObj == 1)
            {
                gameObj = 0;
                noteOffsetObj.SetActive(false);
                noteSpeedObj.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (gameObj == 0)
            {
                noteOffsetObj.SetActive(true);
                noteSpeedObj.SetActive(false);
                gameObj = 1;
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("OptionScene");
        }
        //�ύX�����l������
        GManager.instance.noteSpeed = noteSpeed;
        GManager.instance.noteOffset = noteOffset;
        noteNumText.text = "" + noteSpeed;
        noteOffsetText.text = "" + noteOffset;
    }
}
