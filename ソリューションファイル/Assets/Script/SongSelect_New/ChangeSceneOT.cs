using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOT : MonoBehaviour
{
    [SerializeField] GameObject optionObj;
    [SerializeField] GameObject titleObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("TitleScene");
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene("OptionScene");
        }
    }
}
