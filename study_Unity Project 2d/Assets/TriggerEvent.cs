using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    [SerializeField] //움직일 다른 게임오브젝트 등록하여 맞닿은 두 물체가 아닌 다른 물체의 색 변경
    private GameObject moveObject;

    [SerializeField]
    private Vector3 moveDirection;
    private float moveSpeed;

    private void Awake()
    {
        moveSpeed = 5.0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // moveObject 의 색상을 검은색으로 설정
        moveObject.GetComponent<SpriteRenderer>().color = Color.black;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        moveObject.transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //moveObject의 색상을 흰색으로 설정
        moveObject.GetComponent<SpriteRenderer>().color = Color.white;
        //moveObject의 위치를 (0,4,0)으로 설정
        moveObject.transform.position = new Vector3(0, 4, 0);
    }
}
