using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Gate : MonoBehaviour
{
    private int value;
    private DeformationType deformationType;
    [SerializeField] GateScript gateScript;

    private void Start()
    {
       deformationType = (DeformationType)Random.Range(0, 2);
       value = Random.Range(-16, 17);

        gateScript.UpdateVisual(deformationType, value);
    }


    public void OnTriggerEnter(Collider other)
    {
        PlayerModifi playerModifi = other.attachedRigidbody.GetComponent<PlayerModifi>();

        if (playerModifi != null)
        {
            if (deformationType == DeformationType.Height)
            {
                playerModifi.AddHight(value);
            }
            else if (deformationType == DeformationType.Width)
            {
                playerModifi.AddWeight(value);
            }

            Destroy(gameObject);
        }


    }






}
