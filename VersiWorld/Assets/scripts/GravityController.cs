using UnityEngine;
using System.Collections;

/// <summary>
/// This MonoBehaviour changes the gravity setting to a given float value along a given axis.
/// </summary>
public class GravityController : MonoBehaviour 
{
    public enum Direction
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    [Range(0, Mathf.Infinity)]
    [Tooltip("Absolute value of gravity value in axis of choice.")]
    public float Gravity;

    public Direction CurrentDirection;

    /// <summary>
    /// Change the gravity along given axis.
    /// </summary>
    /// <param name="newDirection"></param>
    public void ChangeGravityDirection(Direction newDirection)
    {
        Vector3 grav = Vector3.zero;
        switch (newDirection)
        {
            case Direction.DOWN:
                grav.y = -Gravity;
                break;
            case Direction.UP:
                grav.y = Gravity;
                break;
            case Direction.RIGHT:
                grav.x = Gravity;
                break;
            case Direction.LEFT:
                grav.x = -Gravity;
                break;
        }
        Physics.gravity = grav;
        CurrentDirection = newDirection;
    }

}
