using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    public float rotateSpeed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (target == null)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
        }
    }

    void FixedUpdate()
    {
        // move forward
        rb.linearVelocity = transform.up * speed;
    }

    void RotateTowardsTarget()
    {
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        rb.rotation = Mathf.LerpAngle(
            rb.rotation,
            angle,
            rotateSpeed * Time.fixedDeltaTime
        );
    }
 
    void GetTarget()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            target = player.transform;
    }
}