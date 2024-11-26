using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Health monsterHealth; // กำหนด Health ของมอนสเตอร์ที่เราต้องการโจมตี
    [SerializeField] private int damage = 5; // ค่า Damage ที่จะลดลงจากมอนสเตอร์

    private void Start()
    {
        if (monsterHealth == null)
        {
            monsterHealth = FindObjectOfType<Health>(); // ค้นหาคอมโพเนนต์ Health ในฉาก
            if (monsterHealth == null)
            {
                Debug.LogError("No Health component found in the scene!");
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // เมื่อกดปุ่ม F
        {
            AttackMonster();
        }
    }

    private void AttackMonster()
    {
        if (monsterHealth != null)
        {
            monsterHealth.TakeDamage(damage); // เรียกฟังก์ชัน TakeDamage ของมอนสเตอร์

            // ตรวจสอบว่า HP ของมอนสเตอร์เหลือ 0 หรือไม่
            if (monsterHealth.GetCurrentHealth() <= 0)
            {
                DestroyMonster(); // ถ้า HP = 0 ให้ทำลายมอนสเตอร์
            }
        }
        else
        {
            Debug.LogError("Monster Health is not assigned!");
        }
    }

    private void DestroyMonster()
    {
        Destroy(monsterHealth.gameObject); // ทำลายมอนสเตอร์
        Debug.Log("Monster destroyed!");
    }
}