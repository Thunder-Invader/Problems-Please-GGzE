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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GoToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
