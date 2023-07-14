using JetBrains.Annotations;
using UnityEngine;

public class platformMovement2D : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    
    [SerializeField]
    private float jumpForce = 8.0f;
    
    private Rigidbody2D rigid2D;

    [HideInInspector] //�ν����ͺ信 ������ �ʰ� ����
    public bool isLongjump = false; // ���� ����, ���� ���� üũ

    [SerializeField]
    private LayerMask groundLayer; // �ٴ� üũ ���� �浹 ���̾�                   
    private CapsuleCollider2D capsuleCollider2D; //�÷��̾� ������Ʈ�� �浹 ���� ������Ʈ
    private bool isGrounded; // �ٴ� üũ(�ٴڿ� ������ true)
    private Vector3 footPosition; //���� ��ġ

    // ����Ƽ ���̾�(LayerMask Ÿ��)�� ����
    // ������Ʈ�� �׷����� ���� ���� ����
    // ������Ʈ �浹���� ������ ���̾���� �浹�� ���� ����
    // Edit - project setting - physics ���� ���̾���� collider �浹 ó�� ���� ����

    [SerializeField]
    private int maxJumpCount = 2;   // �ִ� ���� ���� Ƚ��
    private int currentJumpCount = 0;   // ���� ������ ���� Ƚ��




    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    private void FixedUpdate()
    {
        // �÷��̾� ������Ʈ�� Collider2D min, center, max ����
        Bounds bounds = capsuleCollider2D.bounds; // �ٿ��� ĸ�� �ݶ��̴��� ������ �ǹ�, ���ϴ��� bounds.min, �»���� bounds.max, �߾��� bounds.cener
        // �÷��̾��� �� ��ġ ����
        footPosition = new Vector2(bounds.center.x, bounds.min.y); // �ݶ��̴� ���� �߾� ���� �� ��ġ�� ����
        //�÷��̾��� �� ��ġ�� ���� �����ϰ�, ���� �ٴڰ� ������ isGrounded=true
        // OverlapCircle() : ������ ���̾ ������ �ش� ������ �浹�� ������Ʈ�� �����ϴ� �Լ�
        // OverlapCircle(��ġ, ������, ���̾�) ������ ��ġ�� ������ ũ���� ������ �ʴ� �� �浹���� ����, groundLayer ���̾ ���� ������Ʈ �浹�� üũ�ϰ� �� ��ȯ
        isGrounded = Physics2D.OverlapCircle(footPosition, 0.1f, groundLayer);

        // �÷��̾��� ���� ���� ����ְ�, y�� �ӵ��� 0�����̸� ���� Ƚ�� �ʱ�ȭ
        // velocity.y <= 0 �߰��F �Ӿ����� ����Ű�� ������ �������� �ʱ�ȭ�� �Ǿ� �ִ� ���� Ƚ���� 2�� ���� �� 3ȸ ���� ����
        if (isGrounded == true && rigid2D.velocity.y <= 0)
            currentJumpCount = maxJumpCount;

        // ����, ���� ���� ���� rigid2D.gravityScale ����
        // �߷� ����� ���� if���� ���� ������ �ǰ�, �߷°���� ���� else���� ���� ������ �ȴ�
        // ������ �ö󰡴� ���¿����� �Ǵ�
        if (isLongjump && rigid2D.velocity.y > 0) //����Ű�� ��� ������ ���� ��
            rigid2D.gravityScale = 1.0f;
        else // ����Ű�� ��� ������ ���� �ʰ� ���� ���� ��
            rigid2D.gravityScale = 2.5f;
    }
    // �÷��̾�� �������� �߷��� (0, -9.81, 0) * gravityScale ��ŭ�̴�
    // gravityScale�� 1�̸� transform.position += (0, -9.81, 0) �� �߰� �Ǵ� ��

    public void Move(float x) //�ܺ��� �ٸ� Ŭ�������� ȣ��ȴ�
    {
        // x�� �̵��� x*speed, y�� �̵��� ������ �ӷ°�(�߷�)
        rigid2D.velocity = new Vector2(x * speed, rigid2D.velocity.y);
    }

    //�� �信���� ���̴� ��ü�� �׸��� ����ϴ� �Լ�(������ ���� �� ��ġ�� �׸�)
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(footPosition, 0.1f);
    }


    public void Jump()
    {
        if(currentJumpCount > 0)
        {
            //jumpForce ũ�� ��ŭ ���� �������� �ӷ� ����
            // rigid2D.velocity.y �� ����(����Ű ����)���� 8�� ������ ���� �����ϴٰ�(�߷� ����) �ְ� �������� 0��
            rigid2D.velocity = Vector2.up * jumpForce;
            // ��������Ƚ�� 1����
            currentJumpCount--;
        }
    }
}

