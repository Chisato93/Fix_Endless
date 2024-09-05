using UnityEngine;

public interface IMovementItem
{
    void Move(Transform transform, float moveSpeed);
}
public class CoinMove : IMovementItem
{
    public void Move(Transform transform, float moveSpeed)
    {
        transform.Rotate(Vector3.up, moveSpeed * Time.deltaTime);
    }
}public class OxygenTankMove : IMovementItem
{
    public void Move(Transform transform, float moveSpeed)
    {
        float wave = Mathf.Sin(Time.time) * 0.5f;
        transform.position += new Vector3(0, wave, 0) * moveSpeed * Time.deltaTime;
    }
}
