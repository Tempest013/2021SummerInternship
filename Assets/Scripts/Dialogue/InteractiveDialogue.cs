using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractiveDialogue : MonoBehaviour
{

    [Header("TextBoxes")]
    [SerializeField] private GameObject textBox;
    [SerializeField] private TextMeshProUGUI dialogueBox;

    [Header("Dialogue Variables")]
    [SerializeField] private string[] dialogue;
    [SerializeField] private int indexIndicator;
    private bool isActive;

    [SerializeField] private bool touched = false;
    private GameManager gameManager;

    void Start()
    {
        textBox.SetActive(false);
        gameManager = GameManager.instance;
    }


    void Update()
    {
        ScrollText();
        UpdateText(indexIndicator);
        DeactivateTextBox(indexIndicator);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && touched == false)
        {
            if(Input.GetKey(KeyCode.E))
            {
                gameManager.CurrState.SwitchToTextBoxState();
                textBox.SetActive(true);
                isActive = true;
                UpdateText(0);
                touched = true;
            }
        }
    }

    private void UpdateText(int index)
    {
        if (isActive == true)
        {
            dialogueBox.GetComponent<TMPro.TextMeshProUGUI>().text = dialogue[index];
        }
    }

    private void DeactivateTextBox(int index)
    {
        if (index == dialogue.Length - 1)
        {
            textBox.SetActive(false);
            isActive = false;
            indexIndicator = 0;
            gameManager.CurrState.SwitchToGameplayState();
            this.gameObject.SetActive(false);
            touched = false;
        }
    }

    private void ScrollText()
    {
        if (isActive == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                indexIndicator += 1;
            }
        }
    }
}
