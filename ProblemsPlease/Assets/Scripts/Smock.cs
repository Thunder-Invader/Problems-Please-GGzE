using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScenarioMock", menuName = "ScriptableObjects/ScenarioMockSO", order = 1)]
public class Smock : ScriptableObject
{
    public ScenarioMock ScenarioMock;
}

[System.Serializable]
public class ScenarioMock
{
    public string scenarioName;
    public string scenarioDes;
    public int maxStress; //min stress is 0
    public int startStress;
    public string failLowText;
    public string failHighText;
    public string winText;
    public int score;
}

[System.Serializable]
public class ScenarioPhase
{
    //Confrontation is saved here
}

[System.Serializable]
public class ScenarioButton
{
    public string buttonText;
    public bool buttonEnabled;
    public string videoName;

}