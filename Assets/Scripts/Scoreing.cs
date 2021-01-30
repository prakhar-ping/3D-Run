using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Scoreing : MonoBehaviour
{
    public Transform player;
    public GameObject gamescore;
    public GameObject endscore;
    private TextMeshProUGUI s;
    private TextMeshProUGUI es;

    private void Awake()
    {
        s = GetComponent<TextMeshProUGUI>();
        es = endscore.GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        int score = (int)(player.position.z + 20);
        s.text = score.ToString();
        es.text = score.ToString();
    }
}
