using System.Collections.Generic;
using UnityEngine;

// Esta clase es estática y contiene todas las secuencias de diálogo predefinidas
public static class DialogsDatabase
{

    // Variables de Audio
    // ------------------------------------------------------------------------------------------------------------------------------------------
    private static readonly AudioClip arm01_n1_01 = Resources.Load<AudioClip>("Dialogs/Arm 01/arm01_n1_01");
    private static readonly AudioClip arm01_n1_02 = Resources.Load<AudioClip>("Dialogs/Arm 01/arm01_n1_02");
    private static readonly AudioClip arm01_n1_03 = Resources.Load<AudioClip>("Dialogs/Arm 01/arm01_n1_03");
    private static readonly AudioClip arm01_n2_01 = Resources.Load<AudioClip>("Dialogs/Arm 01/arm01_n2_01");
    private static readonly AudioClip arm01_n2_02 = Resources.Load<AudioClip>("Dialogs/Arm 01/arm01_n2_02");
    private static readonly AudioClip arm01_n2_03 = Resources.Load<AudioClip>("Dialogs/Arm 01/arm01_n2_03");
    private static readonly AudioClip arm01_n3_01 = Resources.Load<AudioClip>("Dialogs/Arm 01/arm01_n3_01");
    private static readonly AudioClip arm01_n3_02 = Resources.Load<AudioClip>("Dialogs/Arm 01/arm01_n3_02");
    private static readonly AudioClip arm01_n4_01 = Resources.Load<AudioClip>("Dialogs/Arm 01/arm01_n4_01");
    private static readonly AudioClip arm01_n4_02 = Resources.Load<AudioClip>("Dialogs/Arm 01/arm01_n4_02");
    private static readonly AudioClip arm01_n4_03 = Resources.Load<AudioClip>("Dialogs/Arm 01/arm01_n4_03");
    private static readonly AudioClip arm01_n5_01 = Resources.Load<AudioClip>("Dialogs/Arm 01/arm01_n5_01");
    private static readonly AudioClip arm01_n5_02 = Resources.Load<AudioClip>("Dialogs/Arm 01/arm01_n5_02");
    // ------------------------------------------------------------------------------------------------------------------------------------------
    
    


    /// <summary>
    /// Devuelve la lista de DialogLine para una secuencia específica.
    /// </summary>
    /// <param name="sequenceID">El ID de la secuencia que se desea reproducir (ej: "IntroMision1").</param>
    /// <returns>Una lista de DialogLine.</returns>
    public static List<DialogLine> GetDialogueSequence(string sequenceID)
    {
        switch (sequenceID)
        {
            case "GetArm01":
                return GetArm01();

            default:
                Debug.LogError($"ID de diálogo no encontrado en la base de datos: {sequenceID}");
                return new List<DialogLine>(); // Devuelve una lista vacía si no existe
        }
    }
    
    // =================================================================
    //  AQUÍ DEFINES TODAS TUS SECUENCIAS DE DIÁLOGO
    // =================================================================

