using UnityEngine;

public class PositionAutoDestroyer : MonoBehaviour
{
    private Vector2 limitMin = new Vector2(-7.5f, -4.5f);
    private Vector2 limitMax = new Vector2(7.5f, 4.5f);

    private void Update()
    {
        if (transform.position.x < limitMin.x || transform.position.x > limitMax.x ||
            transform.position.y < limitMin.y || transform.position.y > limitMax.y)

            // �ҹ��� gameObject�� �ش� ������Ʈ�� �Ҽӵ� ���ӿ�����Ʈ �ǹ�
            Destroy(gameObject);
    }

}
