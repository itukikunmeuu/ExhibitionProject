//-------------------------------------
//ボタンを押したらシーンを変える
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeOption : MonoBehaviour
{
    public void Change_button()
    {
        SceneManager.LoadScene("OptionScene");
    }
}
