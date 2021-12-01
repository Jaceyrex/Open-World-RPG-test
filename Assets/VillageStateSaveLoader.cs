using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class VillageStateSaveLoader : MonoBehaviour
{
    public void SaveData(GameObject townToSave)
    {
        BinaryFormatter bf = new BinaryFormatter();
        using FileStream file = File.Open(Application.persistentDataPath + Path.DirectorySeparatorChar + "playerInfo.dat", FileMode.OpenOrCreate); //Opens filestream within a persistent location, separates it by a platform specific character and gives it a name

        LocationData data = new LocationData();

        //Bellow segment gives relevant data to save to the file
        //data.exitPoint = new Vector3(
        //    townToSave.transform.Find("Exit Point").gameObject.transform.position.x,
        //    townToSave.transform.Find("Exit Point").gameObject.transform.position.y,
        //    townToSave.transform.Find("Exit Point").gameObject.transform.position.z);

        data.x = townToSave.transform.Find("Exit Point").gameObject.transform.position.x;
        data.y = townToSave.transform.Find("Exit Point").gameObject.transform.position.y;
        data.z = townToSave.transform.Find("Exit Point").gameObject.transform.position.z;

        bf.Serialize(file, data);
        file.Close();

        Debug.LogError($"Not actually an error but the data has been saved to {file.ToString()}");
    }

    public Vector3 LoadData()
    {
        if (File.Exists(Application.persistentDataPath + Path .DirectorySeparatorChar + "playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(
                Application.persistentDataPath +
                Path.DirectorySeparatorChar +
                "playerInfo.dat", FileMode.Open);
            LocationData data = (LocationData)bf.Deserialize(file);

            //Closes then deletes the data afterwards to ensure no issues with entering another town or starting again
            file.Close();
            File.Delete(
                Application.persistentDataPath +
                Path.DirectorySeparatorChar +
                "playerInfo.dat");


            return new Vector3(data.x, data.y, data.z);
        }
        return new Vector3(0,0,0);
    }

    public bool Exists()
    {
        if (File.Exists(Application.persistentDataPath + Path.DirectorySeparatorChar + "playerInfo.dat"))
        {
            //Location data file exists
            Debug.Log("Location data file DOES exist");
            return true;
        }
        else
        {
            //Location data file does not exist
            Debug.Log("Location data file does NOT exist");
            return false;
        }
    }
}
[Serializable]
class LocationData
{
    //public Vector3 exitPoint;
    public float x;
    public float y;
    public float z;
    //public bool leavingTown;
}
