using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Whiteboard : MonoBehaviour
{
    private XRGrabInteractable currentInteractable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<XRGrabInteractable>(out XRGrabInteractable interactable))
            currentInteractable = interactable;
    }

    private void OnTriggerStay(Collider other)
    {
        if (currentInteractable == null)
            return;

        if (!currentInteractable.isSelected)
        {
            currentInteractable.transform.SetParent(this.transform);
            currentInteractable.gameObject.GetComponent<Rigidbody>().useGravity = false;
            currentInteractable = null;
        }
    }
}
