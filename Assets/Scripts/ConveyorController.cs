using UnityEngine;

public class ConveyorController : MonoBehaviour
{
    public float speed = 2f;

    private bool isMoving = false;

    public void StartConveyor()
    {
        isMoving = true;
    }

    public void StopConveyor()
    {
        isMoving = false;
    }

    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}