using System;
using UnityEngine;

public class PlayerRunning : MonoBehaviour
{
    float MoveSpeed = 8f;
    float increase_Speed = 1f;
    public bool canTurn = false;

    private Rigidbody rb;

    private float speedUp_delay = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        InvokeRepeating("SpeedUP", speedUp_delay, speedUp_delay);
    }

    void SpeedUP()
    {
        Debug.Log("invoke success");
        MoveSpeed += increase_Speed;
    }

    void Update()
    {
        if (GameManager.instance.isLive)
        {
            if (canTurn)
            {
                Turn();
            }
            else
            {
                Move();
            }
        }
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis(AxisTag.HORIZONTAL);

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, 1f).normalized;
        Vector3 localMoveDirection = transform.TransformDirection(moveDirection);
        rb.MovePosition(transform.position + localMoveDirection * MoveSpeed * Time.deltaTime);

    }
    void Turn()
    {
        float horizontalInput = Input.GetAxis(AxisTag.HORIZONTAL);

        if (horizontalInput != 0f)
        {
            Vector3 eulerAngle = transform.eulerAngles;
            eulerAngle.y += horizontalInput > 0f ? 90f : -90f;
            transform.eulerAngles = eulerAngle;

            canTurn = false;
        }
        else
        {
            Vector3 forwardDirection = transform.forward;
            rb.MovePosition(transform.position + forwardDirection * MoveSpeed * Time.deltaTime);
        }
    }

    // 임시
    public void Death()
    {
        // 죽는 소리
        // 게임오버 판넬
        // 게임 정지
        Debug.Log("플레이어죽음");
    }
}
