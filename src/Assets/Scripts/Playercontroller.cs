using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{  
    public float turnSpeed = 20f;

    public float moveSpeed = 5f;
    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
      
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            m_Movement.Set(horizontal, 0f, vertical);
            m_Movement.Normalize();

            Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
            m_Rotation = Quaternion.LookRotation(desiredForward);
        
            Move();
         
    }

    void Move()
    {
        Vector3 movement = m_Movement * moveSpeed * Time.fixedDeltaTime;
        m_Rigidbody.MovePosition(transform.position + movement);
    }

    void OnAnimatorMove()
    {
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
