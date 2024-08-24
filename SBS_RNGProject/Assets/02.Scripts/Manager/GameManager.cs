using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UI_ItemTooltip tootips;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
    }

    void Start()
    {
        Application.targetFrameRate = 120;

        int targetWidth = 1080;
        int targetHeight = 1920;
        bool fullscreen = true;

        Screen.SetResolution(targetWidth, targetHeight, fullscreen);
    }

    void Update()
    {
        
    }
}
