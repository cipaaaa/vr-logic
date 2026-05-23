using UnityEngine;

public class SimpleVRSimulator : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;

    [Header("References")]
    public Transform playerRig;
    public GameObject teleportMarker;

    [Header("Teleport")]
    public float teleportDistance = 20f;

    private Camera cam;

    private float xRotation = 0f;

    void Start()
    {
        cam = GetComponent<Camera>();

        Cursor.lockState =
            CursorLockMode.Locked;

        teleportMarker.SetActive(false);
    }

    void Update()
    {
        Move();
        Look();
        Teleport();
    }

    void Move()
    {
        float h =
            Input.GetAxis("Horizontal");

        float v =
            Input.GetAxis("Vertical");

        Vector3 move =
            playerRig.forward * v +
            playerRig.right * h;

        move.y = 0;

        playerRig.position +=
            move * moveSpeed * Time.deltaTime;
    }

    void Look()
    {
        float mouseX =
            Input.GetAxis("Mouse X") *
            mouseSensitivity;

        float mouseY =
            Input.GetAxis("Mouse Y") *
            mouseSensitivity;

        xRotation -= mouseY;

        xRotation =
            Mathf.Clamp(xRotation, -80f, 80f);

        cam.transform.localRotation =
            Quaternion.Euler(
                xRotation,
                0,
                0
            );

        playerRig.Rotate(
            Vector3.up * mouseX
        );
    }

    void Teleport()
    {
        // HOLD RIGHT CLICK
        if (Input.GetMouseButton(1))
        {
            Ray ray =
                new Ray(
                    cam.transform.position,
                    cam.transform.forward
                );

            RaycastHit hit;

            if (Physics.Raycast(
                ray,
                out hit,
                teleportDistance
            ))
            {
                teleportMarker.SetActive(true);

                teleportMarker.transform.position =
                    hit.point +
                    Vector3.up * 0.02f;

                // LEFT CLICK = TELEPORT
                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 pos =
                        playerRig.position;

                    pos.x = hit.point.x;
                    pos.z = hit.point.z;

                    playerRig.position = pos;
                }
            }
        }
        else
        {
            teleportMarker.SetActive(false);
        }
    }
}