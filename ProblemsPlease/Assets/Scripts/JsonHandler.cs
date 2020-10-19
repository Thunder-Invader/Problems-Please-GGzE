using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonHandler : MonoBehaviour
{

    [SerializeField]
    private ScenarioSO scenario;

    // Start is called before the first frame update
    void Start()
    {
        //string json = JsonUtility.ToJson(scenario.Scenario);
        //Debug.Log(json);
        ImportScenario();
    }

    public void ImportScenario()
    {
        string path = "Scenario";
        TextAsset scenarioFile = Resources.Load<TextAsset>(path);
        scenario.Scenario = JsonUtility.FromJson<Scenario>(scenarioFile.text);
    }
}
