using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SongData", menuName = "楽曲データを作成")]

public class SongData : ScriptableObject
{
    [SerializeField] public string songID;          //楽曲IDを入れる　
    [SerializeField] public string songName;        //楽曲名を入れる
    [SerializeField] public string songDifficult;   //難易度を入れる
    [SerializeField] public string songNameopen;    //表示する楽曲名を入力する
    [SerializeField] public string selectSongName;  //楽曲選択中に流す
    [SerializeField] public string creditName;      //制作者の名前を入れる
    [SerializeField] public string BPM;             //BPMを入力する
    [SerializeField] public float musicLength;      //曲の長さを入れる
    [SerializeField] public int songLevel;          //楽曲のレベルを入れる
    [SerializeField] public Sprite songImage;       //楽曲のイメージ画像を入れる
}
