using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagerController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI killsText;
    private int kills;

    void Start()
    {
        kills = 0;
        UpdateKillCount();
    }

    public void IncrementKillCount()
    {
        kills++;
        UpdateKillCount();
    }

    void UpdateKillCount()
    {
        killsText.text = kills.ToString();
        StateManager.Instance.setKills(killsText.text);
    }
}
