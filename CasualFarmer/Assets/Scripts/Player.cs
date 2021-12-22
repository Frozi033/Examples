using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : StickmanCore
{
    [SerializeField] private GameObject Arrow;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        Move();
        //ArrowDirection();
        
    }
    private void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));


        Move(direction);
    }

   /* private void ArrowDirection()
    {
        if (LifeStatus == Status.DeliveringOrder)
        {
            Arrow.transform.LookAt(GameObject.FindGameObjectWithTag("Delivering").transform);
        }
        else if (LifeStatus == Status.Live)
        {
            Arrow.transform.LookAt(GameObject.FindGameObjectWithTag("PlayerShop").transform);
        }
    }*/
}
