using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    public GameObject seedPrefab;  // Prefab เมล็ดพันธุ์
    public GameObject treePrefab;  // Prefab ต้นไม้
    public float growthTime = 5f;  // เวลาเติบโตจากเมล็ดพันธุ์เป็นต้นไม้

    private Dictionary<Vector2, GameObject> plantedSeeds = new Dictionary<Vector2, GameObject>();

    // ฟังก์ชันสำหรับการปลูก
    public void PlantSeed(Vector2 position)
    {
        if (!plantedSeeds.ContainsKey(position)) // ตรวจสอบว่าตำแหน่งนี้ยังไม่มีการปลูก
        {
            GameObject seed = Instantiate(seedPrefab, position, Quaternion.identity);
            plantedSeeds[position] = seed;

            // เริ่มการเติบโต
            StartCoroutine(GrowTree(position));
        }
    }

    private IEnumerator GrowTree(Vector2 position)
    {
        yield return new WaitForSeconds(growthTime); // รอให้เวลาผ่านไป

        // ลบเมล็ดพันธุ์และเปลี่ยนเป็นต้นไม้
        if (plantedSeeds.ContainsKey(position))
        {
            Destroy(plantedSeeds[position]); // ลบพรีแฟบเมล็ดพันธุ์
            GameObject tree = Instantiate(treePrefab, position, Quaternion.identity);
            plantedSeeds[position] = tree; // แทนที่ด้วยต้นไม้
        }
    }
}