using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToSceneOnClicks : MonoBehaviour
{
    public int sceneIndex;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            ClickEvent();
        });
    }

    void ClickEvent()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
