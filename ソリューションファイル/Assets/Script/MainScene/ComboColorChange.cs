//--------------------------------------
//コンボ数に応じてテキストの色を変更する
//--------------------------------------
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComboColorChange : MonoBehaviour
{
    //テキストのオブジェクトを入れる箱
    [SerializeField]TextMeshProUGUI colorText;
    [SerializeField]TextMeshProUGUI colorTextSum;

    //アニメーション
    Animation animation;

    //コンボ数確認のためのもの
    int combo;

    // Start is called before the first frame update
    void Start()
    {
        //色のタグをtrueにする(こうすることでα値の変更が可能になる)
        colorText.overrideColorTags = true;
        colorTextSum.overrideColorTags = true;
        //色の変更(初期色は白)
        colorText.color= new Color(255, 255, 255, 50);
        colorTextSum.color = new Color(255, 255, 255, 50);
        //アニメーションの初期設定
        animation = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        //GManagerからコンボ数を取得して現在のコンボに応じてアニメーションを再生するのかしないのか決める変数
        if (GManager.instance.combo > combo)
        {
            animation.Rewind();
            animation.Play();
            combo++;
            if(GManager.instance.combo == 0)
            {
                combo = 0;
            }
        }

        //コンボ数が10コンボ以上だった場合テキストを白色にする処理
        if(GManager.instance.combo <= 10)
        {
            colorText.overrideColorTags = true;
            colorTextSum.overrideColorTags = true;
            colorText.color= new Color32(255,255,255,50);
            colorTextSum.color= new Color32(255, 255, 255,50);
        }
        else if(GManager.instance.combo > 50)
        {
            //コンボ数が50コンボ以上になった際にオレンジ色に変更する処理
            colorText.overrideColorTags = true;
            colorTextSum.overrideColorTags = true;
            colorText.color= new Color32(238, 120, 0,50);
            colorTextSum.color = new Color32(238, 120, 0, 50);
        }
    }
}
