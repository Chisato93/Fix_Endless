using UnityEngine;

public class Oxygen : MonoBehaviour, ICharacterBaseStatus
{
    private PlayerInteract _playerInteract;

    private int _maxOxygen = 100;
    private int _currentOxygen;

    private float oxygenDecreaseInterval = 1f;
    private float decreaseAmount = 1f;

    private void Awake()
    {
        _playerInteract = GetComponent<PlayerInteract>();
    }

    private void Start()
    {
        _currentOxygen = _maxOxygen;
        InvokeRepeating(nameof(DecreaseOxygen), oxygenDecreaseInterval, oxygenDecreaseInterval);
    }
    private void DecreaseOxygen()
    {
        AddOxygen(-(int)decreaseAmount);
    }

    public float GetOxygenRate()
    {
        return (float)_currentOxygen / _maxOxygen;
    }

    public void AddOxygen(int amount)
    {
        _currentOxygen += amount;
        if (_currentOxygen <= 0)
        {
            _currentOxygen = 0;
            _playerInteract.Dead();
        }
    }

    public void SetOxygenDecreaseInterval(float interval)
    {
        oxygenDecreaseInterval += interval;
    }

    public void ApplyEffect(float effectValue)
    {
        oxygenDecreaseInterval += effectValue;
    }

    public void RemoveEffect(float effectValue)
    {
        oxygenDecreaseInterval -= effectValue;
    }
}
