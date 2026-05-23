using UnityEngine;

public class MagnetObject : MonoBehaviour
{
    public bool isAttached { get; set; }
    public float constantAttach { get; set; }

    private void Update()
    {
        if (isAttached)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, constantAttach);
        }
    }
}
