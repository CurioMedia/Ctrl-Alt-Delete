using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance

    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("GameManager is NULL");
            }
        
        return instance;
        }
    }
    private void Awake ()
    {
        
        if (instance)
        Destroy(gameObject);
        else
        instance=this;
        DontDestroyOnLoad(this);
    }
    public bool buttClick{get; set;}
}
