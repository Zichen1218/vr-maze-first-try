using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class arrowLookAt : MonoBehaviour
{
    //public Transform player; 
    public XRBaseController headController;
    public Transform destination; 
    public Vector3 offset = new Vector3(0,2,0);

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.position = headController.transform.position + offset;
        transform.LookAt(new Vector3(destination.position.x, transform.position.y, destination.position.z));
        transform.Rotate(180, 0, 0);
    }
}
