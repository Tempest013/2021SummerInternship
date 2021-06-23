using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIDeath : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject deathUI;

    private void Start()
    {
        if(GameManager.instance!=null)
        {
            GameManager.instance.onTurnOffDeathUI += TurnOffDeathUI;
            GameManager.instance.onTurnOnDeathUI += TurnOnDeathUI;
        }
    }

    private void TurnOffDeathUI()
    {
        deathUI.SetActive(false);
    }
    private void TurnOnDeathUI()
    {
        deathUI.SetActive(true);

    }
    public void BtnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
