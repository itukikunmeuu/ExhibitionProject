using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOS : MonoBehaviour
{
    //ゲームオブジェクトを入れる
    [SerializeField] GameObject titleObj;
    [SerializeField] GameObject optionObj;

    //カウント
    int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (count == 0)
            {
                count = 1;
            }
            else
            {
                count = 0;
            }

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (count == 0)
            {
                count = 1;
            }
            else
            {
                count = 0;
            }

        }

        if (count == 0)
        {
            titleObj.SetActive(true);
            optionObj.SetActive(false);
        }
        else if (count == 1)
        {
            titleObj.SetActive(false);
            optionObj.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (count == 0)
            {
                SceneManager.LoadScene("TitleScene");
            }
            else if (count == 1)
            {
                SceneManager.LoadScene("SettingScene");
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("OptionScene");
        }
    }
}
