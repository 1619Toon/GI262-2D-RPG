using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public string questName;  // ชื่อเควส
    public string description; // คำอธิบายเควส
    public bool isComplete; // เช็คว่าเควสเสร็จสมบูรณ์หรือยัง
    public Item requiredItem; // ไอเทมที่ต้องใช้ในเควส (ในกรณีนี้อาจเป็นไอเทมไข่)

    private Quest currentQuest;  // ตัวแปรเก็บเควสปัจจุบันที่กำลังทำอยู่

    // ฟังก์ชั่นสำหรับเริ่มเควส
    public void StartQuest(Quest quest)
    {
        currentQuest = quest;  // กำหนดเควสปัจจุบัน
        isComplete = false;
        Debug.Log("Quest Started: " + questName);
    }

    // ฟังก์ชั่นสำหรับตรวจสอบการทำเควส
    public void CheckQuestCompletion(Item item)
    {
        // ถ้าไอเทมที่ได้รับตรงกับที่ต้องการ
        if (item == requiredItem)
        {
            isComplete = true;
            Debug.Log("Quest Completed: " + questName);
        }
    }

    // ฟังก์ชั่นสำหรับส่งไอเทมให้ NPC (ในกรณีนี้คือไก่)
    public void GiveItemToNPC(Item item, GameObject npc)
    {
        if (item == requiredItem && !isComplete)
        {
            CheckQuestCompletion(item);
            if (isComplete)
            {
                Debug.Log("You have successfully completed the quest by giving " + item.data.itemName + " to the chicken!");
                // เพิ่มการให้รางวัลหรือทำบางอย่างเมื่อเควสเสร็จ
                // npc.GetComponent<NPC>().GiveReward(); // ให้รางวัลกับผู้เล่น
            }
        }
    }

    // ฟังก์ชั่น OnTriggerEnter2D ให้ไก่รับไอเทมจากผู้เล่น
    void OnTriggerEnter2D(Collider2D other)
    {
        // ตรวจสอบว่าผู้เล่นเข้ามาใกล้ NPC หรือไม่
        if (other.CompareTag("NPC"))  // ตรวจสอบว่าเป็นไก่ (NPC)
        {
            // เช็คว่าเควสนี้ต้องการไอเทม EggItem หรือไม่
            if (currentQuest != null && currentQuest.requiredItem != null)
            {
                currentQuest.GiveItemToNPC(currentQuest.requiredItem, this.gameObject);
            }
        }
    }
}