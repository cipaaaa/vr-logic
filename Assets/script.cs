using UnityEngine;
using UnityEngine.XR;

public class Whiteboard : MonoBehaviour
{
    private XRGrabInteractable currentInteractable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<XRGrabInteractable>(out XRGrabInteractable interactable))
            currentInteractable = interactable;

        // if (interactable != null)
        // {
        //     currentInteractable = interactable;
        //     currentInteractable.selectExited.AddListener(OnObjectReleased);
        // }
    }

    private void OnTriggerStay(Collider other)
    {
        if (currentInteractable == null)
            return;

        if (!currentInteractable.isSelected)
        {
            currentInteractable.transform.SetParent(this.transform);
            currentInteractable.TryGetComponent<Rigidbody>().enabled = false;
        }

        // if (currentInteractable != null && other.GetComponentInParent<XRGrabInteractable>() == currentInteractable)
        // {
        //     currentInteractable.selectExited.RemoveListener(OnObjectReleased);
        //     currentInteractable = null;
        // }
    }

    // private void OnObjectReleased(SelectExitEventArgs args)
    // {
    //     Debug.Log("Object released inside the trigger box!");
    //
    //     // Execute your placement logic here
    //
    //     // currentInteractable.selectExited.RemoveListener(OnObjectReleased);
    //     // currentInteractable = null;
    // }
}
