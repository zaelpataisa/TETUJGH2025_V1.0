using UnityEngine;

[System.Serializable] 
public class DialogLine
{
    [Tooltip("El nombre del personaje que habla.")]
    public string CharacterName; 

    [Tooltip("El texto completo del diálogo.")]
    [TextArea(3, 5)] 
    public string DialogueText;

    [Tooltip("Opcional: Sonido a reproducir con esta línea.")]
    public AudioClip VoiceLine; 
}