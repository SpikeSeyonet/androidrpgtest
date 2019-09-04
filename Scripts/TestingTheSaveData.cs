using UnityEngine;

public class TestingTheSaveData : MonoBehaviour
{
    private void Awake()
    {
        // Load the vars and print them in the conosle  
        LoadVarsAndDebug();
        // Change them and save them.
        TestChageTheVars(5);
        LoadVarsAndDebug();
        TestChageTheVars(10);
    }

    void LoadVarsAndDebug()
    {
        SaveData.Load();
        Debug.Log("tacos " + SaveData.saveVars.taco);
        Debug.Log("drink " + SaveData.saveVars.drink);
    }

    void TestChageTheVars(int value)
    {
        // This will change taco by value
        SaveData.saveVars.taco += value;
        SaveData.saveVars.drink += value / 10;
        // This will save the class data.
        SaveData.Save();
    }
}
