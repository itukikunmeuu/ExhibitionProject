using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DifficultData", menuName = "難易度データベースを作成")]

public class DifficultData : ScriptableObject
{
    [SerializeField] public SongDataBase[] songDataBase;
}
