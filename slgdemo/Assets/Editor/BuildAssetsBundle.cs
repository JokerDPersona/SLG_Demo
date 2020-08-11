using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class BuildAssetsBundle
{

    [MenuItem("AssetBundleTools/BuildAllAssetBundles")]
    public static void BuildAllAB(){
        string strABOutPath = string.Empty;
        strABOutPath = Application.streamingAssetsPath;
        if (!Directory.Exists(strABOutPath))
        {
            Directory.CreateDirectory(strABOutPath);
        }
        BuildPipeline.BuildAssetBundles(strABOutPath, BuildAssetBundleOptions.None,BuildTarget.StandaloneWindows64);
    }
}
