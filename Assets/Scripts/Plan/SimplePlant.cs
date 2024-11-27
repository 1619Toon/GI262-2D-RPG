using UnityEngine;

public class SimplePlant : MonoBehaviour
{
    public string plantName = "Carrot";  // ชื่อของพืช
    public float growthTime = 5f;  // เวลาในการเติบโต (เป็นวินาที)
    private float currentGrowthTime = 0f;  // เวลาในการเติบโตที่ได้ผ่านไปแล้ว

    public Sprite seedSprite;  // รูปภาพตอนพืชยังเป็นเมล็ด
    public Sprite grownSprite;  // รูปภาพตอนพืชโตแล้ว

    private SpriteRenderer spriteRenderer;  // เพื่อจัดการกับการแสดงผล Sprite

    private bool isPlanted = false;  // เช็คว่าพืชได้ถูกปลูกแล้วหรือไม่
    private Vector3 plantPosition;  // ตำแหน่งที่เมล็ดถูกวางลง
    private int plantCount = 0; 

    public GameObject plantPrefab;  // Prefab สำหรับพืช

    public bool IsGrown => currentGrowthTime >= growthTime;  // เช็คว่าพืชเติบโตหรือยัง

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  // ค้นหาคอมโพเนนต์ SpriteRenderer
    }

    private void Update()
    {
        // กด P เพื่อปลูกพืช
        if (Input.GetKeyDown(KeyCode.P) && plantCount < 10)  
        {
            if (!isPlanted)
            {
                PlaceSeedOnGround();  // วางเมล็ดพืช
            }
        }

        // ถ้าพืชถูกปลูกแล้ว
        if (isPlanted && !IsGrown)  // ถ้าพืชยังไม่โต
        {
            currentGrowthTime += Time.deltaTime;  // เพิ่มเวลาการเติบโต
        }
        else if (IsGrown)  // ถ้าพืชโตแล้ว
        {
            spriteRenderer.sprite = grownSprite;  // เปลี่ยนภาพเป็นพืชที่โตแล้ว
        }
    }

    // ฟังก์ชั่นสำหรับการวางเมล็ดพืช
    private void PlaceSeedOnGround()
    {
        // ใช้ตำแหน่งเมาส์เพื่อวางเมล็ดพืช
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0;  // ให้ตำแหน่ง Z เป็น 0

        // สร้างพืชใหม่จาก Prefab ที่ตั้งค่า
        GameObject newPlant = Instantiate(plantPrefab, worldPosition, Quaternion.identity);

        // แสดงภาพเมล็ดพืช
        SpriteRenderer plantRenderer = newPlant.GetComponent<SpriteRenderer>();
        plantRenderer.sprite = seedSprite;

        // บันทึกข้อมูล
        isPlanted = true;  // บันทึกว่าพืชได้ถูกปลูกแล้ว
        plantPosition = worldPosition;  // บันทึกตำแหน่งของพืชที่ปลูก
        plantCount++;  

        Debug.Log("Seed planted at: " + plantPosition);
    }

    private void OnDrawGizmos()
    {
        if (IsGrown)
        {
            Gizmos.color = Color.green;  // เมื่อพืชเติบโตจะเปลี่ยนสี
        }
        else
        {
            Gizmos.color = Color.red;  // ถ้ายังไม่เติบโต
        }
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}