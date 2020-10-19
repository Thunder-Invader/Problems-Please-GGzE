using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private ScenarioSO scenario = default;

    [SerializeField]
    private Text buttonLowText = default;

    [SerializeField]
    private Text buttonNeutralText = default;

    [SerializeField]
    private Text buttonHighText = default;

    [SerializeField]
    private Text buttonConfrontText = default;

    [SerializeField]
    private Text conText = default;

    [SerializeField]
    private Text previousText = default;

    [SerializeField]
    private Text answerText = default;

    [SerializeField]
    private Animator ani = default;

    [SerializeField]
    private DialoguePlayer videoPlayer = default;

    [SerializeField]
    private int phase = 1;

    [SerializeField]
    private int stress;

    private ScenarioPhase currentPhase;

    private ScenarioButton pressedButton = null;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.SetVideo(Application.dataPath + "/Videos/" + scenario.Scenario.startVideoName);
        stress = scenario.Scenario.startStress;

        conText.text = scenario.Scenario.scenarioDes;
        previousText.text = scenario.Scenario.patientName + ": " + scenario.Scenario.introText;
        answerText.text = scenario.Scenario.patientName + ": " + scenario.Scenario.introText;
    }

    public void AddStress(int amount)
    {
        pressedButton = currentPhase.buttons[1+amount];
        

        /* 
        stress += amount;
        if (!(minStress < stress && maxStress > stress))
        {
            Debug.Log("Game Over");
            return;
        }
        AnswerText.text = "stress: " + stress;
*/
    }

    public void FreezeFrame()
    {
        //load correct data.
        ani.Play("VideoScaleDown");

        currentPhase = GetPhase(phase, stress);
        if (currentPhase == null)
        {
            Debug.LogError("Error 404 phase does not exist");
            return;
        }

        buttonLowText.text = currentPhase.buttons[0].buttonText;
        buttonLowText.transform.parent.gameObject.SetActive(currentPhase.buttons[0].buttonEnabled);

        buttonNeutralText.text = currentPhase.buttons[1].buttonText;
        buttonNeutralText.transform.parent.gameObject.SetActive(currentPhase.buttons[1].buttonEnabled);

        buttonHighText.text = currentPhase.buttons[2].buttonText;
        buttonHighText.transform.parent.gameObject.SetActive(currentPhase.buttons[2].buttonEnabled);

        buttonConfrontText.text = currentPhase.buttons[3].buttonText;

        if (pressedButton == null)
        {
            return;
        }
        answerText.text = scenario.Scenario.patientName + ": " + pressedButton.answerText;
        previousText.text += System.Environment.NewLine + System.Environment.NewLine + "Jij: " + pressedButton.buttonText + System.Environment.NewLine + System.Environment.NewLine + scenario.Scenario.patientName + ": " + pressedButton.answerText;
    }

    public ScenarioPhase GetPhase(int phase, int stress)
    {
        foreach (ScenarioPhase p in scenario.Scenario.phases)
        {
            if (p.phaseNumber == phase && p.stress == stress)
            {
                return p;
            }
        }
        return null;
    }
}
