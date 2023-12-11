using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoState<LevelManager>
{
    // LevelManager = Control que se va encargar de manejar las transiciones entre escenas

    int sceneCount;

    protected override void Awake()
    {
        base.Awake();
        sceneCount = SceneManager.sceneCountInBuildSettings - 1;
    }

    public void FirstScene()
    {
        // Las escenas van enumeras de 0 a n-1

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            return;
        }

        SceneManager.LoadScene(sceneCount);
    }

    public void LastScene()
    {
        if (SceneManager.GetActiveScene().buildIndex == sceneCount)
        {
            return;
        }

        SceneManager.LoadScene(0);
    }

    public void NextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene >= sceneCount)
        {
            return;
        }

        SceneManager.LoadScene(currentScene + 1);
    }

    public void PreviousScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene <= 0)
        {
            return;
        }

        SceneManager.LoadScene(currentScene - 1);
    }
}
