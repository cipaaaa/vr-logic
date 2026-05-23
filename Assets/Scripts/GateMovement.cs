using UnityEngine;

public class GateMovement : MonoBehaviour
{
    public float speed = 2f;

    public Transform endPoint;

    public Vector3 targetPosition;

    public ConveyorTextureScroll conveyorScroll;

    private bool stopMoving = false;

    void Update()
    {
        if (!stopMoving)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            if (transform.position.x <= endPoint.position.x)
            {
                stopMoving = true;

                SnapToSlot();
            }
        }
    }

    void SnapToSlot()
    {
        transform.position = targetPosition;

        conveyorScroll.isMoving = false;
    }
}