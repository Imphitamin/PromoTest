#if UNITY_EDITOR
using System.IO;
using UnityEditor;

namespace PromoTest.Project.Editor
{
    public class CreateAssetBundles
    {
        private const string AssetBundlesDirectory = "Assets/AssetBundles";
    
        [MenuItem("Assets/Test Build AssetBundles for Windows")]
        private static void BuildAllAssetBundles()
        {
            if (!Directory.Exists(AssetBundlesDirectory))
            {
                Directory.CreateDirectory(AssetBundlesDirectory);
            }
        
            BuildPipeline.BuildAssetBundles(
                AssetBundlesDirectory,
                BuildAssetBundleOptions.StrictMode,
                BuildTarget.StandaloneWindows
            );
        }
    }
}
#endif