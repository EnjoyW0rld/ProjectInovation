using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Net;
using TMPro;
using System.Text;
using System;

public class TCP_Client : MonoBehaviour
{
    private TcpClient tcpClient;
    [SerializeField] private TextMeshProUGUI text;
    //private IPEndPoint remoteEndPoint;
    // Start is called before the first frame update
    void Start()
    {
        tcpClient.Connect(IPAddress.Parse("84.28.23.116"), 55555);
    }

    // Update is called once per frame
    void Update()
    {
        if (tcpClient.Available > 0)
        {
            byte[] data = new byte[4];
            tcpClient.GetStream().Read(data, 0, 4);
            text.text = "" + BitConverter.ToInt32(data, 0);
        }
    }
}
