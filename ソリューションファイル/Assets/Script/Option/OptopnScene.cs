//-------------------------------------
//シーンチェンジ
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OptopnScene : MonoBehaviour
{
    //指定したボタンに応じてシーンを変更する
    public void NoteSpeed_SceneChange()
    {
        SceneManager.LoadScene("NoteSpeedScene");
    }
    public void Volume_SceneChange()
    {
        SceneManager.LoadScene("SettingScene");
    }
    public void SelectScene_SceneChange() 
    {
        SceneManager.LoadScene("SelectTest");
    }
}
