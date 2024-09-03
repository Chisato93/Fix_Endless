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
            // 캐릭터를 90도 회전시킴
            Vector3 eulerAngle = transform.eulerAngles;
            eulerAngle.y += horizontalInput > 0f ? 90f : -90f;
            transform.eulerAngles = eulerAngle;

            // 회전 후에는 다시 회전을 허용하지 않음
            canTurn = false;
        }
        else
        {
            // 캐릭터가 앞으로 계속 나아가도록 설정
            Vector3 forwardDirection = transform.forward;
            rb.MovePosition(transform.position + forwardDirection * MoveSpeed * Time.deltaTime);
        }
    }
}
