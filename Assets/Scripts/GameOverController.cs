using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI nameText;
    
    [SerializeField]
    TextMeshProUGUI killsText;

    void Awake()
    {
        nameText.text = StateManager.Instance.getName();
        killsText.text = StateManager.Instance.getKills();
    }
}
