using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetSceneCount : MonoBehaviour
{
    internal string sceneName;

    private void Update()
    {
        sceneName = SceneManager.GetActiveScene().name;
        Debug.Log(sceneName);
    }
}
