using UnityEngine;

public class ItemMove : MonoBehaviour
{
    private bool _isActive = false;
    public ItemType itemType;
    private IMovementItem _movementItem;
    [SerializeField] private float moveSpeed;

    private void Start()
    {
        _movementItem = GetMovementItem(itemType);
    }

    private IMovementItem GetMovementItem(ItemType type)
    {
        switch (type)
        {
            case ItemType.COIN:
                return new CoinMove();
            case ItemType.OXYGEN:
                return new OxygenTankMove();
            default:
                Debug.LogWarning("잘못된 아이템 타입");
                return null;
        }
    }

    private void OnEnable()
    {
        _isActive = true;
    }
    private void OnDisable()
    {
        _isActive = false;
    }

    void Update()
    {
        if(_isActive)
        {
            _movementItem?.Move(transform, moveSpeed);
        }
    }

}
