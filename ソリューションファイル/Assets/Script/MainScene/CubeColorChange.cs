using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColorChange : MonoBehaviour
{
    //変更
    int color = 0;

    //データベースを入れる
    [SerializeField] SongDataBase dataBase;

    [SerializeField] GameObject objEasy;
    [SerializeField] GameObject objNormal;
    [SerializeField] GameObject objExpert;
    [SerializeField] GameObject objMaster;

    // Start is called before the first frame update
    void Start()
    {
        color = GManager.instance.songID;
    }

    // Update is called once per frame
    void Update()
    {
        if(color <= 9)
        {
            objEasy.SetActive(true);
            objNormal.SetActive(false);
            objExpert.SetActive(false);
            objMaster.SetActive(false);

        }
        else if(color <= 19) 
        {
            objEasy.SetActive(false);
            objNormal.SetActive(true);
            objExpert.SetActive(false);
            objMaster.SetActive(false);
        }
        else if (color == 29)
        {
            objEasy.SetActive(false);
            objNormal.SetActive(false);
            objExpert.SetActive(true);
            objMaster.SetActive(false);
        }
        else if (color == 39)
        {
            objEasy.SetActive(false);
            objNormal.SetActive(false);
            objExpert.SetActive(false);
            objMaster.SetActive(true);
        }
    }
}
