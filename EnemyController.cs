using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy Movement")]
    public float moveSpeed = 2f;
    public Transform pointA;
    public Transform pointB;

    private bool movingToB = true;

    void Update()
    {
        if (movingToB)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointB.position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, pointB.position) < 0.1f)
                movingToB = false;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, pointA.position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, pointA.position) < 0.1f)
                movingToB = true;
        }
    }
}
