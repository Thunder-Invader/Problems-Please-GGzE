using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventCallback : MonoBehaviour
{
    [SerializeField]
    private UnityEvent callBack;


    public void CallBack()
    {
        callBack.Invoke();
    }
}
