using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ClientSideMovement : MonoBehaviour
{
    private PlayerMovement playerMovement;
    void Start()
    {
        PhotonNetwork.SetSendingEnabled(1, true);
        PhotonNetwork.SetInterestGroups(1, false);
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        playerMovement.velocity = new Vector3(0, vertical, 0);
        if (playerMovement.velocity.magnitude > 0) Debug.Log("moved");
    }
}
