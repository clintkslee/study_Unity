using UnityEngine;

public class CollisionEvent : MonoBehaviour
{
    [SerializeField]
    private Color color;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        spriteRenderer.color = color;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(gameObject.name + "OnCollisionStay2D() 메소드 실행");

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        spriteRenderer.color = Color.white;
    }
}
