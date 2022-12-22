using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] GameObject[] _open;
    [SerializeField] GameObject[] _close;

    public static void SceneMove(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SetActive()
    {
        if(_open.Length > 0)
        {
            for(int i = 0; i < _open.Length; i++)
            {
                _open[i].SetActive(true);
            }
            for (int i = 0; i < _close.Length; i++)
            {
                _close[i].SetActive(false);
            }
        }
        else
        {
            _open[0].SetActive(true);
            _close[0].SetActive(false);
        }
    }
}
