using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartup : MonoBehaviour
{
    public InputField nameField;
    private string playername;
  
    public void OnSubmit()
    {
        playername = nameField.text;
        Debug.Log(playername);
      
    }
}