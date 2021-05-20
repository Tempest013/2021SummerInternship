using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    #region singleton
    public static SceneManagement instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    #endregion singleton
    public GameObject generalCanvas;
    public GameObject loadingScreen;
    public Slider slider;
    [SerializeField] private string sceneNameNext;
    [SerializeField] private string currentSceneName;
    public AsyncOperation async;

    public void loadNextScene()
    {
        StartCoroutine(LoadLevelAsync());
    }

    public void loadNextScene(string nextSceneName)
    {
        sceneNameNext = nextSceneName;
        StartCoroutine(LoadLevelAsync());
    }

    private IEnumerator LoadLevelAsync()
    {
        async = SceneManager.LoadSceneAsync(sceneNameNext, LoadSceneMode.Additive);
        async.allowSceneActivation = false;
        loadingScreen.SetActive(true);
        while(async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / .9f);
            slider.value = progress;
            yield return null;
        }
        if (currentSceneName != "")
        {
            AsyncOperation op = SceneManager.UnloadSceneAsync(currentSceneName);
            while(op.isDone)
            {
                yield return null;
            }
        }
        loadingScreen.SetActive(false);
        currentSceneName = sceneNameNext;
        async.allowSceneActivation = true;
        
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

    }

    private void LoadMainMenu()
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadMainMenuAsync());
    }

    private IEnumerator LoadMainMenuAsync()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        async = SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);
        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / .9f);
            slider.value = progress;
            yield return null;
        }
        loadingScreen.SetActive(false);
        generalCanvas.SetActive(false);
        
    }



    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "TestScene")
        {
            loadNextScene("MainMenu");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("b"))
        {
            loadNextScene("NianTRALALALAScene");
        }
    }
}
