using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
//using System.Numerics;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{

    public Transform playerCamera;
    public Transform portal_1;
    public Transform portal_2;

    void Start()
    {

        //Vector3 playerOffsetFromPortal = playerCamera.position - portal_1.position;
        //transform.position = portal_2.position + playerOffsetFromPortal;

    }


    // Update is called once per frame
    void Update()
    {


        Vector3 ajuste_pos_camera = new Vector3(1, 2, 3);


        // Movimenta a camera B junto com a Player's camera, no espaco 3D
        Vector3 playerOffsetFromPortal = playerCamera.position - portal_1.position;
        transform.position = portal_2.position + playerOffsetFromPortal;

        //Vector3 playerOffsetFromPortal = playerCamera.position - portal_1.position;
        //transform.position = new Vector3(playerOffsetFromPortal.x, playerOffsetFromPortal.y, playerOffsetFromPortal.z);

        //= -portal_1.position.x;

        // Ajusta tambem a rotacao da camera, pois acima cuidamos apenas da posicao x, y e z

        // recupero a diferenca angular entre os 2 portais para aplicar na camera
        float angDiffBetweenPortals = Quaternion.Angle(portal_2.rotation, portal_1.rotation);
        Quaternion portalRotDiff = Quaternion.AngleAxis(angDiffBetweenPortals, Vector3.up);

        // pega a direcao no qual a camera deve olhar
        Vector3 newCameraDir = portalRotDiff * playerCamera.forward;

        // transforma em um rotation
        transform.rotation = Quaternion.LookRotation(newCameraDir, Vector3.up);
 


    }
}
