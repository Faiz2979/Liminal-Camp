using UnityEditor;
using UnityEngine;
using System.IO;

public class InteractableCreator
{
    private const string TEMPLATE =
@"using UnityEngine;

public class #SCRIPTNAME# : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        // TODO: Implement interaction logic
    }
}";

    [MenuItem("Assets/Create/Custom/EventTrigger/Interactable", false, 80)]
    public static void CreateInteractable()
    {
        string path = GetSelectedPathOrFallback();
        string fileName = "NewInteractable.cs";
        string fullPath = Path.Combine(path, fileName);

        fullPath = AssetDatabase.GenerateUniqueAssetPath(fullPath);

        string className = Path.GetFileNameWithoutExtension(fullPath);
        string content = TEMPLATE.Replace("#SCRIPTNAME#", className);

        File.WriteAllText(fullPath, content);

        AssetDatabase.Refresh();

        Object asset = AssetDatabase.LoadAssetAtPath<Object>(fullPath);
        Selection.activeObject = asset;
    }

    private static string GetSelectedPathOrFallback()
    {
        string path = "Assets";

        if (Selection.activeObject != null)
        {
            path = AssetDatabase.GetAssetPath(Selection.activeObject);
            if (File.Exists(path))
                path = Path.GetDirectoryName(path);
        }

        return path;
    }
}
