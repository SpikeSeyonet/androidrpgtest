using System.Collections;
using UnityEngine;
using LitJson;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

/*public class FilePath 
{
    
    public static void SetDBPath()
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

     
    }
}
*/