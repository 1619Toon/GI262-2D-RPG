using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHp = 10;  // ค่าผู้เล่นเต็ม
    private int currentHp;

    private void Start()
    {
        currentHp = maxHp;  // เริ่มต้นด้วย HP เต็ม
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        currentHp = Mathf.Clamp(currentHp, 0, maxHp);  // ห้ามค่า HP ต่ำกว่า 0 หรือสูงกว่า maxHp

        if (currentHp <= 0)
        {
            Die();  // ถ้า HP = 0 จะทำให้มอนตาย
        }
    }

    public int GetCurrentHealth()
    {
        return currentHp;  // คืนค่าปัจจุบันของ HP
    }

    private void Die()
    {
        Destroy(gameObject); // ทำลายมอนสเตอร์
        Debug.Log("Monster destroyed!");
    }
}