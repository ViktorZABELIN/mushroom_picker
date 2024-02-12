using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] Animator _animation;

    private float OldMausePositionX;
    private float eulerY;

    void Start()
    {
        
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            OldMausePositionX = Input.mousePosition.x;
            _animation.SetBool("Run", true);
        }



        if (Input.GetMouseButton(0))
        {
            Vector3 newPosition = transform.position + transform.forward * Time.deltaTime * _speed;
            newPosition.x = Mathf.Clamp(newPosition.x, -2.5f, 2.5f);
            transform.position = newPosition;

            float deltaX = Input.mousePosition.x - OldMausePositionX;
            OldMausePositionX = Input.mousePosition.x;

            eulerY += deltaX;
            eulerY = Mathf.Clamp(eulerY, - 70, 70);
            transform.eulerAngles = new Vector3(0, eulerY, 0);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _animation.SetBool("Run", false);
        }

    }
}
