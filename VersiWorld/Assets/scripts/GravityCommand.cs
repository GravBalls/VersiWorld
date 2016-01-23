using UnityEngine;
using System.Collections;


[RequireComponent(typeof(GravityController))]
public class GravityCommand : CommandParent
{
     public enum SWITCH_MODE
    {
        CLOCKWISE,
        COUNTER_CLOCKWISE,
        FLIP
    }

       public float coolDownTimer;

    public SWITCH_MODE currentMode;

    private float currentCoolDownTime = 0;
    private bool isCooled = true;
    private GravityController gravControl;

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

        gravControl = GetComponent<GravityController>();
        gravControl.CurrentDirection = GravityController.Direction.DOWN;


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
                    switch (gravControl.CurrentDirection)
                    {
                        case GravityController.Direction.DOWN:
                            gravControl.ChangeGravityDirection(GravityController.Direction.LEFT);
                            break;
                        case GravityController.Direction.LEFT:
                            gravControl.ChangeGravityDirection(GravityController.Direction.UP);
                            break;
                        case GravityController.Direction.UP:
                            gravControl.ChangeGravityDirection(GravityController.Direction.RIGHT);
                            break;
                        case GravityController.Direction.RIGHT:
                            gravControl.ChangeGravityDirection(GravityController.Direction.DOWN);
                            break;
                    }
                    break;
                case SWITCH_MODE.COUNTER_CLOCKWISE:
                    switch (gravControl.CurrentDirection)
                    {
                        case GravityController.Direction.DOWN:
                            gravControl.ChangeGravityDirection(GravityController.Direction.RIGHT);
                            break;
                        case GravityController.Direction.RIGHT:
                            gravControl.ChangeGravityDirection(GravityController.Direction.UP);
                            break;
                        case GravityController.Direction.UP:
                            gravControl.ChangeGravityDirection(GravityController.Direction.LEFT);
                            break;
                        case GravityController.Direction.LEFT:
                            gravControl.ChangeGravityDirection(GravityController.Direction.DOWN);
                            break;
                    }
                    break;
                case SWITCH_MODE.FLIP:
                    switch (gravControl.CurrentDirection)
                    {
                        case GravityController.Direction.DOWN:
                            gravControl.ChangeGravityDirection(GravityController.Direction.UP);
                            break;
                        case GravityController.Direction.UP:
                            gravControl.ChangeGravityDirection(GravityController.Direction.DOWN);
                            break;
                        case GravityController.Direction.RIGHT:
                            gravControl.ChangeGravityDirection(GravityController.Direction.LEFT);
                            break;
                        case GravityController.Direction.LEFT:
                            gravControl.ChangeGravityDirection(GravityController.Direction.RIGHT);
                            break;
                    }
                    break;
            }
            isCooled = false;
        }

    }

}
