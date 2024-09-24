//-------------------------------------
//キューブの色の変更　現在は使用指定なし
//-------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public GameObject cube;
    public Color startColor;
    public Color endColor;

    [Range(0f, 1f)]
    public float t;
    public AnimationCurve curve;

    MeshRenderer cubeMeshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        cubeMeshRenderer = cube.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        cubeMeshRenderer.material.SetColor("_BaseColor", Color.Lerp(startColor, endColor, curve.Evaluate(t)));
    }
}