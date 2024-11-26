using System;
using UnityEngine;

namespace WorldTime
{
    public class MonsterSpawner : MonoBehaviour
    {
        [SerializeField] private WorldTime _worldTime; // เชื่อมต่อกับ WorldTime
        [SerializeField] private GameObject _monsterPrefab; // มอนสเตอร์ที่คุณจะสร้าง
        [SerializeField] private float _spawnChance = 0.1f; // ความน่าจะเป็นในการเกิดมอนสเตอร์
        [SerializeField] private int maxMonsters = 10; // จำนวนมอนสเตอร์สูงสุด

        private int currentMonsterCount = 0;

        private void OnEnable()
        {
            if (_worldTime != null)
            {
                _worldTime.WorldTimeChanged += OnWorldTimeChanged;
            }
            else
            {
                Debug.LogError("WorldTime not assigned!");
            }
        }

        private void OnDisable()
        {
            if (_worldTime != null)
            {
                _worldTime.WorldTimeChanged -= OnWorldTimeChanged;
            }
        }

        private void OnWorldTimeChanged(object sender, TimeSpan newTime)
        {
            if (newTime.Hours >= 0 && newTime.Hours < 5)
            {
                TrySpawnMonster();
            }
        }

        private void TrySpawnMonster()
        {
            if (UnityEngine.Random.value < _spawnChance)
            {
                SpawnMonsterAtRandomPosition();
            }
        }

        private void SpawnMonsterAtRandomPosition()
        {
            if (currentMonsterCount >= maxMonsters)
            {
                Debug.LogWarning("Maximum number of monsters reached.");
                return;
            }

            float x = UnityEngine.Random.Range(-9.25f, 5.74f); 
            float y = UnityEngine.Random.Range(-2.31f, 6.98f);
            Vector3 spawnPosition = new Vector3(x, y, 0);

            Instantiate(_monsterPrefab, spawnPosition, Quaternion.identity);
            currentMonsterCount++;
            Debug.Log("Monster spawned at: " + spawnPosition);
        }
    }
}