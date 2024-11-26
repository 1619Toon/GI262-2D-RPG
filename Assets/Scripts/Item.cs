using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Item : MonoBehaviour
{
    public ItemData data;  // ใช้ ItemData สำหรับข้อมูลของไอเทม เช่น ชื่อ, ไอคอน

    [HideInInspector]
    public Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();  // ค้นหาคอมโพเนนต์ Rigidbody2D
    }

    // ฟังก์ชั่นนี้จะถูกเรียกเมื่อไอเทมถูกเก็บไปใน Inventory
    public void AddToInventory()
    {
        // สามารถเพิ่มการจัดการเมื่อไอเทมถูกเก็บใน Inventory ได้ที่นี่
        Debug.Log($"Item {data.itemName} added to inventory");
    }
}