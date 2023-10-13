using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score { get; private set; }
    public static GameManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
    private void Start()
    {
        Application.targetFrameRate = 60;
        NewGame();
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Scene");
    }
}
