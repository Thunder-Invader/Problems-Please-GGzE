using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventCallback : MonoBehaviour
{
    [SerializeField]
    private UnityEvent callBack;

    [SerializeField]
    private UnityEvent callBackTwo;

    public void CallBack()
    {
        callBack.Invoke();
    }

    public void CallBack2()
    {
        callBackTwo.Invoke();
    }
}
