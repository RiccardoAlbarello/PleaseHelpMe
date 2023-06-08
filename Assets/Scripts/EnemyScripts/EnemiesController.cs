using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float enemySpeed;
    [SerializeField] float enemyRotationSpeed;

    [Header("Patrolling")]
    [SerializeField] GameObject[] patrolPoints;
    [SerializeField] int maxRange;
    int minRange = 0;

    [Header("Attack")]
    [SerializeField] float playerDistance;
    [SerializeField] float timeBeforeAttack;
    [SerializeField] float enemyAttackSpeed;
    float attackTimer;

    CarController carController;

    // Start is called before the first frame update
    void Start()
    {
        carController = FindObjectOfType<CarController>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    int index;
    void EnemyMovement()
    {
        var lookRotation = patrolPoints[index].transform.position - transform.position;
        var rotation = Quaternion.LookRotation(lookRotation);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, enemyRotationSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[index].transform.position, enemySpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, patrolPoints[index].transform.position) == 0)
        {
            index = Random.Range(minRange, maxRange);
        }
    }

    //void EnemyAttack()
    //{
    //    float distance = Vector3.Distance(carController.transform.position, transform.position);
    //    var lookPosition = carController.transform.position - transform.position;
    //    lookPosition.y = 0;
    //    var lookRotation = Quaternion.LookRotation(lookPosition);

    //    if(playerDistance >= distance)
    //    {
    //        attackTimer += Time.deltaTime;

    //        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, enemyRotationSpeed * Time.deltaTime);

    //        if(attackTimer >= timeBeforeAttack)
    //        {
    //            Vector3 enemyPos = Vector3.MoveTowards(transform.position, enemyPos, ene)
    //        }
    //    }
    //}
}
