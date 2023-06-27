using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] pPoints;
    int pPointIndex;
    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, target) < .1)
        {
            IteratePPointsIndex();
            UpdateDestination();
        }
    }

    void UpdateDestination()
    {
        target = pPoints[pPointIndex].position;
        agent.SetDestination(target);
    }

    void IteratePPointsIndex()
    {
        pPointIndex++;
        if(pPointIndex == pPoints.Length)
        {
            pPointIndex = 0;
        }
    }
}
