using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    bool GameIsPause;
    public GameObject PausePanel;
    // Start is called before the first frame update
    void Start()
    {
        PausePanel = GameObject.Find("PausePanel");
        PausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Pause()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
    }
    void Resume()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }
}
