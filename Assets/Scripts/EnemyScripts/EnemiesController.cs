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
    //[SerializeField] float patrolTimer;
    //float timer;
    int minRange = 0;


    [Header("Attack")]
    [SerializeField] float playerDistance;
    [SerializeField] float timeBeforeAttack;
    [SerializeField] float enemyAttackSpeed;
    [SerializeField] float knockBackForce;
    float attackTimer;

    CarController carController;
    //Rigidbody rb;

    Vector3 firstPosition;
    Quaternion firstRotation;

    // Start is called before the first frame update
    void Start()
    {
        carController = FindObjectOfType<CarController>();
        //rb = GetComponent<Rigidbody>();

        firstPosition = transform.position;
        firstRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isStunned)
            EnemyAttack();
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

    void EnemyAttack()
    {
        float distance = Vector3.Distance(carController.transform.position, transform.position);
        var lookPosition = carController.transform.position - transform.position;
        lookPosition.y = 0;
        var lookRotation = Quaternion.LookRotation(lookPosition);

        if (playerDistance >= distance)
        {

            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, enemyRotationSpeed * Time.deltaTime);
            Vector3 enemyPos = new Vector3(carController.transform.position.x, 0, carController.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, enemyPos, enemyAttackSpeed * Time.deltaTime);

        }
        else
        {
            EnemyMovement();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isStunRunning = true;
            StartCoroutine(EnemyStun());
            //KnockBack();
        }
    }

    private bool isStunned;
    private bool isStunRunning;
    private IEnumerator EnemyStun()
    {
        if (isStunRunning)
        {
            isStunned = true;
            yield return new WaitForSecondsRealtime(3f);
            isStunned = false;
            isStunRunning = false;
        }

    }

    //private void KnockBack()
    //{
    //    Vector3 targetPos = carController.gameObject.transform.position;
    //    Vector3 startPos = transform.position;
    //    rb.AddForce((startPos - targetPos) * knockBackForce, ForceMode.Impulse);
    //    //rb.AddForce((targetPos - startPos) * knockBackForce, ForceMode.Impulse);
    //}
}
