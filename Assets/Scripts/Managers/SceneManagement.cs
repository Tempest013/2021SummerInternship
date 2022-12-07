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
    public string currentSceneName;
    public AsyncOperation async;
    public int checkPoint = -2;
    private PlayerCharacter player;
    private GameManager gamemanager;


    void Start()
    {
        if (SceneManager.GetActiveScene().name == "CoreScene")
        {
            loadNextScene("MainMenu");
            // GameManager.instance.CurrState.SwitchToMenuState();
        }
        player = PlayerCharacter.instance;
        gamemanager = GameManager.instance;
    }

    public void loadNextScene()
    {
        PlayerTransformCheck();
        StartCoroutine(LoadLevelAsync());
    }

    private void PlayerTransformCheck()
    {
        if (player != null && gamemanager != null)
            player.transform.parent = gamemanager.transform;
    }

    public void loadNextScene(string nextSceneName)
    {

        PlayerTransformCheck();
        sceneNameNext = nextSceneName;
        checkPoint = 0;
        StartCoroutine(LoadLevelAsync());
    }

    private IEnumerator LoadLevelAsync()
    {
        PlayerTransformCheck();
        async = SceneManager.LoadSceneAsync(sceneNameNext, LoadSceneMode.Additive);
        async.allowSceneActivation = false;
        loadingScreen.SetActive(true);
        if (currentSceneName != "")
        {
            AsyncOperation op = SceneManager.UnloadSceneAsync(currentSceneName);
            while (op.isDone)
            {
                yield return null;
            }
        }
        while (async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / .9f);
            slider.value = progress;
            yield return null;
        }

        loadingScreen.SetActive(false);
        currentSceneName = sceneNameNext;
        async.allowSceneActivation = true;
        if (CheckpointsSystem.instance != null)
        {
            CheckpointsSystem.instance.gameObject.SetActive(false);
            CheckpointsSystem.instance.gameObject.SetActive(true);
        }
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

    }

    private void LoadMainMenu()
    {
        PlayerTransformCheck();
        loadingScreen.SetActive(true);
        StartCoroutine(LoadMainMenuAsync());
    }

    private IEnumerator LoadMainMenuAsync()
    {
        PlayerTransformCheck();
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

    
}
