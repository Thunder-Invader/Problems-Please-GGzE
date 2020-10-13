using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialoguePlayer : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer patientPlayer = default;

    [SerializeField]
    private UnityEvent freezeFrame = default;

    private void Start()
    {
        patientPlayer.loopPointReached += OnVideoEnd;
    }

    public void StartVideo()
    {
        // patientPlayer.Play();
        StartCoroutine(Test());
    }

    public void OnVideoEnd(VideoPlayer vp)
    {
        freezeFrame.Invoke();
    }

    private IEnumerator Test()
    {
        yield return new WaitForSeconds(2);
        OnVideoEnd(patientPlayer);
    }

    public void SetVideo(string url)
    {
        patientPlayer.url = url;
        patientPlayer.Play();
    }
}
