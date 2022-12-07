using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BtnContinue : MonoBehaviour
{
    string sceneName;
    int checkpoint;

    // Start is called before the first frame update
    void Start()
    {
        if (!(File.Exists(Application.dataPath + "/save.txt")))
        {
            this.gameObject.SetActive(false);
        }
    }

    public void StartLoadingAsync()
    {
        SceneManagement.instance.generalCanvas.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameManager.instance.CurrState.SwitchToGameplayState();
        SaveManager.instance.Load();
        
        

    }

}
