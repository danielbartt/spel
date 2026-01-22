using UnityEngine;

public class movement : MonoBehaviour

{
    private Rigidbody2D rb;
    private Vector3 offset;
    private float zCoord;

    [SerializeField]
    private float dragSpeed = 10f; // Control drag speed here

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true; // Required for manual movement
    }

    void OnMouseDown()
    {
        zCoord = Camera.main.WorldToScreenPoint(transform.position).z;
        offset = transform.position - GetMouseWorldPos();
    }

    void OnMouseDrag()
    {
        Vector2 targetPosition = GetMouseWorldPos() + offset;

        Vector2 newPosition = Vector2.MoveTowards(
            rb.position,
            targetPosition,
            dragSpeed * Time.deltaTime
        );

        rb.MovePosition(newPosition);
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}

