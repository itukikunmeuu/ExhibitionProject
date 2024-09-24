//-------------------------------------
//ボタンを押したらシーンが変わる
//-------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeOption : MonoBehaviour
{
    public void Change_button()
    {
        SceneManager.LoadScene("OptionScene");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("OptionScene");
        }
    }
}
