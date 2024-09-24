using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class OptionChangeBottom : MonoBehaviour
{
    //ゲームオブジェクトを入れる
    [SerializeField] GameObject noteSpeedObj;
    [SerializeField] GameObject soundObj;

    //カウントの表示
    int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
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
        if (Input.GetKeyDown(KeyCode.DownArrow))
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

        if(count == 0)
        {
            noteSpeedObj.SetActive(true);
            soundObj.SetActive(false);
        }
        else if(count == 1)
        {
            noteSpeedObj.SetActive(false);
            soundObj.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(count == 0)
            {
                SceneManager.LoadScene("NoteSpeedScene");
            }
            else if(count == 1)
            {
                SceneManager.LoadScene("SettingScene");
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("SelectTest");
        }
    }
}
