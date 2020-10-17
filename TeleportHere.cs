using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportHere : MonoBehaviour
{
    public GameObject player;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("GameBullet")){
            player.transform.position = new Vector3(this.transform.position.x, player.transform.position.y, this.transform.position.z);
        }
    }
}
