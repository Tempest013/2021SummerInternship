using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPause : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;



    void Start()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.onTurnOnPauseUI += TurnOnPauseUI;
            GameManager.instance.onTurnOffPauseUI += TurnOffPauseUI;
        }


    }

    private void TurnOffPauseUI()
    {
        pauseUI.SetActive(false);
    }
    private void TurnOnPauseUI()
    {
        pauseUI.SetActive(true);

    }
    public void BtnPause()
    {
        GameManager.instance.CurrState.OnPause();
    }


}
