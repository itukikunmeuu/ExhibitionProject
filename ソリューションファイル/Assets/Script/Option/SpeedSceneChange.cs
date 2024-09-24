//-------------------------------------
//ボタンを押したらシーンが変わる
//-------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SpeedSceneChange : MonoBehaviour
{
    public void Change_button()
    {
        SceneManager.LoadScene("OptionScene");
    }
}
