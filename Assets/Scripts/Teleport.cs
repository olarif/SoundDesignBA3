using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public GameObject teleport;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        teleportPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void teleportPlayer()
    {
        player.transform.position = teleport.transform.position;
    }
}
