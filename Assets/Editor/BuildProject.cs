using UnityEngine;
using UnityEditor;

public class BuildProject : MonoBehaviour
{
    public static string version = System.Environment.GetEnvironmentVariable("projectVersion");
    public static string gameName = System.Environment.GetEnvironmentVariable("gameName");

    public static void BuildWindows64()
    {
        string buildPath = ".\\Builds\\" + version + "\\" + gameName + ".exe";
        BuildPipeline.BuildPlayer(
            new string[] 
            {
                "Assets\\Scenes\\GamePlay\\SampleScene.unity"
                //lista de escenas separadas por ","
            },
            buildPath,
            BuildTarget.StandaloneWindows64,
            BuildOptions.None
        );
    }
}