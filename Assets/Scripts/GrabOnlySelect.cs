using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class GrabOnlySelect : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrabStart);
            grabInteractable.selectExited.AddListener(OnGrabEnd);
        }
    }
    
    private void OnGrabStart(SelectEnterEventArgs args)
    {
        Debug.Log("Grab es TRUE. Object: "+args.interactableObject.transform.name);
    }
    private void OnGrabEnd(SelectExitEventArgs args)
    {
        Debug.Log("Grab es FALSE. Object: " + args.interactableObject.transform.name);
    }

    void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrabStart);
            grabInteractable.selectExited.RemoveListener(OnGrabEnd);
        }
    }
}
