using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformPlayerController : MonoBehaviour
{
    private platformMovement2D movement2D;

    private void Awake()
    {
        movement2D = GetComponent<platformMovement2D>();
    }

    private void Update()
    {
        // left, a : -1     right, d : 1
        float x = Input.GetAxisRaw("Horizontal");
        // �¿� �̵� ����
        movement2D.Move(x);

        //�÷��̾� ����
        if (Input.GetKeyDown(KeyCode.Space))
            movement2D.Jump();

        // �����̽��� ������ �ֳķ� ����, ���� �Ǵ�
        if (Input.GetKey(KeyCode.Space))
            movement2D.isLongjump = true;
        else if (Input.GetKeyUp(KeyCode.Space))
            movement2D.isLongjump = false;
    }
}
