using System.Collections;
using UnityEngine;
using LitJson;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

[System.Serializable]
public class ItemDatabase : MonoBehaviour
{
    private List<Item> database = new List<Item>();
    private JsonData itemData;


    void Start()
    {
        SetDBPath();
        ConstructItemDatabase();

    }

    public void SetDBPath()
    {
        string DatabaseName = "Items.json";

#if UNITY_EDITOR
        var dbPath = string.Format(@"Assets/StreamingAssets/{0}", DatabaseName);
#else
        // check if file exists in Application.persistentDataPath
        var filepath = string.Format("{0}/{1}", Application.persistentDataPath, DatabaseName);

        if (!File.Exists(filepath))
        {
            Debug.Log("Database not in Persistent path");
            // if it doesn't ->
            // open StreamingAssets directory and load the db ->

#if UNITY_ANDROID
                                    var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
                                    while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
                                    // then save to Application.persistentDataPath
                                    File.WriteAllBytes(filepath, loadDb.bytes);
#elif UNITY_IOS
                                    var loadDb = Application.dataPath + "/Raw/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                                    // then save to Application.persistentDataPath
                                    File.Copy(loadDb, filepath);
#elif UNITY_WP8
                                    var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                                    // then save to Application.persistentDataPath
                                    File.Copy(loadDb, filepath);
         
#elif UNITY_WINRT
                                    var loadDb = Application.dataPath + "/StreamingAssets/" + DatabaseName;  // this is the path to your StreamingAssets in iOS
                                    // then save to Application.persistentDataPath
                                    File.Copy(loadDb, filepath);
#endif

            Debug.Log("Database written");
        }

        var dbPath = filepath;
#endif
        itemData = JsonMapper.ToObject(File.ReadAllText(dbPath));

    }

    public Item FetchItemByID(int id)
    {
        for (int i = 0; i < database.Count; i++)
            if (database[i].ID == id)
                return database[i];
        return null;
    }


    void ConstructItemDatabase()
    {
        for (int i = 0; i < itemData.Count; i++)
        {
            database.Add(new Item((int)itemData[i]["id"], itemData[i]["name"].ToString(), (int)itemData[i]["value"], itemData[i]["description"].ToString(),
                (bool)itemData[i]["stackable"], itemData[i]["slug"].ToString()));
        }
    }
}
[System.Serializable]
public class Item
{

    public int ID { get; set; }
    public string Name { get; set; }
    public int Value { get; set; }
    public string Description { get; set; }
    public bool Stackable { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }

    public Item(int id, string name, int value, string description, bool stackable, string slug)
    {
        this.ID = id;
        this.Name = name;
        this.Value = value;
        this.Description = description;
        this.Stackable = stackable;
        this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>("Sprites/Items/" + slug);
    }

    public Item()
    {
        this.ID = -1;
    }
}
