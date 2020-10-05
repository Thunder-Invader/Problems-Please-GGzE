using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
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

    //hardcoded

    int stress = 2;
    int minStress = 0;
    int maxStress = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddStress(int amount)
    {
        stress += amount;
        if (!(minStress < stress && maxStress > stress))
        {
            Debug.Log("Game Over");
            return;
        }
        AnswerText.text = "stress: " + stress;
    }
}
