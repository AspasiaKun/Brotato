
using UnityEngine;

public sealed class Utils
{
    private static readonly Utils instance = new Utils();
    private Utils() 
    {

    }
    public static Utils Instance{
        get
        {
            return instance;
        }
    }
    public GameObject findGameObject(string goName) {
        GameObject go = GameObject.Find(goName);
        if (go == null) {
            Debug.LogError($"GameObject '{goName}' not found!");
            return null;
        }
        return go;
    }
}
