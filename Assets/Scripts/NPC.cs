using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string npcName = "Chicken";  // ชื่อ NPC
    public string requiredItemName = "Egg";  // ชื่อไอเทมที่ NPC ต้องการ
    public InventoryManager inventoryManager;  // ตัวจัดการ Inventory

    // ฟังก์ชันในการรับไอเทม
    public void ReceiveItem(Item item)
    {
        if (item.data.itemName == requiredItemName)  // ตรวจสอบว่าเป็นไอเทมที่ต้องการหรือไม่
        {
            Debug.Log(npcName + " has received the " + item.data.itemName);
            inventoryManager.Add("backpack", item);  // เพิ่มไอเทมใน Inventory ของผู้เล่น (สามารถปรับใช้กับระบบของคุณได้)
            CompleteQuest();  // เคลียร์เควส
        }
        else
        {
            Debug.Log(npcName + " doesn't want this item.");
        }
    }

    // ฟังก์ชันเคลียร์เควส
    public void CompleteQuest()
    {
        Debug.Log("Quest completed!");
        // เพิ่มฟังก์ชันการให้รางวัลหรือการทำภารกิจเพิ่มเติมที่นี่
    }
}
