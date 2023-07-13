using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode keyCodeFire = KeyCode.Space;
    [SerializeField]
    private GameObject bulletPrefab;
    private float moveSpeed = 3.0f;

    private Vector3 lastMoveDirection = Vector3.right;

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(x, y, 0) * moveSpeed * Time.deltaTime;

        // 마지막에 입력된 방향을 총알의 발사 방향으로 사용
        if(x!=0 || y!=0)
            lastMoveDirection = new Vector3(x, y, 0);       

        if (Input.GetKeyDown(keyCodeFire))
        {
            GameObject clone = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            clone.name = "Bullet";
            clone.transform.localScale = Vector3.one * 0.5f;
            clone.GetComponent<SpriteRenderer>().color = Color.red;
            clone.GetComponent<Movement2D2>().Setup(lastMoveDirection); //총알의 이동
           
        }    
    }
}
