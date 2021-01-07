using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private ScenarioSO scenario = default;

    [SerializeField]
    private OverviewSO overview = default;

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

    [SerializeField]
    private GameObject endButton;

    [SerializeField]
    private GameObject dialogueButtons;

    [SerializeField]
    private ScrollRect scrollRect;

    [SerializeField]
    private CountdownTimer timer;

    private int score;

    [SerializeField]
    private GloomColour gloom;

    private int stepsTaken;
    private List<Answer> answers;

    private bool isConfronting;

    // Start is called before the first frame update
    void Start()
    {
        isConfronting = false;
        score = scenario.Scenario.maxScore;
        videoPlayer.SetVideo(Application.dataPath + "/Videos/" + scenario.Scenario.startVideoName);
        stress = scenario.Scenario.startStress;

        conText.text = scenario.Scenario.scenarioDes;
        previousText.text = scenario.Scenario.patientName + ": " + scenario.Scenario.introText;
        answerText.text = scenario.Scenario.patientName + ": " + scenario.Scenario.introText;

        stepsTaken = 0;
        answers = new List<Answer>();
    }

    public void AddStress(int amount)
    {
        ani.Play("VideoScaleUp");

        score -= timer.GetCountdown() > 0 ? 10 : 15;
        ++stepsTaken;

        pressedButton = currentPhase.buttons[1 + amount];

        answers.Add(new Answer(pressedButton.buttonText, amount));
        answers.Add(new Answer(pressedButton.answerText, 3));

        stress += amount;
        gloom.SetStress(stress, scenario.Scenario.maxStress);

        videoPlayer.SetVideo(Application.dataPath + "/Videos/" + pressedButton.videoName);

        if (pressedButton.toEnd)
        {
            ActivateEnd(scenario.Scenario.winText);
            Debug.Log("End screen");
            return;
        }

        if (stress == 0)
        {
            score = 0;
            ActivateEnd(scenario.Scenario.failLowText);
            Debug.Log("Game over: Low stress");
            return;
        }
        if (stress == scenario.Scenario.maxStress)
        {
            score = 0;
            ActivateEnd(scenario.Scenario.failHighText);
            Debug.Log("Game over: Too high stress");
            return;
        }

        ++phase;
      
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

    public void HandleConfrontation()
    {
        score -= timer.GetCountdown() > 0 ? 5 : 10;
        ++stepsTaken;

        pressedButton = currentPhase.buttons[3];

        if (currentPhase.confrontationPossible)
        {
            answers.Add(new Answer(pressedButton.buttonText, 1));
            answers.Add(new Answer(pressedButton.answerText, 3));
            isConfronting = true;
            videoPlayer.SetVideo(Application.dataPath + "/Videos/" + pressedButton.videoName);
            ani.Play("VideoScaleUp");
            previousText.text += System.Environment.NewLine + System.Environment.NewLine + "Jij: " + pressedButton.buttonText + System.Environment.NewLine + System.Environment.NewLine + scenario.Scenario.patientName + ": " + pressedButton.answerText;
        }
        else
        {
            answers.Add(new Answer(pressedButton.buttonText, 1));
            answers.Add(new Answer("...", 0));
            ani.Play("PopUp");
            StartCoroutine(ScrollToBottom());
            previousText.text += System.Environment.NewLine + System.Environment.NewLine + "Jij: " + pressedButton.buttonText + System.Environment.NewLine + System.Environment.NewLine + scenario.Scenario.patientName + ": ...";
        }
    }

    public void FreezeFrame()
    {
        StartCoroutine(ScrollToBottom());
        if (isConfronting)
        {
            HandelConfrontationEnd();
        }
        
        ani.Play("VideoScaleDown");

        if (pressedButton != null && pressedButton.toEnd)
        {
            return;
        }

        currentPhase = GetPhase(phase, stress);
        if (currentPhase == null)
        {
            //Debug.LogError("Error 404 phase does not exist");
            return;
        }

        buttonLowText.text = currentPhase.buttons[0].buttonText;
        buttonLowText.transform.parent.gameObject.SetActive(currentPhase.buttons[0].buttonEnabled);

        buttonNeutralText.text = currentPhase.buttons[1].buttonText;
        buttonNeutralText.transform.parent.gameObject.SetActive(currentPhase.buttons[1].buttonEnabled);

        buttonHighText.text = currentPhase.buttons[2].buttonText;
        buttonHighText.transform.parent.gameObject.SetActive(currentPhase.buttons[2].buttonEnabled);

        buttonConfrontText.text = currentPhase.buttons[3].buttonText;

        timer.SetDuration(currentPhase.phaseTime);

        if (pressedButton == null)
        {
            return;
        }
        answerText.text = scenario.Scenario.patientName + ": " + pressedButton.answerText;
        previousText.text += System.Environment.NewLine + System.Environment.NewLine + "Jij: " + pressedButton.buttonText + System.Environment.NewLine + System.Environment.NewLine + scenario.Scenario.patientName + ": " + pressedButton.answerText;
    }

    public void HandelConfrontationEnd()
    {
        isConfronting = false;
        pressedButton = GetEndButton();

        answers.Add(new Answer(pressedButton.buttonText, 1));
        answers.Add(new Answer(pressedButton.answerText, 3));

        videoPlayer.SetVideo(Application.dataPath + "/Videos/" + pressedButton.videoName);

        ani.Play("VideoScaleUp");

        //previousText.text += System.Environment.NewLine + System.Environment.NewLine + "Jij: " + pressedButton.buttonText + System.Environment.NewLine + System.Environment.NewLine + scenario.Scenario.patientName + ": " + pressedButton.answerText;

        ActivateEnd(scenario.Scenario.winText);
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

    public ScenarioButton GetEndButton()
    {
        foreach (ScenarioPhase p in scenario.Scenario.phases)
        {
            foreach (ScenarioButton b in p.buttons)
            {
                if (b.toEnd && b.buttonEnabled)
                {
                    return b;
                }
            }
        }
        return null; //not handeled, shouldnt be possible
    }

    public void ActivateEnd(string endText)
    {
        endButton.SetActive(true);
        dialogueButtons.SetActive(false);

        answerText.text = endText;
        previousText.text += System.Environment.NewLine + System.Environment.NewLine + "Jij: " + pressedButton.buttonText;

        timer.gameObject.SetActive(false);
    }

    public void EndGame()
    {
        scenario.Scenario.score = score;
        Debug.Log(score);
        overview.Overview = new Overview(stepsTaken, answers);
        SceneManager.LoadScene(2);
    }

    IEnumerator ScrollToBottom()
    {
        yield return new WaitForEndOfFrame();
        scrollRect.verticalNormalizedPosition = 0f;
    }
}

