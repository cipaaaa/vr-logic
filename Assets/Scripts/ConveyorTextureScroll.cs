using UnityEngine;

public class ConveyorTextureScroll : MonoBehaviour
{
    public float scrollSpeed = 2f;

    private Renderer rend;

    public bool isMoving = false;

    private float offset = 0f;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (isMoving)
        {
            offset += Time.deltaTime * scrollSpeed;

            rend.material.mainTextureOffset =
                new Vector2(offset, 0);
        }
    }
}