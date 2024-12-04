// Importación de las bibliotecas necesarias para trabajar con colecciones y Unity
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Definición de la clase AudioManager, que controla la reproducción de audios en la escena.
public class AudioManager : MonoBehaviour
{
    // Instancia estática de AudioManager para acceder desde cualquier parte del código.
    public static AudioManager instance;

    // Lista para almacenar los objetos de audio activos (aquellos que están reproduciéndose).
    private List<GameObject> activeAudios;

    // Método Awake se llama cuando el script se carga, antes de Start.
    private void Awake()
    {
        // Verifica si ya existe una instancia de AudioManager.
        if (!instance)
        {
            // Si no existe, la actual se convierte en la instancia única.
            instance = this;

            // Asegura que este objeto no se destruya al cambiar de escena.
            DontDestroyOnLoad(gameObject);

            // Inicializa la lista que almacenará los audios activos.
            activeAudios = new List<GameObject>();
        }
        else
        {
            // Si ya existe una instancia, destruye el objeto actual para evitar duplicados.
            Destroy(gameObject);
        }
    }

    // Método para reproducir un clip de audio.
    // Recibe un AudioClip, un nombre para el objeto, un volumen (opcional) y si el audio es en bucle (opcional).
    public AudioSource PlayAudio(AudioClip clip, string objectName, float volume = 1, bool isLoop = false)
    {
        // Crea un nuevo GameObject para el audio y le asigna el nombre proporcionado.
        GameObject audioObject = new GameObject(objectName);

        // Agrega un componente de AudioSource al objeto recién creado.
        AudioSource audioSourceComponent = audioObject.AddComponent<AudioSource>();

        // Asigna el clip de audio al AudioSource.
        audioSourceComponent.clip = clip;

        // Ajusta el volumen del AudioSource.
        audioSourceComponent.volume = volume;

        // Define si el audio debe repetirse en bucle.
        audioSourceComponent.loop = isLoop;

        audioSourceComponent.Play();

        // Si el audio debe reproducirse en bucle, lo agrega a la lista de audios activos.
        if (isLoop)
        {
            // Añade el objeto de audio a la lista de audios activos.
            activeAudios.Add(audioObject);

            // Inicia una corrutina para verificar el estado del audio.
            StartCoroutine(CheckAudio(audioSourceComponent));
        }


        // Devuelve el componente AudioSource para poder controlarlo si es necesario.
        return audioSourceComponent;
    }

    // Corrutina que comprueba continuamente si un audio está reproduciéndose.
    IEnumerator CheckAudio(AudioSource audioSource)
    {
        // Mientras el audio se esté reproduciendo, espera brevemente antes de continuar.
        while (audioSource.isPlaying)
        {
            // Espera 0.2 segundos antes de volver a comprobar si sigue reproduciéndose.
            yield return new WaitForSeconds(.2f);
        }

        // Una vez que el audio ha terminado, lo elimina de la lista de audios activos.
        activeAudios.Remove(audioSource.gameObject);

        // Destruye el objeto de audio para liberar recursos.
        Destroy(audioSource.gameObject);
    }
}
