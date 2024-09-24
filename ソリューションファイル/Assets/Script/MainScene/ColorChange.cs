//マテリアルを虹色に変更するスクリプト　現状は使用してないが今後必要になったとき用
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    //メッシュをぶち込む
    MeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
        //メッシュコンポーネントをぶち込む
        mesh = GetComponent<MeshRenderer>();
        StartCoroutine("Transparent");
    }

    // Update is called once per frame
    IEnumerator Transparent()
    {
        //色を変更する
        for (int i = 0; i < 255; i++)
        {
            mesh.material.color = mesh.material.color - new Color32(0, 0, 0, 1);
            yield return new WaitForSeconds(0.01f);
        }
    }
}