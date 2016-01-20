using UnityEngine;
using System.Collections;

public class MovingPlatformScript : CommandParent {

    public enum MovementType {
        //moves between both points if activateable, activate will toggle wether or not it moving
        MOVE_CONTINUOUS,
        //moves between both points, pausing when ariving if activateable, activate will tell the platform to move from its current point to the next, then stop
        MOVE_PAUSE,
        //moves from start to the endpoint if activateable, activate will move the platform to the endpoint and then will ignore future calls to activate
        MOVE_ONCE
    }

    public bool isActivatable = false;
    public GameObject endPosition;
    [Tooltip("Time the platform takes to move between positions in seconds")]
    public float moveTime = 1.0f;
    [Tooltip("Time the platform will pause in seconds")]
    public float pauseTime = 2.0f;
    public MovementType moveType = MovementType.MOVE_PAUSE;

    Vector3 startingPoint;
    Vector3 endingPoint;

    bool endpointIsTarget = true;
    bool pauseMovement = false;
    float curentLerpTime;
    float remainingPauseTime = 0.0f;

    Rigidbody myRigidbody;

    // Use this for initialization
    void Start () {
        startingPoint = transform.position;
        endingPoint = endPosition.transform.position;
        curentLerpTime = 0.0f;
        //remainingPauseTime = pauseTime;
        myRigidbody = GetComponent<Rigidbody>();

        if (isActivatable)
        {
            pauseMovement = true;
            actionDescription = "Move Platform";
        }
	}

    // Update is called once per frame
    void FixedUpdate() {
        if (!pauseMovement)
        {
            if (remainingPauseTime > 0.0f)
            {
                remainingPauseTime -= Time.fixedDeltaTime;
            }

            //dirty but this will get stuck if it doesnt move imediatly
            if (endpointIsTarget && remainingPauseTime <= 0.0f)
            {
                curentLerpTime += Time.fixedDeltaTime;
            }
            else if (remainingPauseTime <= 0.0f)
            {
                curentLerpTime -= Time.fixedDeltaTime;
            }

            if ((curentLerpTime >= moveTime || curentLerpTime <= 0.0f) && remainingPauseTime <= 0.0f)
            {
                endpointIsTarget = !endpointIsTarget;
                Mathf.Clamp(curentLerpTime, 0.0f, moveTime);
                if (moveType == MovementType.MOVE_PAUSE)
                {
                    remainingPauseTime = pauseTime;
                }
                if ((isActivatable && moveType != MovementType.MOVE_CONTINUOUS) || moveType == MovementType.MOVE_ONCE)
                {
                    pauseMovement = true;
                }
            }
        }

        myRigidbody.position = Vector3.Lerp(startingPoint, endingPoint, curentLerpTime / moveTime);
	}

    public override void Activate()
    {
        if (isActivatable)
        {
            if (moveType == MovementType.MOVE_CONTINUOUS)
            {
                pauseMovement = !pauseMovement;
            }
            else if (moveType == MovementType.MOVE_PAUSE)
            {
                if (pauseMovement)
                {
                    pauseMovement = false;
                    remainingPauseTime = 0.0f;
                }
            }
            else if (moveType == MovementType.MOVE_ONCE)
            {
                pauseMovement = false;
                isActivatable = false;
            }
        }
    }
}
