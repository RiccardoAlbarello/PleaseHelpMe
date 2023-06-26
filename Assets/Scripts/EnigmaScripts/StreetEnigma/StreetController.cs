using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetController : MonoBehaviour
{
    [SerializeField] GameObject lever;
    [SerializeField] public List<GameObject> rightStreet = new List<GameObject>();

    

    // Start is called before the first frame update
    void Start()
    {
        
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
            Destroy(gameObject);
        }
    }

    public void RemovePlatform(GameObject platform)
    {
        rightStreet.Remove(rightStreet[0]);
    }

    
}