    private static List<DialogLine> GetArm01()
    {
        return new List<DialogLine>
        {
            new DialogLine 
            {
                CharacterName = "El Concepto y la Estructura", 
                DialogueText = "¡Hola de nuevo! Soy eBot, tu guía en este viaje por la robótica. En esta primera sección, vamos a desarmar el concepto de los Brazos Robóticos.",
                VoiceLine = arm01_n1_01
            },
            new DialogLine 
            {
                CharacterName = "El Concepto y la Estructura", 
                DialogueText = "Primero que todo, la pregunta clave: ¿Qué son exactamente estos brazos robóticos?",
                VoiceLine = arm01_n1_02
            },
            new DialogLine 
            {
                CharacterName = "El Concepto y la Estructura", 
                DialogueText = "Un brazo robótico es... ¡una máquina superinteligente! Es un dispositivo programable cuyas funciones principales y comportamiento se asemejan al de un brazo humano, buscando replicar lo que hacemos. Estos brazos están interconectados por articulaciones que pueden tener un movimiento de rotación (girar) o de desplazamiento lineal (ir en línea recta).",
                VoiceLine = arm01_n1_03
            },
            new DialogLine 
            {
                CharacterName = "Comparación con el Brazo Humano (Estructura)", 
                DialogueText = "Para que te lo imagines mejor, piensa en un brazo de grúa o en el brazo que tienes ahora mismo.",
                VoiceLine = arm01_n2_01
            },
            new DialogLine 
            {
                CharacterName = "Comparación con el Brazo Humano (Estructura)", 
                DialogueText = "Un brazo mecánico cuenta con una estructura que contiene referencias al brazo humano. Por ejemplo, dependiendo del tipo de brazo, encontraremos componentes que equivalen a nuestra cintura, el hombro, el codo, la muñeca, y hasta la \"mano\" (que llamaremos efector final).",
                VoiceLine = arm01_n2_02
            },
            new DialogLine 
            {
                CharacterName = "Comparación con el Brazo Humano (Estructura)", 
                DialogueText = "Además de esta estructura, puede tener otros elementos electrónicos que le dan vida y más funciones, como: \n" +
                "• Actuadores: Los \"músculos\" que generan movimiento.\n" +
                "• Controladores: El \"cerebro\" que sigue las instrucciones de programación.\n" +
                "• Transmisores: Componentes que ayudan a comunicar el movimiento.\n" +
                "• ¡...y muchos más! Pero vamos de a poquito. 😉",
                VoiceLine = arm01_n2_03
            },
            new DialogLine 
            {
                CharacterName = "Las Súper-Funciones (Aplicaciones)", 
                DialogueText = "Ahora, hablemos de por qué son tan importantes. ¿Qué hace un brazo robótico que tu brazo no puede (o no debería) hacer?",
                VoiceLine = arm01_n3_01
            },
            new DialogLine 
            {
                CharacterName = "Las Súper-Funciones (Aplicaciones)", 
                DialogueText = "En cuanto a sus funciones, piensa en un asistente incansable y ultra preciso. Con un brazo robótico podemos:\n" +
                "• Simular o amplificar las capacidades del brazo humano (levantar algo muy pesado).\n" +
                "• Automatizar procesos de trabajo mecánico, repetitivo y de gran magnitud.\n" +
                "• Trabajar de manera independiente o autónoma.\n" +
                "• Mejorar el rendimiento y la precisión.\n" +
                "• Permitir operaciones complejas o trabajar en ambientes peligrosos.\n" +
                "• Dar mayor seguridad a los trabajadores (al reemplazar humanos en tareas de riesgo).\n" +
                "•	Reducir costos de producción a largo plazo.",
                VoiceLine = arm01_n3_02
            },
            new DialogLine 
            {
                CharacterName = "#4. ¿Dónde y Cómo se Usan?", 
                DialogueText = "Entonces, ¿dónde vive toda esta acción?",
                VoiceLine = arm01_n4_01
            },
            new DialogLine 
            {
                CharacterName = "#4. ¿Dónde y Cómo se Usan?", 
                DialogueText = "Estos brazos se utilizan en Fábricas (líneas de ensamblaje de carros o celulares), Industrias (soldadura, pintura), Almacenes (empaquetado y transporte), Talleres... Básicamente, en cualquier lugar donde necesiten la creación de estructuras o transportar elementos de un lado a otro de forma rápida y constante.",
                VoiceLine = arm01_n4_02
            },
            new DialogLine 
            {
                CharacterName = "#4. ¿Dónde y Cómo se Usan?", 
                DialogueText = "Y, ¿cómo les decimos qué hacer? Podemos controlarlos de varias maneras:\n" +
                "• Programación por computadora (se le dan instrucciones de movimiento exactas).\n" +
                "• Control remoto (un humano lo opera en tiempo real).\n" +
                "• Sensores (para que reaccione a su entorno, como evitar un obstáculo).",
                VoiceLine = arm01_n4_03
            },
            new DialogLine 
            {
                CharacterName = "¡A la Práctica! (Interactividad)", 
                DialogueText = "¡Muy bien! Hemos cubierto lo esencial.",
                VoiceLine = arm01_n5_01
            },
            new DialogLine 
            {
                CharacterName = "¡A la Práctica! (Interactividad)", 
                DialogueText = "A continuación, a tu izquierda, tienes un brazo robótico sencillo de ejemplo. ¡Prueba a manejarlo! Observa cómo un comando se traduce en movimiento físico.",
                VoiceLine = arm01_n5_02
            },
        };
    }
}