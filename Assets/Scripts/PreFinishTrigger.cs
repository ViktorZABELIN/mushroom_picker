using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreFinishTrigger : MonoBehaviour
{


    public void OnTriggerEnter(Collider other)
    {
        PlayerBeholder PlayerBeholder = other.attachedRigidbody.GetComponent<PlayerBeholder>();

        if (PlayerBeholder)
        {
            PlayerBeholder.PreFinish();
        }

    }

}
