using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    [SerializeField] private float currentMoveSpeed = 8f;             // 현재 이동속도
    [SerializeField] private float increase_Speed = 1f;               // 시간이 경과되면서 추가되는 속도
    [SerializeField] private float speedUp_delay = 10f;               // 올라가는 속도의 딜레이 시간
    [SerializeField] private const float start_delay_Time = 0f;       // 딜레이 시작 시간
    private bool canTurn = false;                                     // 회전 가능여부
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("SpeedUP", start_delay_Time, speedUp_delay);
    }


    private void FixedUpdate()
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

    void SpeedUP()
    {
        currentMoveSpeed += increase_Speed;
    }
    void Move()
    {
        float horizontalInput = Input.GetAxis(AxisTag.HORIZONTAL);

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, 1f).normalized;
        Vector3 localMoveDirection = transform.TransformDirection(moveDirection);
        rb.MovePosition(transform.position + localMoveDirection * currentMoveSpeed * Time.fixedDeltaTime);

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
            rb.MovePosition(transform.position + forwardDirection * currentMoveSpeed * Time.fixedDeltaTime);
        }
    }

    public void SetTurn()
    {
        canTurn = true;
    }
}
