using UnityEditor;
using UnityEngine;


namespace BWolf.Patterns.Singleton.Editor
{
    public static class SingletonProfileMenuItem
    {
        [MenuItem("Assets/Set As Active Profile", false, 100)]
        private static void SetAsActiveProfile(MenuCommand command)
        {
            var asset = Selection.activeObject as SingletonProfile;
            if (asset == null)
            {
                Debug.LogError("Selected asset is not a SingletonProfile.");
                return;
            }

            var assetPath = AssetDatabase.GetAssetPath(asset);
            var resourcesFolderIndex = assetPath.IndexOf("/Resources/");
            if (resourcesFolderIndex == -1)
            {
                Debug.LogError("Selected asset is not located in a Resources folder.");
                return;
            }
            
            SingletonSettings.SetActiveProfile(asset);
            EditorUtility.SetDirty(asset);
            AssetDatabase.SaveAssets();
        }

        [MenuItem("Assets/Set As Active Profile", true)]
        private static bool ValidateSetAsActiveProfile()
        {
            var asset = Selection.activeObject as SingletonProfile;
            if (asset == null)
                return (false);
            
            var assetPath = AssetDatabase.GetAssetPath(asset);
            var resourcesFolderIndex = assetPath.IndexOf("/Resources/");
            if (resourcesFolderIndex == -1)
                return (false);
            
            return (true);
        }
    }
}
