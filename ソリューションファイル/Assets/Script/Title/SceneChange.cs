//--------------------------------------
//�X�y�[�X�������ꂽ��V�[���J�ڂ���
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    //�T�E���h������
    [SerializeField] AudioSource bgm;
    [SerializeField] float fadeDuration;
    //�ϐ�
    float fadingTime;
    bool isFading;
    // Update is called once per frame
    void Update()
    {
        //�X�y�[�X�������ꂽ��T�E���h���}�b�N�X���炾�񂾂񌸂炵�Ă���
        if (Input.GetKeyDown(KeyCode.Space) && isFading == false)
        {
            fadingTime = fadeDuration;
            isFading = true;
        }
        if (isFading)
        {
            fadingTime -= Time.deltaTime;
            bgm.volume = fadingTime / fadeDuration;

            if (fadingTime <= 0f)
            {
                SceneManager.LoadScene("SelectTest");
            }
        }
        GManager.instance.noteSpeed = 3;
    }
}
