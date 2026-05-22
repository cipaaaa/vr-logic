using UnityEngine;

public class GateSpawner : MonoBehaviour
{
    public GameObject andPrefab;
    public GameObject orPrefab;
    public GameObject norPrefab;
    public GameObject inputPrefab;

    public Transform endPoint;

    public Transform outputSlot;

    public float spacing = 2f;

    public ConveyorTextureScroll conveyorScroll;

    private Vector3 nextSlotPosition;

    void Start()
    {
        nextSlotPosition = outputSlot.position;
    }

    public void SpawnAND()
    {
        SpawnGate(andPrefab);
    }

    public void SpawnOR()
    {
        SpawnGate(orPrefab);
    }

    public void SpawnNOR()
    {
        SpawnGate(norPrefab);
    }

    public void SpawnINPUT()
    {
        SpawnGate(inputPrefab);
    }

    void SpawnGate(GameObject gatePrefab)
    {
        conveyorScroll.isMoving = true;

        GameObject newGate =
            Instantiate(gatePrefab, transform.position, Quaternion.identity);

        GateMovement movement =
            newGate.GetComponent<GateMovement>();

        movement.endPoint = endPoint;

        movement.targetPosition = nextSlotPosition;

        movement.conveyorScroll = conveyorScroll;

        nextSlotPosition += new Vector3(spacing, 0, 0);

        endPoint.position = nextSlotPosition;
    }
}