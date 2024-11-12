using System;
using System.Collections;
using UnityEngine;

namespace WorldTime
{
    public class FlowerSpawner : MonoBehaviour
    {
        [SerializeField] private WorldTime _worldTime;
        [SerializeField] private GameObject _flowerPrefab; // ดอกไม้ที่คุณจะสร้าง
        [SerializeField] private float _spawnChance = 0.1f; // ความน่าจะเป็นในการเกิดดอกไม้ในตอนเช้า

        private void Start()
        {
            // เริ่มต้นการสุ่มและตรวจสอบเวลาที่เกิดดอกไม้
            StartCoroutine(SpawnFlowersDuringMorning());
        }

        private IEnumerator SpawnFlowersDuringMorning()
        {
            while (true)
            {
                // เช็คเวลาในตอนเช้า (เช้าอาจจะหมายถึงเวลา 06:00 - 12:00 เป็นต้น)
                TimeSpan currentTime = _worldTime.GetCurrentTime();
                if (currentTime.Hours >= 6 && currentTime.Hours < 12) // เวลาช่วงเช้า
                {
                    if (UnityEngine.Random.value < _spawnChance)
                    {
                        SpawnFlowerAtRandomTime();
                    }
                }

                yield return new WaitForSeconds(1f); // เช็คทุกๆ 1 วินาที
            }
        }

        private void SpawnFlowerAtRandomTime()
        {
            // สุ่มเวลาการเกิดดอกไม้ภายในช่วงเวลาที่ต้องการ
            int randomHour = UnityEngine.Random.Range(6, 12); // สุ่มชั่วโมงในช่วง 6 ถึง 12
            int randomMinute = UnityEngine.Random.Range(0, 60); // สุ่มนาที

            TimeSpan randomTime = new TimeSpan(randomHour, randomMinute, 0);

            // สร้างดอกไม้ตามเวลาที่สุ่ม
            Debug.Log("Flower will spawn at " + randomTime);

            // สุ่มตำแหน่งในขอบเขตที่ต้องการ
           float x = UnityEngine.Random.Range(-9.25f, 5.74f); 
           float y = UnityEngine.Random.Range(-2.31f, 6.98f); 
           Vector3 spawnPosition = new Vector3(x, y, 0);

            // สร้างดอกไม้
            Instantiate(_flowerPrefab, spawnPosition, Quaternion.identity);
        }
    }
}