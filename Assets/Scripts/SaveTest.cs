using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTest : MonoBehaviour
{
    public SaveObject so;
    public SaveObject TextData;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Save Data
            SaveManager.Save(so);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            //Load Data
            so = SaveManager.Load();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            SaveManager.PrintJsonData(so);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            so = SaveManager.SaveJsonDataToText(TextData,so);
        }
    }
}
