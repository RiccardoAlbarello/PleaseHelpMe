using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudEnigma : MonoBehaviour
{
    [SerializeField] GameObject lever;
    [SerializeField] List<GameObject> platforms = new List<GameObject>();
    private List<GameObject> platformCheck = new List<GameObject>();

    

    // Start is called before the first frame update
    void Start()
    {
        
        platformCheck = platforms;
    }

    // Update is called once per frame
    void Update()
    {
        ActiveLever();
    }

    public void ActiveLever()
    {
        if(platformCheck.Count <= 0)
        {
            lever.SetActive(true);
        }
        //else
        //{
        //    lever.SetActive(false);
        //}
    }
 
    public void RemovePlatform(GameObject platform)
    {
        platformCheck.Remove(platform);
    }

    public void AddPlatform(GameObject platform)
    {
        platformCheck.Add(platform);
    }
}
