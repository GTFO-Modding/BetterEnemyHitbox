using AssetShards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BetterEnemyHitbox.Fixes;
internal class FixBirtherPrefab : PrefabFixer
{
    public override void Fix()
    {
        var bones = GetBonesOfPrefab("Birther/g_birther", "Assets/AssetPrefabs/CharacterBuilder/Enemies/Birther/Birther_CB.prefab");
        bones.ApplySphereColliderSetting("Neck", center: new(-0.0763f, 0.05f, 0.0f), radius: 0.09f);
        bones.ApplySphereColliderSetting("Chest", center: new(-0.17f, 0.06f, 0.0f), radius: 0.15f);
        bones.ApplySphereColliderSetting("Spine", center: new(-0.1039f, 0.12f, 0.0f), radius: 0.1426f);
        bones.ApplySphereColliderSetting("Hips", center: new(-0.06f, 0.05f, 0.0f), radius: 0.15f);
        bones.ApplyCapsuleColliderSetting("RightUpperLeg",
            center: new(-0.22f, -0.04f, 0.03f), radius: 0.06f, height: 0.44f, CapsuleDirection.X);
        bones.ApplyCapsuleColliderSetting("LeftUpperLeg",
           center: new(-0.22f, 0.04f, 0.03f), radius: 0.06f, height: 0.44f, CapsuleDirection.X);
    }
}
