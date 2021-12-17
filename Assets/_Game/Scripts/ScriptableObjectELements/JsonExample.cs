using UnityEditor;
using UnityEngine;



//[ExecuteAlways] always executes in editmode
public class JsonExample : MonoBehaviour
{
    [SerializeField] private ElementSO _element;
    private const string KEY = "my-test-key";
    
    
    [ContextMenu("Save")]
    public void SaveToDisk()
    {
        var jsonString = JsonUtility.ToJson(_element);
        Debug.Log(jsonString);
        
        
        PlayerPrefs.SetString(KEY,jsonString);//Super important, this is not safe, good for ingame options tho for volume
        PlayerPrefs.Save();
        
        //Application.persistentDataPath used to do actual files rather than player prefs.
        //This is the safest way for non-mobile, for mobile use cloud services.

        //Look at docmentation for filestream if you are intresetec in this.
    }
    [ContextMenu("Load")]
    public void LoadFromDisk()
    {
        var saveJSON = PlayerPrefs.GetString(KEY);
        JsonUtility.FromJsonOverwrite(saveJSON,_element);
        

        
    }
    
    [ContextMenu("Load And Save as Asset")]
    public void LoadFromDiskAndSaveAsset()
    {
        Debug.Log("Loading and saving as asset");
        
        var savedJSON = PlayerPrefs.GetString(KEY);
        
        //This si the same as the one below
        var newElement = ScriptableObject.CreateInstance<ElementSO>();//Create scripltableObject in runtime.
        JsonUtility.FromJsonOverwrite(savedJSON,newElement);


        //var element = JsonUtility.FromJson<ElementSO>(savedJSON);//better way to do it.
        
        var path = "Assets/_Game/ScriptsElements/ScriptableObjectELements/ElementfromDisk.asset";
        var asset = AssetDatabase.LoadAssetAtPath<ElementSO>(path);

        if (asset != null)
        {
            AssetDatabase.DeleteAsset(path);
        }
        
        AssetDatabase.CreateAsset(newElement,path);
        AssetDatabase.Refresh();

    }
}