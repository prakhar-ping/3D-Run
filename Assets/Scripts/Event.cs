using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Event : MonoBehaviour
{

    public static bool gameover;
    public GameObject gameOverPanel;
    public GameObject ScoringPanel;
    //public Text endScore;
    //Scoreing sc;

    // Start is called before the first frame update
    void Start()
    {
        gameover = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameover)
        {
            Time.timeScale = 0;
           
            ScoringPanel.SetActive(false);
            gameOverPanel.SetActive(true);
        }
    }
}
