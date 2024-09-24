using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeI : MonoBehaviour
{
    //変数の宣言
    [SerializeField] private GameObject[] CubeObj;

    //変数の最大値と最小値を決める
    public float MaxInstance = 7;
    public float MinInstance = 0;
    //インスタンスの生成部分
    public float instance;

    // Update is called once per frame
    void Update()
    {
        //各キーが押されたときにインスタンスクラスを呼び出す
        if (Input.GetKeyDown(KeyCode.D))
        {
            Instance();
            Message(instance);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instance();
            Message(instance);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Instance();
            Message(instance);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Instance();
            Message(instance);
        }
    }

    //必要な際にランダム関数を呼び出してランダムにオブジェクトを表示させる
    private void Instance()
    {
        //必要な時に呼び出す
        instance = Random.Range(MinInstance, MaxInstance);
    }
    //オブジェクトを生成する
    void Message(float cube)
    {
        Instantiate(CubeObj[(int)cube]);
    }
}
