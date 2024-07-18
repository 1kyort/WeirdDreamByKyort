using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SaveCheckMenu : MonoBehaviour
{
    [SerializeField] private CompletedEndings MenuSave;
    [SerializeField] private CompletedEndings Save;

    [SerializeField] private List<Transform> Holders;
    [SerializeField] private GameObject PopUpEnding;
    [SerializeField] private Transform Parrent;
    [SerializeField] private SaveLoadData SaveLoadSystem;

    private void Start()
    {
        SaveLoadSystem.LoadFromJson();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        for (int i = 0; i < MenuSave.endings.Count; i++)
        {
            if (MenuSave.endings[i].isCompleted)
            {
                Holders[i].gameObject.GetComponent<Image>().sprite = MenuSave.endings[i].Sprite;
                Holders[i].gameObject.GetComponent<Card>().Description = MenuSave.endings[i].Name;
            }
        }

        for (int i = 0; i < Save.endings.Count; i++)
        {
            if (Save.endings[i].isCompleted == true && MenuSave.endings[i].isCompleted == false)
            {
                MenuSave.endings[i].isCompleted = true;
                GameObject obj = Instantiate(PopUpEnding);
                obj.SetActive(true);
                obj.transform.SetParent(Parrent);

                obj.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Save.endings[i].Sprite;
                Vector3 pos = Holders[i].position;
                pos.z -= 0.01f;
                obj.transform.position = pos;
                obj.gameObject.GetComponent<PopUpEnding>().index = i;
                obj.gameObject.GetComponent<PopUpEnding>().Description = Save.endings[i].Name;
                
            }
        }
    }
}
