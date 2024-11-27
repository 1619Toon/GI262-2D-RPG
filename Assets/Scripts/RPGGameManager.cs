using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class RPGGameManager : MonoBehaviour
{
    public Button saveButton;  // ปุ่มสำหรับเซฟเกม
    public GameObject player;  // ตัวละครผู้เล่น
    public int playerHealth;   // ค่าพลังชีวิตของผู้เล่น
    public int playerExperience;  // ค่าประสบการณ์ของผู้เล่น
    public string currentQuest;   // เควสต์ที่ผู้เล่นกำลังทำ
    public Vector3 playerPosition; // ตำแหน่งของผู้เล่น

    void Start()
    {
        saveButton.onClick.AddListener(SaveGame);  // เพิ่มฟังก์ชันเซฟเกมเมื่อคลิกปุ่ม
    }

    void Update()
    {
        // อัปเดตข้อมูลต่างๆ เช่น ตำแหน่งของตัวละคร
        playerPosition = player.transform.position;
    }

    // ฟังก์ชันในการเซฟเกม
    void SaveGame()
    {
        // บันทึกข้อมูลที่จำเป็น (ตัวอย่าง)
        PlayerPrefs.SetFloat("PlayerPosX", playerPosition.x);
        PlayerPrefs.SetFloat("PlayerPosY", playerPosition.y);
        PlayerPrefs.SetFloat("PlayerPosZ", playerPosition.z);
        PlayerPrefs.SetInt("PlayerHealth", playerHealth);
        PlayerPrefs.SetInt("PlayerExperience", playerExperience);
        PlayerPrefs.SetString("CurrentQuest", currentQuest);

        // บันทึกการเซฟไปยังไฟล์
        string saveData = playerPosition.x + "," + playerPosition.y + "," + playerPosition.z + "\n" +
                          playerHealth + "\n" +
                          playerExperience + "\n" +
                          currentQuest;

        string path = Application.persistentDataPath + "/savegame_rpg.txt";
        File.WriteAllText(path, saveData);

        Debug.Log("Game Saved at: " + path);
    }

    // ฟังก์ชันโหลดข้อมูล (สามารถใช้เพื่อโหลดเกมในภายหลัง)
    void LoadGame()
    {
        string path = Application.persistentDataPath + "/savegame_rpg.txt";
        if (File.Exists(path))
        {
            string[] saveData = File.ReadAllLines(path);
            string[] positionData = saveData[0].Split(',');

            playerPosition = new Vector3(float.Parse(positionData[0]), float.Parse(positionData[1]), float.Parse(positionData[2]));
            playerHealth = int.Parse(saveData[1]);
            playerExperience = int.Parse(saveData[2]);
            currentQuest = saveData[3];

            player.transform.position = playerPosition;

            Debug.Log("Game Loaded");
        }
        else
        {
            Debug.Log("No Save File Found");
        }
    }
}