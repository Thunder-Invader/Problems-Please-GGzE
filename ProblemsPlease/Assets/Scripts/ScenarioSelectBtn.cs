using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioSelectBtn : MonoBehaviour
{
    public MainMenuManager MenuManager;

    private string scenarioPath;

    public void ChooseScenario()
    {
        MenuManager.SetScenario(scenarioPath);
    }

    public void SetScenarioPath(string path)
    {
        scenarioPath = path;
    }
    
}
