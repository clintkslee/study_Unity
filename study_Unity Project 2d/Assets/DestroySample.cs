using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySample : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject; //����� �� ������Ʈ ����

    private void Awake()
    {
        //�÷��̾� ������Ʈ�� PlayerController ������Ʈ ����      
        //Destroy(playerObject.GetComponent<PlayerController>());

        //���� ���� �ÿ��� ������Ʈ �������ٴ� ������Ʈ ��Ȱ��ȭ�� ���� 
        //playerObject.GetComponent<PlayerController>().enabled = false;

        // �÷��̾� ������Ʈ ����
        //Destroy(playerObject);

        //Destroy(GameObject, time); ���� ������Ʈ�� time �ð���ŭ �帥 �� ���� (time�� �Ǽ� ��)
        //2�� �� �÷��̾� ������Ʈ ����
        //Destroy(playerObject, 2.0f);
    }
}
