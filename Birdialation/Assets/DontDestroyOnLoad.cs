using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public static DontDestroyOnLoad Instance { get; private set; } // Singleton instance


    void Awake()
    {

        // Singleton pattern to ensure only one instance of SaveManager exists
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Persist across scenes

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
