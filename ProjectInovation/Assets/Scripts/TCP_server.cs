using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Net;

public class TCP_server : MonoBehaviour
{
    private TcpListener listener;
    private TcpClient client;
    // Start is called before the first frame update
    void Start()
    {
        listener = new TcpListener(IPAddress.Any, 55555);
        listener.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (listener.Pending())
        {
            client = listener.AcceptTcpClient();
            System.Console.WriteLine("Client accepted");
        }
    }
}
