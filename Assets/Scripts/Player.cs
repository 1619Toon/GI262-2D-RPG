using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryManager inventoryManager;
    private TileManager tileManager;
    public NPC npc;  // เพิ่มตัวแปรสำหรับอ้างอิงไปยัง NPC

    private void Start()
    {
        tileManager = GameManager.instance.tileManager;

        // ตรวจสอบว่า NPC ถูกกำหนดไว้แล้ว
        if (npc == null)
        {
            Debug.LogWarning("NPC ยังไม่ได้รับการกำหนดใน Player");
        }

        // ตรวจสอบว่า InventoryManager ถูกกำหนดไว้หรือไม่
        if (inventoryManager == null)
        {
            Debug.LogWarning("InventoryManager ยังไม่ได้รับการกำหนดใน Player");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (tileManager != null)
            {
                Vector3Int position = new Vector3Int((int)transform.position.x, (int)transform.position.y, 0);

                string tileName = tileManager.GetTileName(position);

                if (!string.IsNullOrWhiteSpace(tileName))
                {
                    if (tileName == "interactable" && inventoryManager.toolbar.selectedSlot.itemName == "Hoe")
                    {
                        tileManager.SetInteracted(position);
                    }
                }
            }
        }

        // เพิ่มฟังก์ชันส่งไข่ให้ NPC
        if (Input.GetKeyDown(KeyCode.E))  // กด E เพื่อตรวจสอบและส่งไข่ให้ NPC
        {
            if (npc != null)  // ตรวจสอบว่า NPC ถูกกำหนดแล้ว
            {
                // ตรวจสอบใน Inventory ว่ามี "Egg" หรือไม่
                var backpack = inventoryManager.GetInventoryByName("backpack");
                if (backpack != null)
                {
                    Item eggItem = backpack.GetItemByName("Egg");
                    if (eggItem != null)
                    {
                        npc.ReceiveItem(eggItem);  // ส่งไข่ให้ NPC
                        Debug.Log("Egg sent to NPC!");
                    }
                    else
                    {
                        Debug.Log("No Egg item found in inventory.");
                    }
                }
                else
                {
                    Debug.LogWarning("Backpack inventory is not found.");
                }
            }
            else
            {
                Debug.LogWarning("NPC ไม่ได้ถูกกำหนดใน Player");
            }
        }
    }

    public void DropItem(Item item)
    {
        Vector2 spawnLocation = transform.position;
        Vector2 spawnOffset = Random.insideUnitCircle * 1.25f;

        Item droppedItem = Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);
        droppedItem.rb2d.AddForce(spawnOffset * .2f, ForceMode2D.Impulse);
    }

    public void DropItem(Item item, int numToDrop)
    {
        for (int i = 0; i < numToDrop; i++)
        {
            DropItem(item);
        }
    }
}