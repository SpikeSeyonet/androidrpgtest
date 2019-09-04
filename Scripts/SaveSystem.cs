using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

 [System.Serializable]
 public class SaveData
 {
 // Creates a public reference that can be used to set the data
 public static SaveVariables saveVars = new SaveVariables();
 // Get the path to the save file
 public static string GetPath()
 {
     return Application.persistentDataPath + saveVars.directory;
 }
 // Return the filename of the save file.
 public static string GetFileName()
 {
     return saveVars.playerName + saveVars.extention;
 }

 // Call this once before anything else is done.
 // This will create the new file and make sure the directory is correct. 
 public static void RunThisOnceToBuildTheInitailFile()
 {
     var path = GetPath();
     var fileName = GetFileName();
     var fullpath = (Path.Combine(path, fileName));
     if (!Directory.Exists(path))
     {
         Directory.CreateDirectory(path);
     }
     if (File.Exists(fullpath))
     {
         Debug.Log("File named " + fullpath + " already exists");
         return;
     }
     else Debug.Log(fullpath);
     // If the player has never played before write the defaults to the save data and 
     //     then save the state so the game will start fresh
     Save();
 }

 // Save the data.
 public static void Save()
 {
     var path = GetPath();
     var fileName = GetFileName();
     var fullpath = (Path.Combine(path, fileName));
     BinaryFormatter bf = new BinaryFormatter();
     // Save the written variabes to the disk.
     using (var file = File.Create(fullpath))
     {
         // Take the SaveVariables class and write the variables to disk.
         bf.Serialize(file, saveVars);
     }
     Debug.Log("Data Saved in Directory" + fullpath);

 }

 // Load the data.
 public static void Load()
 {
     var path = GetPath();
     var fileName = GetFileName();
     var fullpath = (Path.Combine(path, fileName));
     // Load the file and write the data to the class vars.
     if (File.Exists(fullpath))
     {
         FileStream inStr = new FileStream(fullpath, FileMode.Open);
         BinaryFormatter bf = new BinaryFormatter();
         // Load the file as SaveData class
         var data = bf.Deserialize(inStr) as SaveVariables;
         // write the saved data to the saveVars class reference 
         saveVars = data;
         Debug.Log("Data Loaded From Directory" + fullpath);
         inStr.Close();
     }
     else
         Debug.Log(fullpath + "Doesnt Exist To Load");
 }
 
    // To delete the file.
 public static void Delete()
 {
     var path = GetPath();
     var fileName = GetFileName();
     var fullpath = (Path.Combine(path, fileName));
     // Delete the file from the disk.
     if (File.Exists(fullpath))
     {
         File.Delete(fullpath);
         Debug.Log("File Deleted " + fullpath);
         // Create a new class to reference that will load the defualts back
         saveVars = new SaveVariables();
     }
     else Debug.Log("No File To Delete");
 }

 [System.Serializable]
     public class SaveVariables
     {
        public readonly string directory = "/save/";
        public readonly string playerName = "default";
        public readonly string extention = ".bsd";
        // Put any vaiables you want to save in here.  This will be saved and 
        // loaded every time Save() or Load() is ran. 
        // For instance 
        public int taco = 17;
        public float drink = .25f;
        
     }
 }