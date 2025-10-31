using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public static DialogController Instance;

    [Header("UI References")]
    public GameObject DialogUIPanel;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI DialogueText;
    public AudioSource AudioPlayer;

    [Header("Typewriter Effect Settings")]
    [Tooltip("Tiempo de espera (s) entre la impresión de cada letra")]
    public float typeDelay = 0.05f;

    private List<DialogLine> currentDialogue;
    private int currentLineIndex = 0;
    private bool isDialogueActive = false;
    private Coroutine typeCoroutine;

    [Header("UI Control")]
    [Tooltip("Asignar el componente Button (no el objeto) del botón de 'Siguiente'.")]
    public Button nextButton;
    private bool isAudioPlaying = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (DialogUIPanel != null)
        {
            DialogUIPanel.SetActive(false);
        }

        if (AudioPlayer == null)
        {
            AudioPlayer = GetComponent<AudioSource>();
            if (AudioPlayer == null)
            {
                AudioPlayer = gameObject.AddComponent<AudioSource>();
            }
        }
    }

    /// <summary>
    /// FUNCION PRINCIPAL: Busca y reproduce la secuencia de diálogo por su ID.
    /// </summary>
    public void StartDialogueByID(string sequenceID)
    {
        if (isDialogueActive)
        {
            Debug.LogWarning("Ya hay un diálogo activo. Ignorando solicitud para iniciar: " + sequenceID);
            return;
        }

        List<DialogLine> dialogueLines = DialogsDatabase.GetDialogueSequence(sequenceID);

        if (dialogueLines.Count > 0)
        {
            StartDialogue(dialogueLines);
        }
        else
        {
            Debug.LogError($"Secuencia de diálogo con ID '{sequenceID}' no pudo ser iniciada.");
        }
    }

    private void StartDialogue(List<DialogLine> dialogLines)
    {
        currentDialogue = dialogLines;
        currentLineIndex = 0;
        isDialogueActive = true;

        if (DialogUIPanel != null)
        {
            DialogUIPanel.SetActive(true);
        }

        DisplayNextLine();
    }

    /// <summary>
    /// Llamado por el botón 'Next'.
    /// </summary>
    public void DisplayNextLine()
    {
        if (!isDialogueActive) return;

        if (isAudioPlaying)
        {
            Debug.LogWarning("Audio en reproducción. Avance bloqueado");
            return;
        }

        if (typeCoroutine != null)
        {
            StopCoroutine(typeCoroutine);
            typeCoroutine = null;
            DialogueText.text = currentDialogue[currentLineIndex - 1].DialogueText;
            if (nextButton != null) nextButton.interactable = true;
            return;
        }

        if (currentLineIndex < currentDialogue.Count)
        {
            DialogLine line = currentDialogue[currentLineIndex];
            NameText.text = line.CharacterName;
            // DialogueText.text = line.DialogueText;

            if (nextButton != null) nextButton.interactable = false;

            float clipDuration = 0f;

            if (line.VoiceLine != null && AudioPlayer != null)
            {
                AudioPlayer.PlayOneShot(line.VoiceLine);
                isAudioPlaying = true;
                clipDuration = line.VoiceLine.length;
            }

            typeCoroutine = StartCoroutine(TypeTextAndWaitForAudio(line.DialogueText, clipDuration));

            currentLineIndex++;
        }
        else
        {
            EndDialogue();
        }
    }

    private IEnumerator TypeTextAndWaitForAudio(string textToType, float AudioDuration)
    {
        DialogueText.text = "";

        foreach (char letter in textToType.ToCharArray())
        {
            DialogueText.text += letter;
            yield return new WaitForSeconds(typeDelay);
        }

        typeCoroutine = null;

        if (AudioDuration > 0f)
        {
            yield return new WaitForSeconds(AudioDuration);
            isAudioPlaying = false;
        }
        
        if(nextButton != null)
        {
            nextButton.interactable = true;
            Debug.Log("Audio y texto finalizados. Botón 'Siguiente' habilitado.");
        }
    }
    
    private void EndDialogue(){
        isDialogueActive = false;
        if (DialogUIPanel != null) {
            DialogUIPanel.SetActive(false);
        }
        currentDialogue = null;
        Debug.Log("Diálogo finalizado.");
    }
}
