using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Overview", menuName = "ScriptableObjects/OverviewSO", order = 1)]
public class OverviewSO : ScriptableObject
{
    public Overview Overview;
}

[System.Serializable]
public class Overview
{
    public int StepsTaken;
    public List<Answer> Answers;

    public Overview(int stepsTaken, List<Answer> answers)
    {
        StepsTaken = stepsTaken;
        Answers = answers;
    }
}

[System.Serializable]
public class Answer
{
    public string Text;
    /// <summary>
    /// -1, 0, 1 are low stress, neutral stress, high stress
    /// 2 is confrontation and 3 is the reply of the patient
    /// </summary>
    public int Stress;

    public Answer(string text, int stress)
    {
        Text = text;
        Stress = stress; 
    }
}

