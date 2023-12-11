using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class StateManager : Singleton<StateManager>
{
    string _name;
    string _kills;

    public string getName()
    {
        return _name;
    }

    public void setName(string newName)
    {
        _name = newName;
    }

    public string getKills()
    {
        return _kills;
    }

    public void setKills(string newKills)
    {
        _kills = newKills;
    }
}
