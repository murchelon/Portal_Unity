using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{

    public Transform player;
    public Transform reciever;

    private bool isPlayerOverlapping = false;

    


    void Update()
    {
        if (isPlayerOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);



            if (dotProduct < 0f)
            {


                float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = reciever.position + positionOffset;



                Transform playerMesh = GameObject.FindGameObjectWithTag("PlayerMesh").transform;
                playerMesh.Rotate(Vector3.up, rotationDiff);
                playerMesh.position = reciever.position + positionOffset;

                //player.transform.position = new Vector3(9, 2, -13);

                isPlayerOverlapping = false;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Player")
        {
            isPlayerOverlapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerOverlapping = false;
        }
    }
}
