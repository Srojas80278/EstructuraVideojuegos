using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryController : MonoBehaviour
{
    public void Play()
    {
        CambiarEscena();
    }
    void CambiarEscena()
    {
        string escenaAnterior = "Mapa";

        SceneManager.LoadScene(escenaAnterior);
    }
}
