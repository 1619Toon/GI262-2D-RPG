using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Quest currentQuest;  // ตัวแปรเก็บเควสที่กำลังทำอยู่

    // ฟังก์ชั่นเริ่มเควส
    public void StartNewQuest()
    {
        // ตรวจสอบว่า currentQuest ไม่เป็นค่าว่าง
        if (currentQuest != null)
        {
            currentQuest.StartQuest(currentQuest);  // เรียกใช้ StartQuest และส่ง currentQuest ไป
            Debug.Log("Starting quest: " + currentQuest.questName);
        }
        else
        {
            Debug.LogError("No quest available to start!");
        }
    }
}