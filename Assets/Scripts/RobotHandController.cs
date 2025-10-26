using UnityEngine;

public class RobotHandController : MonoBehaviour
{
    [Header("Pillar")]
    public Transform pillarJoint;
    public float anglesPillar = 90f;
    [Header("Arm")]
    public Transform armJoint;
    public float anglesArm = 45f;
    [Header("Hand")]
    public Transform handJoint;
    public float anglesHand = 45f;

    [Header("Grab System")]
    public Collider grabCollider;
    public Rigidbody grabbedObject = null;
    public float grabRadius = 0.1f;

    [Header("Values")]
    public float rotationSpeed = 50f;
    private string activeMovementAction = "";

    void Update()
    {
        // SOLO si hay una acción de movimiento activa, llamamos a la rotación
        if (!string.IsNullOrEmpty(activeMovementAction))
        {
            PerformMovement(activeMovementAction);
        }
    }
    public void StartContinuousRotation(string action)
    {
        activeMovementAction = action;
    }

    public void StopContinuousRotation(string action)
    {
        if (activeMovementAction == action)
        {
            activeMovementAction = "";
        }
    }

    private void PerformMovement(string action)
    {
        switch (action)
        {
            case "PillarLeft":
                RotateJointAndClamp(pillarJoint, Vector3.up, 1, -anglesPillar, anglesPillar);
                break;
            case "PillarRight":
                RotateJointAndClamp(pillarJoint, Vector3.up, -1, -anglesPillar, anglesPillar);
                break;
            case "ArmUp":
                RotateJointAndClamp(armJoint, Vector3.right, 1, -anglesArm, anglesArm);
                break;
            case "ArmDown":
                RotateJointAndClamp(armJoint, Vector3.right, -1, -anglesArm, anglesArm);
                break;
            case "HandUp":
                RotateJointAndClamp(handJoint, Vector3.right, 1, -anglesHand, anglesHand);
                break;
            case "HandDown":
                RotateJointAndClamp(handJoint, Vector3.right, -1, -anglesHand, anglesHand);
                break;
            default:
                // Ignoramos acciones desconocidas aquí
                break;
        }
    }

    private void RotateJointAndClamp(Transform joint, Vector3 axis, int direction, float minAngle, float maxAngle)
    {
        float angle = direction * rotationSpeed * Time.deltaTime;
        joint.Rotate(axis, angle, Space.Self);

        Vector3 currentAngles = joint.localEulerAngles;
        float targetAngle = 0f;

        if (axis == Vector3.up)
        {
            targetAngle = currentAngles.y;
        }
        else if (axis == Vector3.forward)
        {
            targetAngle = currentAngles.z;
        }
        else if (axis == Vector3.right)
        {
            targetAngle = currentAngles.x;
        }

        if (targetAngle > 180)
        {
            targetAngle -= 360;
        }

        float clampedAngle = Mathf.Clamp(targetAngle, minAngle, maxAngle);

        if (axis == Vector3.up)
        {
            joint.localRotation = Quaternion.Euler(currentAngles.x, clampedAngle, currentAngles.z);
        }
        else if (axis == Vector3.forward)
        {
            joint.localRotation = Quaternion.Euler(currentAngles.x, currentAngles.y, clampedAngle);
        }
        else if (axis == Vector3.right)
        {
            joint.localRotation = Quaternion.Euler(clampedAngle, currentAngles.y, currentAngles.z);
        }
    }

    public void Grab()
    {
        if (grabbedObject != null) return;
        if (grabCollider == null)
        {
            Debug.LogError("Grab Collider NO ASIGNADO en RobotHandController");
        }


        Collider[] colliders = Physics.OverlapSphere(grabCollider.bounds.center, grabRadius);

        foreach (Collider hit in colliders)
        {
            // Omitimos colliders que pertenecen al propio robot
            if (hit.transform.IsChildOf(this.transform)) continue;

            // Buscamos un Rigidbody agarrable
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            // Si encontramos un objeto con Rigidbody (como Cube_001)
            if (rb != null)
            {
                grabbedObject = rb;

                // 1. Adjuntar: Conviértelo en hijo de la mano
                // El objeto agarrado ahora seguirá la rotación de la mano.
                grabbedObject.transform.SetParent(grabCollider.transform);

                // 2. Controlar la Física: Deshabilita la física
                grabbedObject.isKinematic = true;

                // Opcional: Centrar la posición del objeto agarrado en el punto de agarre
                grabbedObject.transform.localPosition = Vector3.zero;

                Debug.Log($"Objeto {grabbedObject.name} agarrado.");
                return; // Solo agarra un objeto
            }
        }
    }

    public void Release()
    {
        if (grabbedObject != null)
        {
            // 1. Desvincular: Remueve la paternidad para que el objeto sea independiente
            grabbedObject.transform.SetParent(null);

            // 2. Reactivar la Física:
            grabbedObject.isKinematic = false;

            // Opcional: Aplicar un pequeño impulso de liberación (si quieres que 'salga' un poco)
            // grabbedObject.velocity = grabCollider.transform.forward * 1f; 

            grabbedObject = null;
            Debug.Log("Objeto liberado.");
        }
    }
}
