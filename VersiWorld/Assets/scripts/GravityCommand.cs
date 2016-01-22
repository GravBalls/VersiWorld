using UnityEngine;
using System.Collections;



public class GravityCommand : CommandParent
{
    public enum DIRECTION
    {
        UP,
        RIGHT,
        DOWN,
        LEFT
    }

    public enum SWITCH_MODE
    {
        CLOCKWISE,
        COUNTER_CLOCKWISE,
        FLIP
    }

    [Range(0, Mathf.Infinity)]
    [Tooltip("Absolute value of gravity value in axis of choice.")]
    public float gravity;
    public float coolDownTimer;

    public DIRECTION currentDirection;
    public SWITCH_MODE currentMode;

    private float currentCoolDownTime = 0;
    private bool isCooled = true;

    void Awake ()
    {
        switch (currentMode)
        {
            case SWITCH_MODE.CLOCKWISE:
                actionDescription = "Grav C-wise";
                break;
            case SWITCH_MODE.COUNTER_CLOCKWISE:
                actionDescription = "Grav Cntr C-wise";
                break;
            case SWITCH_MODE.FLIP:
                actionDescription = "Grav Reverse";
                break;
        }
        currentDirection = DIRECTION.DOWN;
    }

    void Update()
    {
        if (!isCooled)
        {
            if (currentCoolDownTime < coolDownTimer)
            {
                currentCoolDownTime += Time.deltaTime;
            }
            else
            {
                currentCoolDownTime = 0;
                isCooled = true;
            }

        }
    }

    public override void Activate()
    {
        if (isCooled)
        {
            switch (currentMode)
            {
                case SWITCH_MODE.CLOCKWISE:
                    switch (currentDirection)
                    {
                        case DIRECTION.DOWN:
                            ChangeGravityDirection(DIRECTION.LEFT);
                            break;
                        case DIRECTION.LEFT:
                            ChangeGravityDirection(DIRECTION.UP);
                            break;
                        case DIRECTION.UP:
                            ChangeGravityDirection(DIRECTION.RIGHT);
                            break;
                        case DIRECTION.RIGHT:
                            ChangeGravityDirection(DIRECTION.DOWN);
                            break;
                    }
                    break;
                case SWITCH_MODE.COUNTER_CLOCKWISE:
                    switch (currentDirection)
                    {
                        case DIRECTION.DOWN:
                            ChangeGravityDirection(DIRECTION.RIGHT);
                            break;
                        case DIRECTION.RIGHT:
                            ChangeGravityDirection(DIRECTION.UP);
                            break;
                        case DIRECTION.UP:
                            ChangeGravityDirection(DIRECTION.LEFT);
                            break;
                        case DIRECTION.LEFT:
                            ChangeGravityDirection(DIRECTION.DOWN);
                            break;
                    }
                    break;
                case SWITCH_MODE.FLIP:
                    switch (currentDirection)
                    {
                        case DIRECTION.DOWN:
                            ChangeGravityDirection(DIRECTION.UP);
                            break;
                        case DIRECTION.UP:
                            ChangeGravityDirection(DIRECTION.DOWN);
                            break;
                        case DIRECTION.RIGHT:
                            ChangeGravityDirection(DIRECTION.LEFT);
                            break;
                        case DIRECTION.LEFT:
                            ChangeGravityDirection(DIRECTION.RIGHT);
                            break;
                    }
                    break;
            }
        }

    }

    public void ChangeGravityDirection(DIRECTION newDirection)
    {
        Vector3 grav = Vector3.zero;
        switch (newDirection)
        {
            case DIRECTION.DOWN:
                grav.y = -gravity;
                break;
            case DIRECTION.UP:
                grav.y = gravity;
                break;
            case DIRECTION.RIGHT:
                grav.x = gravity;
                break;
            case DIRECTION.LEFT:
                grav.x = -gravity;
                break;
        }
        Physics.gravity = grav;
        currentDirection = newDirection;
        isCooled = false;
    }

}
