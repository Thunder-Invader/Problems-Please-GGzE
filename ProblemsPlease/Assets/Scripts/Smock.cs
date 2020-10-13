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
    public string introText;

    public List<ScenarioPhase> phases;

    public ScenarioMock(string scenarioName, string scenarioDes, int maxStress, int startStress, string failLowText, string failHighText, string winText, int score, string introText)
    {
        this.scenarioName = scenarioName;
        this.scenarioDes = scenarioDes;
        this.maxStress = maxStress;
        this.startStress = startStress;
        this.failLowText = failLowText;
        this.failHighText = failHighText;
        this.winText = winText;
        this.score = score;
        this.introText = introText;
        this.phases = new List<ScenarioPhase>();
    }
}

[System.Serializable]
public class ScenarioPhase
{
    public int phaseNumber;
    public int stress;
    public bool confrontationPossible;
    public int phaseTime;
    public List<ScenarioButton> buttons;
    //button on index 0 is low stress option, on 1 neutral on 2 stressful on 3 confrontation

    public ScenarioPhase(int phaseNumber, int stress, bool confrontationPossible, int phaseTime)
    {
        this.phaseNumber = phaseNumber;
        this.stress = stress;
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
    public bool toEnd;

    public ScenarioButton(string buttonText, bool buttonEnabled, string videoName, string answerText, bool toEnd)
    {
        this.buttonText = buttonText;
        this.buttonEnabled = buttonEnabled;
        this.videoName = videoName;
        this.answerText = answerText;
        this.toEnd = toEnd;
    }
}