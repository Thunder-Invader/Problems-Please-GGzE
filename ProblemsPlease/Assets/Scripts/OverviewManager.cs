using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class OverviewManager : MonoBehaviour
{
    [SerializeField]
    private ScenarioSO scenario = default;

    [SerializeField]
    private OverviewSO overview = default;

    [SerializeField]
    private GameObject answerPrefab = default;

    [SerializeField]
    private Transform answerContainer = default;

    [SerializeField]
    private TextMeshProUGUI stepsTakenText = default;

    [SerializeField]
    private TextMeshProUGUI scoreText = default;

    [SerializeField]
    private Gradient answerColour = default;

    // Start is called before the first frame update
    void Start()
    {
        stepsTakenText.text = overview.Overview.StepsTaken.ToString();
        scoreText.text = scenario.Scenario.score.ToString();
        foreach (Answer a in overview.Overview.Answers)
        {
            Text answer = Instantiate(answerPrefab, answerContainer).GetComponent<Text>();
            answer.text = a.Text;
            switch (a.Stress)
            {
                case -1:
                    answer.color = answerColour.Evaluate(0f);
                    break;
                case 0:
                    answer.color = answerColour.Evaluate(0.25f);
                    break;
                case 1:
                    answer.color = answerColour.Evaluate(0.5f);
                    break;
                case 2:
                    answer.color = answerColour.Evaluate(0.75f);
                    break;
                default:
                    answer.color = answerColour.Evaluate(1f);
                    break;
            }
        }
    }

    public void GoToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
