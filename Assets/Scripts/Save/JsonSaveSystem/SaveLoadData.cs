using UnityEngine;

public class SaveLoadData : MonoBehaviour
{
    public CompletedEndings MenuEndings;
    public CompletedEndings SaveFile;
    public void SaveToJson()
    {
        string Data = JsonUtility.ToJson(MenuEndings);
        string FilePath = Application.persistentDataPath + "/SaveFile.json";
        Debug.Log(FilePath);
        System.IO.File.WriteAllText(FilePath, Data);
        Debug.Log("Data Saved");
    }
    public void LoadFromJson()
    {
        try
        {
            string FilePath = Application.persistentDataPath + "/SaveFile.json";
            string Data = System.IO.File.ReadAllText(FilePath);
            JsonUtility.FromJsonOverwrite(Data, MenuEndings);

            Debug.Log("Data was Loaded");
        }
        catch
        {

            Debug.LogWarning("Save Not Found");
        }
        
    }
    public void DeleteSave()
    {
        string FilePath = Application.persistentDataPath + "/SaveFile.json";
        System.IO.File.Delete(FilePath);

        for (int i = 0; i < MenuEndings.endings.Count; i++)
        {
            MenuEndings.endings[i].isCompleted = false;
            SaveFile.endings[i].isCompleted = false;
        }
    }
}
