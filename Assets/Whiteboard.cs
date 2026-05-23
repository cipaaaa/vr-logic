using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Whiteboard : MonoBehaviour
{
    private XRGrabInteractable currentInteractable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<XRGrabInteractable>(out XRGrabInteractable interactable))
        {
            currentInteractable = interactable;
            // Debug.Log("TEST");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (currentInteractable == null)
            return;

        if (!currentInteractable.isSelected)
        {
            // Debug.Log("magnet");
            currentInteractable.transform.SetParent(this.transform);

            MagnetObject mo = currentInteractable.gameObject.GetComponent<MagnetObject>();
            mo.isAttached = true;
            mo.constantAttach = transform.position.z;

            Rigidbody currRb = currentInteractable.gameObject.GetComponent<Rigidbody>();
            currRb.useGravity = false;
            currRb.constraints = RigidbodyConstraints.FreezeAll;

            currentInteractable.transform.position = new Vector3(currentInteractable.transform.position.x, currentInteractable.transform.position.y, transform.position.z);
            currentInteractable = null;
        }
    }
}
