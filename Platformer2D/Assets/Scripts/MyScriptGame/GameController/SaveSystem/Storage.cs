using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Storage 
{
    private string _filePath;
    private BinaryFormatter _formatter;

    public Storage()
    {
        _filePath = Application.persistentDataPath + "/saves/GameSave.save";
        _formatter = new BinaryFormatter();
    }

    public object Load(object saveDataByDefault)
    {
        if (!File.Exists(_filePath))
        {
            if (saveDataByDefault != null)
            {
                Save(saveDataByDefault);
                return saveDataByDefault;
            }
        }

        var file = File.Open(_filePath, FileMode.Open);
        var savedData = _formatter.Deserialize(file);

        return savedData;
    }

    public void Save(object saveData)
    {
        var file = File.Create(_filePath);
        _formatter.Serialize(file, saveData);
        file.Close();
    }
}
