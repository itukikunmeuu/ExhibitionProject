//-------------------------------------
//ランダムでCubeオブジェクトを使用する(案2　現状使用してない)
//--------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInstance : MonoBehaviour
{
    //敵プレハブ
    public GameObject cubePrefab;
    //各座標の最大値と最小値の設定
    public float xMinPosition = -6;
    public float xMaxPosition = 6;

    public float yMinPosition = -1;

    public float zMinPosition = 4;
    public float zMaxPosition = 7;

    public float maxInstance = 8;
    public float instance = 0;
    private float deleteTime = 5;
    private float time = 0;

    void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Instance();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instance();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Instance();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Instance();
        }
    }

    private void Instance()
    {
        var randRot = Random.rotation;
        //cubeをインスタンス化する(生成させる)
        GameObject cube = Instantiate(cubePrefab);
        //生成した敵の座標決定
        cube.transform.position = GetRomdomPosition();
        cube.transform.rotation = randRot;
        instance++;
        Destroy(cube, 1.0f);
    }

    //指定した座標にランダムな位置に生成させる関数
    private Vector3 GetRomdomPosition()
    {
        //それぞれの座標をランダムに生成する
        float x = Random.Range(xMinPosition, xMaxPosition);
        float y = yMinPosition;
        float z = Random.Range(zMinPosition, zMaxPosition);
        //Vector3型のPositionを返す
        return new Vector3(x, y, z);
    }

   


}
