using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float Health = 100;
    public RectTransform ValueRectTransform;

    private float _maxValue;

    private void Start()
    {
        _maxValue = Health;
        DrawHealthBar();
    }

    private void DrawHealthBar()
    {
        ValueRectTransform.anchorMax = new Vector2(Health / _maxValue, 1);
    }

    public void DealDamageToPlayer(float Damage)
    {
        Health -= Damage;

        DrawHealthBar();
    }
    void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}