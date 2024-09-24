//-------------------------------------
//虹色にするスクリプト
//-------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainbow : MonoBehaviour
{
    public GameObject tile;
    // Start is called before the first frame update
    void Start()
    {
        float count = 0;

        for (int i = 0; i <= 30; i++)
        {
            GameObject obj = Instantiate(tile, new Vector3(0f, 0f, -1f * i), Quaternion.identity);
            //obj.GetComponent<ColorChange>().initial = count;
            //インスタンス化したオブジェクトのColorChangeスクリプト内にある変数initialにcountを代入
            count += 0.1f;
            //countの値を0.1ずつ変える
            //countの増加幅を小さくするほど、タイル間の色相がなめらかに変化します
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
