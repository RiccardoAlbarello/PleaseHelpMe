using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassInteractor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shader.SetGlobalVector("_Player", transform.position);
        Shader.SetGlobalVector("_PlayerForward", transform.forward);
        
    }
}
