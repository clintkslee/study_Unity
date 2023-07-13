using System.Collections;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 벽에 부딪힌 오브젝트 삭제
        Destroy(collision.gameObject);
        // 충돌 시 벽면 색 잠깐 변경 (매개변수 함수명)
        StartCoroutine("HitAnimation");
    }

    private IEnumerator HitAnimation()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    } 
}
