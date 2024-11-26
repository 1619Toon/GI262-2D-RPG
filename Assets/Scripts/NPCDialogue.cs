using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // เพิ่ม namespace สำหรับ TMP

public class NPCDialogue : MonoBehaviour
{
    public string[] dialogue; // ประโยคที่ NPC จะพูด
    private bool isPlayerNearby = false; // ตรวจสอบว่าผู้เล่นอยู่ใกล้หรือไม่
    public GameObject dialogueUI; // อ้างอิง UI พื้นหลัง
    public TextMeshProUGUI dialogueText; // อ้างอิงข้อความ TMP

    void Start()
    {
        // ซ่อน UI เริ่มต้น
        if (dialogueUI != null)
        {
            dialogueUI.SetActive(false);
        }
        else
        {
            Debug.LogWarning("dialogueUI is not assigned in the Inspector.");
        }

        if (dialogueText == null)
        {
            Debug.LogWarning("dialogueText is not assigned in the Inspector.");
        }

        // กำหนดข้อความเป็นภาษาอังกฤษ
        dialogue = new string[]
        {
            "Hello there! How can I assist you today?", // ประโยค 1
        };
    }

    void Update()
    {
        // ถ้าผู้เล่นใกล้ NPC และกด V
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.V)) 
        {
            StartDialogue();
        }
    }

    private void StartDialogue()
    {
        if (dialogueUI != null)
        {
            dialogueUI.SetActive(true); // แสดง UI
        }
        else
        {
            Debug.LogWarning("dialogueUI is missing or destroyed.");
            return; // ออกจากฟังก์ชั่นถ้าไม่มี UI
        }

        StartCoroutine(DisplayDialogue()); // เริ่มแสดงบทสนทนา
    }

    private IEnumerator DisplayDialogue()
    {
        if (dialogueText == null)
        {
            Debug.LogWarning("dialogueText is missing or destroyed.");
            yield break; // ถ้าไม่มี dialogueText ก็ให้หยุด Coroutine
        }

        foreach (string line in dialogue)
        {
            if (dialogueText != null) // ตรวจสอบว่า dialogueText ยังมีอยู่
            {
                dialogueText.text = line; // ตั้งค่าข้อความใน TMP
            }
            else
            {
                Debug.LogWarning("dialogueText is missing or destroyed.");
                yield break; // ออกจาก Coroutine ถ้าไม่ได้อ้างอิงถึง Text
            }

            yield return new WaitForSeconds(2); // แสดงข้อความ 2 วินาทีต่อบรรทัด
        }

        if (dialogueUI != null)
        {
            dialogueUI.SetActive(false); // ซ่อน UI เมื่อจบบทสนทนา
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            Debug.Log("Press V to talk");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            Debug.Log("You are too far to talk.");
            
            // ซ่อน UI เมื่อผู้เล่นออกจากระยะ
            if (dialogueUI != null)
            {
                dialogueUI.SetActive(false); // ซ่อนพื้นหลัง UI
            }

            // ซ่อนข้อความเมื่อผู้เล่นออกจากระยะ
            if (dialogueText != null)
            {
                dialogueText.text = ""; // ลบข้อความออกจาก UI
            }
        }
    }
}