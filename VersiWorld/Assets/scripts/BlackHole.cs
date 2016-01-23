using UnityEngine;
using System.Collections;

public class BlackHole : MonoBehaviour
{
    public float respawnTime;
    public GameObject gravityCommand;

    GameObject player;
    Vector3 playerStartPosition;

    GravityController gravControl;
    GravityController.Direction startDirection;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Assert(player != null, "Could not find player");
        playerStartPosition = player.transform.position;
        gravControl = gravityCommand.GetComponent<GravityController>();
        startDirection = gravControl.CurrentDirection;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.SetActive(false);
            player.transform.position = playerStartPosition;
            gravControl.ChangeGravityDirection(startDirection);
            player.GetComponent<Rigidbody>().velocity = Vector3.zero;
            player.SetActive(true);
        }
    }
}
