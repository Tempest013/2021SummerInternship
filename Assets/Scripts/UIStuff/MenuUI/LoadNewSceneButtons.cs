using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewSceneButtons : MonoBehaviour
{
    public void StartLoadingAsync(string SceneName)
    {
        SceneManagement.instance.generalCanvas.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManagement.instance.loadNextScene(SceneName);
        GameManager.instance.CurrState.SwitchToGameplayState();
        
    }
    


}
