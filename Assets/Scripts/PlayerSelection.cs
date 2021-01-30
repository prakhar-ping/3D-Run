using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSelection : MonoBehaviour
{
    [SerializeField] private Button nextButton;
    [SerializeField] private Button previousButton;
    public GameObject[] Player;

    private int currentSphere;

    private void Awake()
    {
        SelectSphere(0);
    }

    private void SelectSphere(int index)
   {
        previousButton.interactable = (index != 0);
        nextButton.interactable = (index != 4);
        for(int i = 0; i < 5; i++)
        {
            Player[i].SetActive(i == index);
        }
   }

    public void ChangeSphere(int change)
    {
        currentSphere += change;
        SelectSphere(currentSphere);
    }

    public void Select()
    {
        PlayerPrefs.SetInt("PlayerSelected", currentSphere);
        SceneManager.LoadScene("3D Run");
    }

    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
