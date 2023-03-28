using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ServerSidePlayer : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private void Start()
    {
        PhotonNetwork.SetSendingEnabled(1, false);
        PhotonNetwork.SetInterestGroups(1, true);

        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        transform.position += playerMovement.velocity;
        if (playerMovement.velocity.magnitude > 0) Debug.Log("Movemnt get");
    }
}
