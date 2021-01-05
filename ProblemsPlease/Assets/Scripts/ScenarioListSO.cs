using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScenarioList", menuName = "ScriptableObjects/ScenarioListSO", order = 1)]
public class ScenarioListSO : ScriptableObject
{
    public List<string> Scenarios;
}
