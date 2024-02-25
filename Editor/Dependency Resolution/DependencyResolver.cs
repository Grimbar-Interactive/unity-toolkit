using System.Linq;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEngine;
// ReSharper disable StringLiteralTypo

namespace GI.UnityToolkit.Variables.Editor.DependencyResolution
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class DependencyResolver
    {
        private static readonly (string, string)[] Dependencies =
        {
            #if !ODIN_INSPECTOR
            ("com.grimbarinteractive.unityattributes", "https://github.com/Grimbar-Interactive/unity-attributes.git")
            #endif
        };

        [InitializeOnLoadMethod]
        public static async void InstallDependencies()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var packageInfo = UnityEditor.PackageManager.PackageInfo.FindForAssembly(assembly);
            if (packageInfo == null)
            {
                Debug.Log("[DependencyResolver] Skipping dependency resolution: This package is not installed as a UPM package.");
                return;
            }

            var value = Client.List(false, true);
 
            while (!value.IsCompleted)
                await Task.Delay(100);

            foreach (var (packageName, url) in Dependencies)
            {
                if (value.Result.Any(item => item.name == packageName)) return;
                
                Debug.Log($"[DependencyResolver] The dependency \"{packageName}\" is not installed! Installing from \"{url}\"...");
                Client.Add(url);
            }
        }
    }
}