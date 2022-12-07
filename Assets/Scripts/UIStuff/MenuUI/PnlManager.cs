using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PnlManager : MonoBehaviour
{
    [SerializeField] private GameObject[] panels;
    private int currPanelIndex;
    
    private void Start()
    {
        bool flag = false;
        for (int i = 0; i < panels.Length; i++)
        {
            if(panels[i].activeInHierarchy &&flag==false)
            {
                currPanelIndex = i;
                flag = true;
                continue;
            }
            if (flag == true)
                panels[i].SetActive(false);
        }
        if (flag == false)
            panels[0].SetActive(true);
    }
    public void ChangePanel(int index)
    {
        panels[currPanelIndex].SetActive(false);
        currPanelIndex = index;
        panels[index].SetActive(true);
    }
}
