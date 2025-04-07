using UnityEngine;

public abstract class quai : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;

    bool movingToB = true;
    Vector2 targetPosition;

    protected virtual void Start()
    {
        transform.position = pointA.position;
        movingToB = true;
    }

    protected virtual void Update()
    {
        move();
    }

    protected void move()
    {
        if (movingToB)
        {
            targetPosition = pointB.position;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            targetPosition = pointA.position;
            transform.localScale = new Vector3(1, 1, 1);
        }

        var dis = Vector2.Distance(transform.position, targetPosition);

        if (dis < 0.1f)
        {
            movingToB = !movingToB;
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    protected void die()
    {
        Destroy(gameObject);
    }

    public virtual void hit()
    {
        die();
    }
}
