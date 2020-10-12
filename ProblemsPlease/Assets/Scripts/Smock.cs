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

    public List<ScenarioPhase> phases;

    public ScenarioMock(string scenarioName, string scenarioDes, int maxStress, int startStress, string failLowText, string failHighText, string winText, int score)
    {
        this.scenarioName = scenarioName;
        this.scenarioDes = scenarioDes;
        this.maxStress = maxStress;
        this.startStress = startStress;
        this.failLowText = failLowText;
        this.failHighText = failHighText;
        this.winText = winText;
        this.score = score;
        this.phases = new List<ScenarioPhase>();
    }
}

[System.Serializable]
public class ScenarioPhase
{
    public bool confrontationPossible;
    public int phaseTime;
    public List<ScenarioButton> buttons;

    public ScenarioPhase(bool confrontationPossible, int phaseTime)
    {
        this.confrontationPossible = confrontationPossible;
        this.phaseTime = phaseTime;
        this.buttons = new List<ScenarioButton>();
    }
}

[System.Serializable]
public class ScenarioButton
{
    public string buttonText;
    public bool buttonEnabled;
    public string videoName;
    public string answerText;

    public ScenarioButton(string buttonText, bool buttonEnabled, string videoName, string answerText)
    {
        this.buttonText = buttonText;
        this.buttonEnabled = buttonEnabled;
        this.videoName = videoName;
        this.answerText = answerText;
    }
}