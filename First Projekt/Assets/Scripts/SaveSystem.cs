
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
  public static void SavePlayer (Shooting shooting, PlayerDamage damage)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.kocha";
        FileStream stream = new FileStream (path, FileMode.Create);

        PlayerData data = new PlayerData(shooting,damage);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.kocha";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter ();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save File not found");
            return null;
        }
    }
}
