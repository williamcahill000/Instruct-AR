using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveToPoint : MonoBehaviour
{
    public Transform target, start;
    public NavGraph navGraph;
    private Vector3 ToTarget, dif, startPos;
    Vector2 temp, temp2;
    public List<NavGraphNode> pathToWalk = new();
    public Rigidbody rigidBody;
    public float speed = 1.0f, acceleration = 1.0f, stoppingDistanceEpsilon = 0.05f, distance, rotationSpeed = 0.1f, rotate;
    public bool walk = false;
    public AnimationController animCon;


    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animCon = GetComponent<AnimationController>();
    }
    public void Embiggen()
    {
        speed = 1.0f;
        transform.localScale = 4.0f * Vector3.one;
        transform.localScale = 4.0f * Vector3.one;
    }
    private void Awake()
    {
        startPos = transform.position;
    }
    public void MoveToStart()
    {
        this.gameObject.transform.position = startPos;
    }
    public void UpdateStartPos()
    {
        startPos = start.transform.position;
    }
    private void FixedUpdate()
    {
        if (pathToWalk.Count <= 0) return;
        if (walk == false || animCon.dance || animCon.sleep) return;
        target.position = pathToWalk[0].transform.position;
        temp.x = this.transform.position.x;
        temp.y = this.transform.position.z;
        temp2.x = target.position.x;
        temp2.y = target.position.z;
        distance = Vector2.Distance(temp, temp2);
        if(distance < stoppingDistanceEpsilon)
        {
            pathToWalk.RemoveAt(0);
            if (pathToWalk.Count == 0)
                return;
        }
        target.position = pathToWalk[0].transform.position;
        if (distance < stoppingDistanceEpsilon) return;
        ToTarget = (target.position - transform.position);

        if (rigidBody.velocity.magnitude < speed)
        {
            ToTarget.y = transform.position.y;
            rigidBody.AddForce(ToTarget.normalized * acceleration * (speed - rigidBody.velocity.magnitude), ForceMode.Impulse);
        }
        if(rigidBody.velocity.magnitude > 0.01f)
        {
            ToTarget.y = 0;
            transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, ToTarget, 0.04f, 0.0f));
        }
    }
    public void LoadInPath()
    {
        pathToWalk.Clear();
        if (navGraph.path.Count == 0) return;
        Debug.Log("Loading Path");
        foreach (NavGraphNode node in navGraph.path)
            pathToWalk.Add(node);
    }
    /*
    private void Update()
    {
        rigidBody.angularVelocity = new Vector3(0, rigidBody.angularVelocity.y, 0);
        Vector3 targetDir = target.position - transform.position;
        Vector3 forward = transform.forward;
        float angle = Vector3.SignedAngle(targetDir, forward, Vector3.up);
        if (angle < -1.0F)
        {
            //print("turn left");
            rigidBody.AddTorque(Vector3.up * rotationSpeed, ForceMode.Acceleration);
        }
        else if (angle > 1.0F)
        {
            //print("turn right");
            rigidBody.AddTorque(Vector3.up * -rotationSpeed, ForceMode.Acceleration);
        }
        //else
            //print("forward");
    }
    */
}
