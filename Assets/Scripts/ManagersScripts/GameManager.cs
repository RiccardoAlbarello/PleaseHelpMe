using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    [SerializeField] GameObject finalTrigger;

    [SerializeField] public List<GameObject> monolithCollection = new List<GameObject>();

    private void Awake()
    {
        _instance = this;
    }

    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("GameManager is null!");
            }

            return _instance;
        }
    }

    public void EndGame()
    {
        if(monolithCollection.Count >= 4)
        {
            finalTrigger.SetActive(true);
        }
    }
}
