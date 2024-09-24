using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlChangeScenes : MonoBehaviour
{
    [SerializeField] GameObject StartS;
    [SerializeField] GameObject StartR;
    bool isStartFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        StartS.SetActive(true);
        StartR.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isStartFlag == false)
        {
             StartS.SetActive(false);
            StartR.SetActive(true);
            isStartFlag = true;
        }
    }
}
