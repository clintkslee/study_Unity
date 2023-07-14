using JetBrains.Annotations;
using UnityEngine;

public class platformMovement2D : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    
    [SerializeField]
    private float jumpForce = 8.0f;
    
    private Rigidbody2D rigid2D;

    [HideInInspector] //인스펙터뷰에 보이지 않게 설정
    public bool isLongjump = false; // 낮은 점프, 높은 점프 체크

    [SerializeField]
    private LayerMask groundLayer; // 바닥 체크 위한 충돌 레이어                   
    private CapsuleCollider2D capsuleCollider2D; //플레이어 오브젝트의 충돌 범위 컴포넌트
    private bool isGrounded; // 바닥 체크(바닥에 닿으면 true)
    private Vector3 footPosition; //발의 위치

    // 유니티 레이어(LayerMask 타입)의 역할
    // 오브젝트가 그려지는 순서 설정 가능
    // 오브젝트 충돌에서 지정한 레이어와의 충돌을 제외 가능
    // Edit - project setting - physics 에서 레이어끼리의 collider 충돌 처리 설정 가능

    [SerializeField]
    private int maxJumpCount = 2;   // 최대 점프 가능 횟수
    private int currentJumpCount = 0;   // 현재 가능한 점프 횟수




    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    private void FixedUpdate()
    {
        // 플레이어 오브젝트의 Collider2D min, center, max 정보
        Bounds bounds = capsuleCollider2D.bounds; // 바운드는 캡슐 콜라이더의 범위를 의미, 좌하단이 bounds.min, 좌상단이 bounds.max, 중앙이 bounds.cener
        // 플레이어의 발 위치 설정
        footPosition = new Vector2(bounds.center.x, bounds.min.y); // 콜라이더 범위 중앙 밑을 발 위치로 설정
        //플레이어의 발 위치에 원을 생성하고, 원이 바닥과 닿으면 isGrounded=true
        // OverlapCircle() : 범위와 레이어를 설정해 해당 범위에 충돌한 오브젝트를 검출하는 함수
        // OverlapCircle(위치, 반지름, 레이어) 지정한 위치에 반지름 크기의 보이지 않는 원 충돌범위 생성, groundLayer 레이어에 속한 오브젝트 충돌을 체크하고 값 반환
        isGrounded = Physics2D.OverlapCircle(footPosition, 0.1f, groundLayer);

        // 플레이어의 발이 땅에 닿아있고, y축 속도가 0이하이면 점프 횟수 초기화
        // velocity.y <= 0 추가핮 ㅣ않으면 점프키를 누르는 순간에도 초기화가 되어 최대 점프 횟수를 2로 설정 시 3회 점프 가능
        if (isGrounded == true && rigid2D.velocity.y <= 0)
            currentJumpCount = maxJumpCount;

        // 낮쩜, 높쩜 구현 위해 rigid2D.gravityScale 조절
        // 중력 계수가 낮은 if문은 높은 점프가 되고, 중력계수가 높은 else문은 낮은 점프가 된다
        // 점프가 올라가는 상태에서만 판단
        if (isLongjump && rigid2D.velocity.y > 0) //점프키를 계속 누르고 있을 때
            rigid2D.gravityScale = 1.0f;
        else // 점프키를 계속 누르고 있지 않고 빨리 뗐을 때
            rigid2D.gravityScale = 2.5f;
    }
    // 플레이어에게 가해지는 중력은 (0, -9.81, 0) * gravityScale 만큼이다
    // gravityScale이 1이면 transform.position += (0, -9.81, 0) 이 추가 되는 것

    public void Move(float x) //외부의 다른 클래스에서 호출된다
    {
        // x축 이동은 x*speed, y축 이동은 기존의 속력값(중력)
        rigid2D.velocity = new Vector2(x * speed, rigid2D.velocity.y);
    }

    //씬 뷰에서만 보이는 물체를 그릴때 사용하는 함수(위에서 붙인 발 위치에 그림)
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(footPosition, 0.1f);
    }


    public void Jump()
    {
        if(currentJumpCount > 0)
        {
            //jumpForce 크기 만큼 위쪽 방향으로 속력 설정
            // rigid2D.velocity.y 는 지면(점프키 누름)에서 8로 시작해 점점 감소하다가(중력 영향) 최고 지점에서 0값
            rigid2D.velocity = Vector2.up * jumpForce;
            // 점프가능횟수 1감소
            currentJumpCount--;
        }
    }
}

