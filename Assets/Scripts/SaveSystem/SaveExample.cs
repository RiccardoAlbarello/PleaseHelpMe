using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveExample : MonoBehaviour
{
    public bool enigma1 = false;
    public bool enigma2 = false;
    public bool enigma3 = false;
    public bool enigma4 = false;

    public int numberOfEnigmi;
    private void Start()
    {
        LoadGame();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
            SaveGame();
        if (Input.GetKeyDown(KeyCode.L))
            LoadGame();
    }

    public void SaveGame()
    {
        SaveData saveData = new SaveData();
        saveData.positions = new SaveData.Position[1]; //dont do like that, im just showing example here
        saveData.positions[0] = new SaveData.Position();
        saveData.positions[0].x = transform.position.x;
        saveData.positions[0].y = transform.position.y;
        saveData.positions[0].z = transform.position.z;
        SaveManager.SaveGameState(saveData);
        Debug.Log("Game Saved!");

        PlayerPrefs.SetInt("numberOfEnigmi", numberOfEnigmi);
        
    }
    public void SaveBool()
    {
        PlayerPrefs.SetInt("enigma1", (enigma1 ? 1 : 0));
        PlayerPrefs.SetInt("enigma2", (enigma2 ? 1 : 0));
        PlayerPrefs.SetInt("enigma3", (enigma3 ? 1 : 0));
        PlayerPrefs.SetInt("enigma4", (enigma4 ? 1 : 0));//salvare bool
    }

    private void LoadGame()
    {
        SaveData saveData = SaveManager.LoadGameState();
        if (saveData != null)
        {
            transform.position = new Vector3(saveData.positions[0].x, saveData.positions[0].y, saveData.positions[0].z);
            Debug.Log("Game Loaded!");
            enigma1 = (PlayerPrefs.GetInt("enigma1") != 0); //caricare bool
            enigma2 = (PlayerPrefs.GetInt("enigma2") != 0); //caricare bool
            enigma3 = (PlayerPrefs.GetInt("enigma3") != 0); //caricare bool
            enigma4 = (PlayerPrefs.GetInt("enigma4") != 0); //caricare bool

            PlayerPrefs.GetInt("numberOfEnigmi");
        }
    }
    public void Save()
    {
        PlayerPrefs.SetInt("Name", (enigma1 ? 1 : 0));
    }
}
