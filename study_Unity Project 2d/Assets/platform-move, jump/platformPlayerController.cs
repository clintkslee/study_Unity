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
        // 좌우 이동 제어
        movement2D.Move(x);

        //플레이어 점프
        if (Input.GetKeyDown(KeyCode.Space))
            movement2D.Jump();

        // 스페이스를 누르고 있냐로 높쩜, 낮쩜 판단
        if (Input.GetKey(KeyCode.Space))
            movement2D.isLongjump = true;
        else if (Input.GetKeyUp(KeyCode.Space))
            movement2D.isLongjump = false;
    }
}
