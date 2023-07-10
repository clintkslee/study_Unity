using UnityEngine;

public class Movement2D : MonoBehaviour
{
    private float moveSpeed = 5.0f;                 // �̵� �ӵ�
    private Rigidbody2D rigid2D;

    private void Awake()
    {
        rigid2D = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");   // �¿� �̵� 
        float y = Input.GetAxisRaw("Vertical");     // ���� �̵�

        // Rigidbody2D ������Ʈ�� �ִ� �ӷ� ���� ����
        rigid2D.velocity = new Vector3(x, y, 0) * moveSpeed;
    }
}
