using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private ScenarioListSO scenarioList;
    [SerializeField]
    private ScenarioSO scenarioManager;
    [SerializeField]
    private Text chosenScenarioText;
    [SerializeField]
    private GameObject chooseScenarioDialogue;
    [SerializeField]
    private Transform scenarioButtonContainer;
    [SerializeField]
    private GameObject scenarioButtonPrefab;


    private string chosenScenarioPath;

    public void StartGame()
    {
        if (chosenScenarioPath != null && chosenScenarioPath.Length > 0)
        {
            TextAsset scenarioFile = Resources.Load<TextAsset>(chosenScenarioPath);
            scenarioManager.Scenario = JsonUtility.FromJson<Scenario>(scenarioFile.text);

            SceneManager.LoadScene(1);
        }
        else
        {
            chosenScenarioText.color = Color.red;
        }
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetScenario(string scenarioPath)
    {
        chosenScenarioPath = scenarioPath;
        chosenScenarioText.text = chosenScenarioPath;
        chooseScenarioDialogue.SetActive(false);
        chosenScenarioText.color = Color.black;
    }

    public void OpenScenarioDialogue()
    {
        chooseScenarioDialogue.SetActive(true);
    }

    private void Start()
    {
        foreach (string scenario in scenarioList.Scenarios)
        {
            ScenarioSelectBtn btn = Instantiate(scenarioButtonPrefab, scenarioButtonContainer).GetComponent<ScenarioSelectBtn>();
            btn.SetScenarioPath(scenario);
            btn.MenuManager = this;
            btn.GetComponentInChildren<Text>().text = scenario;
        }
    }
}
