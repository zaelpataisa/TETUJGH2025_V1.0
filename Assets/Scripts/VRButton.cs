using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(XRSimpleInteractable))]
public class VRButton : MonoBehaviour
{
    [Tooltip("El script principal del brazo robótico")]
    public RobotHandController controller;

    [Tooltip("La acción que este botón activa (ej: PillarLeft, Grab, Release)")]
    public string actionName;

    [Header("Visual Feedback")]
    public MeshRenderer buttonRenderer;
    public Material defaultMaterial;
    public Material pressedMaterial;

    void Start()
    {
        // Opcional: Asegurarse de que el botón comience con el material por defecto
        if (buttonRenderer != null && defaultMaterial != null)
        {
            buttonRenderer.material = defaultMaterial;
        }
    }

    // Se llama cuando el usuario COMIENZA a interactuar (Presiona el botón)
    public void OnButtonPressed(SelectEnterEventArgs args)
    {
        if (buttonRenderer != null && pressedMaterial != null)
        {
            buttonRenderer.material = pressedMaterial;
        }

        if (controller == null) return;

        // Comprobamos si es una acción de MOVIMIENTO
        if (actionName.StartsWith("Pillar") || actionName.StartsWith("Arm") || actionName.StartsWith("Hand"))
        {
            // Le decimos al controlador que inicie la rotación continua con esta acción
            controller.StartContinuousRotation(actionName);
        }
        else if (actionName == "Grab")
        {
            controller.Grab();
        }
    }

    // Se llama cuando el usuario TERMINA la interacción (Suelto el botón)
    public void OnButtonReleased(SelectExitEventArgs args)
    {
        if (buttonRenderer != null && defaultMaterial != null)
        {
            buttonRenderer.material = defaultMaterial;
        }

        if (controller == null) return;

        // Si es una acción de MOVIMIENTO, le decimos que se detenga
        if (actionName.StartsWith("Pillar") || actionName.StartsWith("Arm") || actionName.StartsWith("Hand"))
        {
            controller.StopContinuousRotation(actionName);
        }
        else if (actionName == "Release")
        {
            controller.Release();
        }
    }
}