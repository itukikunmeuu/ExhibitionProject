//-------------------------------------
//ボタンを押したらシーンを変える
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeTitle : MonoBehaviour
{
    // Start is called before the first frame update
    public void Change_button()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
