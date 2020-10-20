using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GloomColour : MonoBehaviour
{
    [SerializeField]
    private Image gloom;

    [SerializeField]
    private Gradient stressColour;

    public void SetStress(float stress, float maxStress)
    {
        gloom.color = stressColour.Evaluate(stress/maxStress);
        
    }

}
