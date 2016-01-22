using UnityEngine;
using System.Collections;

public class BlackHole : MonoBehaviour
{
    public float respawnTime;
    public GameObject gravityCommand;

    GameObject player;
    Vector3 playerStartPosition;
    GravityCommand.DIRECTION startDirection;
    GravityCommand gravScript;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Assert(player != null, "Could not find player");
        playerStartPosition = player.transform.position;
        gravScript = gravityCommand.GetComponent<GravityCommand>() as GravityCommand;
        startDirection = gravScript.currentDirection;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.SetActive(false);
            player.transform.position = playerStartPosition;
            gravScript.ChangeGravityDirection(startDirection);
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.SetActive(true);
        }
    }
}
