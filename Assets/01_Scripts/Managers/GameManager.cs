using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public DataManager DataManager { get; private set; }

    private void Awake()
    {//싱글톤
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        DataManager = new DataManager();

        DataManager.Initialize();
    }
}
