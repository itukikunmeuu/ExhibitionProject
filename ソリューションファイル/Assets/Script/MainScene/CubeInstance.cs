//-------------------------------------
//�����_����Cube�I�u�W�F�N�g���g�p����(��2�@����g�p���ĂȂ�)
//--------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInstance : MonoBehaviour
{
    //�G�v���n�u
    public GameObject cubePrefab;
    //�e���W�̍ő�l�ƍŏ��l�̐ݒ�
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
        //cube���C���X�^���X������(����������)
        GameObject cube = Instantiate(cubePrefab);
        //���������G�̍��W����
        cube.transform.position = GetRomdomPosition();
        cube.transform.rotation = randRot;
        instance++;
        Destroy(cube, 1.0f);
    }

    //�w�肵�����W�Ƀ����_���Ȉʒu�ɐ���������֐�
    private Vector3 GetRomdomPosition()
    {
        //���ꂼ��̍��W�������_���ɐ�������
        float x = Random.Range(xMinPosition, xMaxPosition);
        float y = yMinPosition;
        float z = Random.Range(zMinPosition, zMaxPosition);
        //Vector3�^��Position��Ԃ�
        return new Vector3(x, y, z);
    }

   


}
