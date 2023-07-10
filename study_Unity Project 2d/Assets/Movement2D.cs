using UnityEngine;

public class Movement2D : MonoBehaviour
{
    private float moveSpeed = 5.0f;                 // 이동 속도
    private Rigidbody2D rigid2D;

    private void Awake()
    {
        rigid2D = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");   // 좌우 이동 
        float y = Input.GetAxisRaw("Vertical");     // 상하 이동

        // Rigidbody2D 컴포넌트에 있는 속력 변수 설정
        rigid2D.velocity = new Vector3(x, y, 0) * moveSpeed;
    }
}
