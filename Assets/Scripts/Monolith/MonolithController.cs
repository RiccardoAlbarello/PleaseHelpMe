using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonolithController : MonoBehaviour
{
    [Header("Trail")]
    [SerializeField] GameObject particle;
    [SerializeField] GameObject destination;
    [SerializeField] float trailSpeed;

    [Header("Rotation Angle")]
    [SerializeField] float rotation;
    public float angleToRotate = 20f;
    public float speed = 5f;

    Collider colliders;
    SaveExample saveEx;

    Quaternion targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        colliders = GetComponent<Collider>();
        targetRotation = transform.rotation;
        saveEx = FindObjectOfType<SaveExample>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Active)
            MonolithLight();
    }

    public bool Active = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Rover"))
        {
            targetRotation *= Quaternion.AngleAxis(angleToRotate, Vector3.left);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speed * Time.deltaTime);

            if(targetRotation.eulerAngles.y <= rotation)
            {
                colliders.enabled = false;
                Active = true;
                speed = 0;
                GameManager.Instance.monolithCollection.Add(gameObject);
                saveEx.numberOfEnigmi++;
            }

        }

    }

    void MonolithLight()
    {
        particle.SetActive(true);
        StartCoroutine(LigthTransformPosition());
    }

    IEnumerator LigthTransformPosition()
    {
        yield return new WaitForSeconds(3);
        particle.transform.position = Vector3.MoveTowards(particle.transform.position, destination.transform.position, trailSpeed * Time.deltaTime);
    }
}
