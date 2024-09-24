//--------------------------------------
//スペースが押されたらシーン遷移する
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    //サウンドを入れる
    [SerializeField] AudioSource bgm;
    [SerializeField] float fadeDuration;
    //変数
    float fadingTime;
    bool isFading;
    // Update is called once per frame
    void Update()
    {
        //スペースが押されたらサウンドをマックスからだんだん減らしていく
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
