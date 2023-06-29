using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetController : MonoBehaviour
{
    [SerializeField] GameObject lever;
    [SerializeField] public List<GameObject> rightStreet = new List<GameObject>();
    [SerializeField] public List<GameObject> secondStreet = new List<GameObject>();
    //[SerializeField] public List<GameObject> SecondStreet = new List<GameObject>();

    [SerializeField] public DeactivePlatform[] deactivePlatform;

    // Start is called before the first frame update
    void Start()
    {
        deactivePlatform = GetComponentsInChildren<DeactivePlatform>();
    }

    // Update is called once per frame
    void Update()
    {
        ActiveLever();

        for (int i = 0; i < deactivePlatform.Length; i++)
        {
            if (deactivePlatform[i].deathPlatform)
            {
                ResetPlatform();
                deactivePlatform[i].deathPlatform = false;
            }
        }
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

    public void ResetPlatform()
    {
        rightStreet.Clear();
        rightStreet = new List<GameObject>(secondStreet);
        for (int i = 0; i < secondStreet.Count; i++)
        {
            secondStreet[i].GetComponent<Collider>().enabled = true;
            secondStreet[i].GetComponent<Material>().SetFloat("_Emissive", 0);
        }
    }

    
}
