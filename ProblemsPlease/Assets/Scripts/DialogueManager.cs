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
    private Text ConText = default;

    [SerializeField]
    private Text PreviousText = default;

    [SerializeField]
    private Text AnswerText = default;

    [SerializeField]
    private Animator ani = default;

    [SerializeField]
    private DialoguePlayer videoPlayer = default;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.SetVideo(scenario.Scenario.startVideoName);
    }

   public void AddStress(int amount)
    {/* 
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
        }
}
