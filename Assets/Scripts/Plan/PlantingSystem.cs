using UnityEngine;

public class PlantingSystem : MonoBehaviour
{
    public GameObject plantPrefab;  // ไอเทมพืชที่สามารถปลูกได้
    public Transform[] plantingSpots;  // จุดปลูกพืช

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))  // กด P เพื่อปลูกพืช
        {
            PlantSeed();
        }
    }

    void PlantSeed()
    {
        foreach (Transform spot in plantingSpots)
        {
            if (!spot.GetComponentInChildren<SimplePlant>())
            {
                // สร้างพืชใหม่ในจุดที่เลือก
                GameObject newPlant = Instantiate(plantPrefab, spot.position, Quaternion.identity);
                SimplePlant plant = newPlant.GetComponent<SimplePlant>();
                plant.growthTime = Random.Range(3f, 10f);  // กำหนดเวลาการเติบโตแบบสุ่ม
                break;  // หยุดการปลูกหลังจากปลูกพืชแล้ว
            }
        }
    }
}