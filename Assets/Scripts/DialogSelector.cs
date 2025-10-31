using UnityEngine;

public class MissionSelector : MonoBehaviour
{
    [Header("ID de Diálogo")]
    [Tooltip("El ID de la secuencia que debe iniciar (ej: IntroMision1)")]
    public string DialogueToPlayID; 

    void Start()
    {
        // Esta línea asegura que el diálogo comience tan pronto como la escena esté lista
        PlaySelectedDialogue();
    }

    public void PlaySelectedDialogue()
    {
        if (DialogController.Instance != null)
        {
            // Pide al controlador que inicie la secuencia con el ID que definiste en el Inspector
            DialogController.Instance.StartDialogueByID(DialogueToPlayID);
        }
        else
        {
            Debug.LogError("Error: DialogController no encontrado.");
        }
    }
}