using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class BotonConverter : MonoBehaviour
{
    public Button btnSound;
    public Button btnNoSound;

    void Start()
    {
        // Asegúrate de que ambos botones estén inicialmente activados/desactivados según tu necesidad
        btnSound.gameObject.SetActive(true);
        btnNoSound.gameObject.SetActive(false);

        // Asigna la función de cambio al clic del botón actual
        btnSound.onClick.AddListener(CambiarBotones);
        btnNoSound.onClick.AddListener(CambiarBotones);
    }

    void CambiarBotones()
    {
        // Invierte la activación de los botones
        btnSound.gameObject.SetActive(!btnSound.gameObject.activeSelf);
        btnNoSound.gameObject.SetActive(!btnNoSound.gameObject.activeSelf);

        AudioListener.pause = btnNoSound.gameObject.activeSelf;
    }
}

