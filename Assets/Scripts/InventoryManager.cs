using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Dictionary<string, Inventory> inventoryByName = new Dictionary<string, Inventory>();

    [Header("Backpack")]
    public Inventory backpack;
    public int backpackSlotsCount = 27;

    [Header("Toolbar")]
    public Inventory toolbar;
    public int toolbarSlotsCount = 9;

    private void Awake()
    {
        backpack = new Inventory(backpackSlotsCount);
        toolbar = new Inventory(toolbarSlotsCount);

        inventoryByName.Add("backpack", backpack);
        inventoryByName.Add("toolbar", toolbar);
    }

    public Inventory GetInventoryByName(string name)
    {
        if (inventoryByName.ContainsKey(name))
        {
            return inventoryByName[name];
        }

        return null;
    }

    public void Add(string inventoryName, Item item)
    {
        if (inventoryByName != null)
        {
            if (inventoryByName.ContainsKey(inventoryName))
            {
                inventoryByName[inventoryName].Add(item);
            }
        }
    }

    // ส่งไอเทมไปเควสต์
    public void SendItemToQuest(string itemName)
    {
        if (backpack.HasItem(itemName))  // ตรวจสอบว่าใน Backpack มีไอเทมนี้หรือไม่
        {
            // ค้นหาตำแหน่งของไอเทมใน Backpack
            int itemIndex = backpack.slots.FindIndex(slot => slot.itemName == itemName && slot.count > 0);

            if (itemIndex != -1)  // ถ้าพบไอเทม
            {
                // ทำการส่งไอเทมไปให้ NPC
                Debug.Log("Item sent to quest: " + itemName);

                // ลบไอเทมออกจาก Backpack
                backpack.Remove(itemIndex, 1);  // ส่งตำแหน่ง (itemIndex) และจำนวน (1) เพื่อกำจัดไอเทม
            }
            else
            {
                Debug.Log("Item not found in backpack.");
            }
        }
        else
        {
            Debug.Log("Item not found in backpack.");
        }
    }
}

