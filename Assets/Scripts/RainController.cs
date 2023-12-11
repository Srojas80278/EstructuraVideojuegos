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
        // Si el generador no est� activado
        if (!generadorActivado)
        {
            // Contar el tiempo transcurrido desde el inicio del juego
            float tiempoTranscurrido = Time.time;

            // Si han pasado al menos 15 segundos
            if (tiempoTranscurrido >= 15f)
            {
                // Activar la emisi�n de part�culas
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
        // Obt�n el m�dulo de renderizado del sistema de part�culas
        var rendererModule = generadorDeParticulas.GetComponent<ParticleSystemRenderer>();

        // Verifica si el m�dulo de renderizado es v�lido
        if (rendererModule != null)
        {
            // Cambia el material del m�dulo de renderizado
            rendererModule.material = material;

            // Cambia el color del material
            material.color = color;
        }
        else
        {
            Debug.LogError("No se encontr� el m�dulo de renderizado en el sistema de part�culas.");
        }
    }

    void ChangeParticleRate(float rate)
    {
        // Obt�n el m�dulo de emisi�n del sistema de part�culas
        var emissionModule = generadorDeParticulas.emission;

        // Modifica la tasa de emisi�n
        emissionModule.rateOverTime = rate;
    }
}

