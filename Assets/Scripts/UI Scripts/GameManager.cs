using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum SceneIndexes
{
    MANAGER = 0,
    TITLE_SCREEN = 1,
    LEVEL_1 = 2,
    LEVEL_2 = 3,
    LEVEL_3 = 4,
    LEVEL_4 = 5,
    INTRODUCTION = 6,
    LEVEL_1_C = 7,
    LEVEL_2_C = 8,
    LEVEL_3_C = 9,
    LEVEL_4_C = 10
}

/*
-- Author: Andrew Orvis
-- Description: Main game mamager for keeping track of / chaning scenes when nessary as well as implementing a functional loading screen with progress bar
 */


public class GameManager : MonoBehaviour
{
    [SerializeField] static GameManager instance;
    [SerializeField] GameObject loadingScreen;
    [SerializeField] Slider progressbar;

    public SceneIndexes currentScene;

    public virtual void firstLoad() { SceneManager.LoadSceneAsync((int)SceneIndexes.TITLE_SCREEN, LoadSceneMode.Additive); }
    private void Awake()
    {
        instance = this;

        firstLoad();
    }
    

    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();

    public void LoadGame(SceneIndexes x, SceneIndexes y)
    {
        loadingScreen.SetActive(true);
        scenesLoading.Add(SceneManager.LoadSceneAsync((int)(y), LoadSceneMode.Additive));
        scenesLoading.Add(SceneManager.UnloadSceneAsync((int)(x)));

        currentScene = y;

        StartCoroutine(GetSceneLoadProgress());
    }

    public void ReloadScene()
    {
        LoadGame(currentScene, currentScene);
    }

    #region progress bar

    float totalSceneProgress;
    public IEnumerator GetSceneLoadProgress()
    {
        for(int i = 0; i < scenesLoading.Count; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                totalSceneProgress = 0;

                foreach(AsyncOperation operation in scenesLoading)
                {
                    totalSceneProgress += operation.progress;
                }

                //calculate scene progress
                totalSceneProgress = totalSceneProgress / scenesLoading.Count;

                
                progressbar.value = (totalSceneProgress);


                yield return null;
            }
        }

        loadingScreen.gameObject.SetActive(false);
    }
    #endregion
}
