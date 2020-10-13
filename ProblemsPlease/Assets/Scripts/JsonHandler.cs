using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonHandler : MonoBehaviour
{

    [SerializeField]
    public Smock scenario;

    // Start is called before the first frame update
    void Start()
    {
        string json = JsonUtility.ToJson(scenario.ScenarioMock);
        Debug.Log(json);
    }
}
