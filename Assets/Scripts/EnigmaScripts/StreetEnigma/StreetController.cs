using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetController : MonoBehaviour
{
    [SerializeField] GameObject lever;
    [SerializeField] public List<GameObject> rightStreet = new List<GameObject>();

    StreetPlatform StreetPlatform;

    // Start is called before the first frame update
    void Start()
    {
        StreetPlatform = FindObjectOfType<StreetPlatform>();
    }

    // Update is called once per frame
    void Update()
    {
        ActiveLever();
    }

    void ActiveLever()
    {
        if(rightStreet.Count <= 0)
        {
            lever.SetActive(true);
            //Destroy(gameObject);
            //StreetPlatform.enabled = false;
        }
    }

    public void RemovePlatform(GameObject platform)
    {
        rightStreet.Remove(rightStreet[0]);
    }

    
}
