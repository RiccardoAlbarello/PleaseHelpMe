using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private List<RopeSegment> ropeSegments = new List<RopeSegment>();
    private float ropeSegLen = 0.25f;
    private int segmentLength = 35;
    private float lineWidth = 0.1f;
    public float maxDist = 10f;
    [SerializeField] private Transform startPoint;
    private Transform endPoint;
    private GameObject InteractableObject;
    private ConfigurableJoint configurableJoint;
    public bool spawn = false;
    public bool canInteract = false;
    Rigidbody rb;
    public KeyCode codeSpawn;
    public KeyCode codeRiavvolgere;
    public float forzaVerricelloNormale;
    public float forzaVerricelloAumentata;

    // Use this for initialization
    void Start()
    {
        this.lineRenderer = this.GetComponent<LineRenderer>();
        Vector3 ropeStartPoint = Vector3.zero;

        for (int i = 0; i < segmentLength; i++)
        {
            this.ropeSegments.Add(new RopeSegment(ropeStartPoint));
            ropeStartPoint.y -= ropeSegLen;
        }

        
        rb = transform.root.GetComponent<Rigidbody>();
        Debug.Log(rb.transform.name);
        configurableJoint = gameObject.GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(codeSpawn) && canInteract == true)
        {
            if (spawn == false)
            {
                spawn = true;
            }
            else if (spawn == true)
            {
                canInteract = false;
                spawn = false;
                lineRenderer.positionCount = 0;
                endPoint = null;
                configurableJoint.connectedBody = null;
            }
        }

        if (Input.GetKey(codeRiavvolgere))
        {
            configurableJoint.angularYZDrive = new JointDrive()
            {
                maximumForce = 3.402823e+38f,
                positionDamper = 0,
                positionSpring = forzaVerricelloAumentata
            };

            configurableJoint.angularXDrive = new JointDrive()
            {
                maximumForce = 3.402823e+38f,
                positionDamper = 0,
                positionSpring = forzaVerricelloAumentata
            };

            configurableJoint.yDrive = new JointDrive()
            {
                maximumForce = 3.402823e+38f,
                positionDamper = 0,
                positionSpring = forzaVerricelloAumentata
            };

            configurableJoint.xDrive = new JointDrive()
            {
                maximumForce = 3.402823e+38f,
                positionDamper = 0,
                positionSpring = forzaVerricelloAumentata
            };

            configurableJoint.zDrive = new JointDrive()
            {
                maximumForce = 3.402823e+38f,
                positionDamper = 0,
                positionSpring = forzaVerricelloAumentata
            };
        }
        else 
        {
            configurableJoint.angularYZDrive = new JointDrive()
            {
                maximumForce = 3.402823e+38f,
                positionDamper = 0,
                positionSpring = forzaVerricelloNormale
            };

            configurableJoint.angularXDrive = new JointDrive()
            {
                maximumForce = 3.402823e+38f,
                positionDamper = 0,
                positionSpring = forzaVerricelloNormale
            };

            configurableJoint.yDrive = new JointDrive()
            {
                maximumForce = 3.402823e+38f,
                positionDamper = 0,
                positionSpring = forzaVerricelloNormale
            };

            configurableJoint.xDrive = new JointDrive()
            {
                maximumForce = 3.402823e+38f,
                positionDamper = 0,
                positionSpring = forzaVerricelloNormale
            };

            configurableJoint.zDrive = new JointDrive()
            {
                maximumForce = 3.402823e+38f,
                positionDamper = 0,
                positionSpring = forzaVerricelloNormale
            };
        }


        if (spawn)
        {
            this.DrawRope();
        }
    }

    private void FixedUpdate()
    {
        if (spawn)
        {
            this.Simulate();
        }
    }

    private void Simulate()
    {
        // SIMULATION
        Vector3 forceGravity = new Vector3(0f, -1.5f, 0f);

        for (int i = 1; i < this.segmentLength; i++)
        {
            RopeSegment firstSegment = this.ropeSegments[i];
            Vector3 velocity = firstSegment.posNow - firstSegment.posOld;
            firstSegment.posOld = firstSegment.posNow;
            firstSegment.posNow += velocity;
            firstSegment.posNow += forceGravity * Time.fixedDeltaTime;
            this.ropeSegments[i] = firstSegment;
            
        }

        //CONSTRAINTS
        for (int i = 0; i < 50; i++)
        {
            this.ApplyConstraint();
        }
    }

    private void ApplyConstraint()
    {
        

        RopeSegment firstSegment = this.ropeSegments[0];
        firstSegment.posNow = this.startPoint.position;
        this.ropeSegments[0] = firstSegment;

        RopeSegment endSegment = this.ropeSegments[this.segmentLength - 1];
        endSegment.posNow = this.endPoint.position;
        this.ropeSegments[this.segmentLength - 1] = endSegment;

        

        for (int i = 0; i < this.segmentLength - 1; i++)
        {
            RopeSegment firstSeg = this.ropeSegments[i];
            RopeSegment secondSeg = this.ropeSegments[i + 1];

            float dist = (firstSeg.posNow - secondSeg.posNow).magnitude;
            float error = Mathf.Abs(dist - this.ropeSegLen);
            Vector3 changeDir = Vector3.zero;

            if (dist > ropeSegLen)
            {
                changeDir = (firstSeg.posNow - secondSeg.posNow).normalized;
            }
            else if (dist < ropeSegLen)
            {
                changeDir = (secondSeg.posNow - firstSeg.posNow).normalized;
            }

            Vector3 changeAmount = changeDir * error;
            if (i != 0)
            {
                firstSeg.posNow -= changeAmount * 0.5f;
                this.ropeSegments[i] = firstSeg;
                secondSeg.posNow += changeAmount * 0.5f;
                this.ropeSegments[i + 1] = secondSeg;
            }
            else
            {
                secondSeg.posNow += changeAmount;
                this.ropeSegments[i + 1] = secondSeg;
            }
        }
    }

    private void DrawRope()
    {
        float lineWidth = this.lineWidth;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;

        Vector3[] ropePositions = new Vector3[this.segmentLength];
        for (int i = 0; i < this.segmentLength; i++)
        {
            ropePositions[i] = this.ropeSegments[i].posNow;
        }

        lineRenderer.positionCount = ropePositions.Length;
        lineRenderer.SetPositions(ropePositions);
    }

    public struct RopeSegment
    {
        public Vector3 posNow;
        public Vector3 posOld;

        public RopeSegment(Vector3 pos)
        {
            this.posNow = pos;
            this.posOld = pos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Interactable"))
        {
            InteractableObject = other.gameObject;

            endPoint = InteractableObject.transform;

            canInteract = true;
            configurableJoint.connectedBody = InteractableObject.GetComponent<Rigidbody>();

            Debug.Log(InteractableObject.name);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable") && spawn == false)
        {
            configurableJoint.connectedBody = null;

            if (InteractableObject != null)
            {
                InteractableObject = null;
            }

            canInteract = false;
        }
        
    }
}