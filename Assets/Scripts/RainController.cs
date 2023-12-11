using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class RainController : MonoBehaviour
{
    public ParticleSystem generadorDeParticulas;
    private bool generadorActivado = false;
    //public AudioSource rainSound;

    public float rateOverTime = 70f;

    void Start()
    {
        // Desactivar el generador de part culas al inicio del juego
        var emissionModule = generadorDeParticulas.emission;
        emissionModule.enabled = false;

        ChangeParticleRate(rateOverTime);
    }

    void Update()
    {
        // Si el generador no está activado
        if (!generadorActivado)
        {
            // Contar el tiempo transcurrido desde el inicio del juego
            float tiempoTranscurrido = Time.time;

            // Si han pasado al menos 15 segundos
            if (tiempoTranscurrido >= 15f)
            {
                // Activar la emisión de partículas
                var emissionModule = generadorDeParticulas.emission;
                emissionModule.enabled = true;

                generadorActivado = true;

                AudioManager.Instance.StopSFX();
                // Reproduce el sonido de lluvia
                AudioManager.Instance.PlaySFX("Rain");
            }
        }
    }



    void ChangeParticleMaterialAndColor(Material material, Color color)
    {
        // Obtén el módulo de renderizado del sistema de partículas
        var rendererModule = generadorDeParticulas.GetComponent<ParticleSystemRenderer>();

        // Verifica si el módulo de renderizado es válido
        if (rendererModule != null)
        {
            // Cambia el material del módulo de renderizado
            rendererModule.material = material;

            // Cambia el color del material
            material.color = color;
        }
        else
        {
            Debug.LogError("No se encontró el módulo de renderizado en el sistema de partículas.");
        }
    }

    void ChangeParticleRate(float rate)
    {
        // Obtén el módulo de emisión del sistema de partículas
        var emissionModule = generadorDeParticulas.emission;

        // Modifica la tasa de emisión
        emissionModule.rateOverTime = rate;
    }
}

