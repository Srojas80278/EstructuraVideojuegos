using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class BotonConverter : MonoBehaviour
{
    public Button btnSound;
    public Button btnNoSound;

    void Start()
    {
        // Aseg�rate de que ambos botones est�n inicialmente activados/desactivados seg�n tu necesidad
        btnSound.gameObject.SetActive(true);
        btnNoSound.gameObject.SetActive(false);

        // Asigna la funci�n de cambio al clic del bot�n actual
        btnSound.onClick.AddListener(CambiarBotones);
        btnNoSound.onClick.AddListener(CambiarBotones);
    }

    void CambiarBotones()
    {
        // Invierte la activaci�n de los botones
        btnSound.gameObject.SetActive(!btnSound.gameObject.activeSelf);
        btnNoSound.gameObject.SetActive(!btnNoSound.gameObject.activeSelf);

        AudioListener.pause = btnNoSound.gameObject.activeSelf;
    }
}

