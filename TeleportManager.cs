using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Transform[] positions;
   

    // Update is called once per frame
    void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            print("TELEPORT TO POSITION " + positions[0].position);
            player.transform.position = positions[0].position;
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            player.transform.position = positions[1].position;
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            player.transform.position = positions[2].position;
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            player.transform.position = positions[3].position;
        }
    }
}
