using MelonLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TreeSpace;
using UnhollowerRuntimeLib;
using UnityEngine;

[assembly: MelonInfo(typeof(Mod), "TreeSpace", "1.0", "Blaze#066", "Mod Hub | discord.gg/gawbfZXYYA")]
[assembly: MelonGame("VRChat", "VRChat")]

namespace TreeSpace
{
    public class Mod : MelonMod
    {
        public override void OnApplicationStart()
        {
            AssetBundle();
            MelonLogger.Msg("Tree Gang!");
        }

        public override void OnGUI()
        {
            Rect rect = new Rect(Screen.width - 250, Screen.height - 550, 200, 300);
            GUI.DrawTexture(rect, TreeSprite.texture);
        }

        private static AssetBundle TreeAssetBundle;
        public static Sprite TreeSprite;

        public static void AssetBundle()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("TreeSpace.treespace")) //String is MainNamespace.assetbundlename
            using (var tempStream = new MemoryStream((int)stream.Length))
            {
                stream.CopyTo(tempStream);

                TreeAssetBundle = UnityEngine.AssetBundle.LoadFromMemory_Internal(tempStream.ToArray(), 0);
                TreeAssetBundle.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            }

            TreeSprite = TreeAssetBundle.LoadAsset_Internal("Assets/Tree.png", Il2CppType.Of<Sprite>()).Cast<Sprite>(); //String is the location/name of the asset in the assetbundle
            TreeSprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
        }
    }
}
