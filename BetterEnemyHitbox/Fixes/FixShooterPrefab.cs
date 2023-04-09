using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BetterEnemyHitbox.Fixes;
internal class FixShooterPrefab : PrefabFixer
{
    public override void Fix()
    {
        var normal = GetPrefab("Assets/AssetPrefabs/CharacterBuilder/Enemies/Shooter/Shooter_CB.prefab");
        var rapid = GetPrefab("Assets/AssetPrefabs/CharacterBuilder/Enemies/ShooterRapidFire/ShooterRapidFire_CB.prefab");
        ApplyToBones(normal);
        ApplyToBones(rapid);
    }

    private static void ApplyToBones(GameObject prefab)
    {
        var chest = prefab.transform.Find("root/Hips/Spine/Chest");
        chest.ApplySphereColliderSetting(center: new(-0.08f, 0.02f, 0.0f), radius: 0.1576f);
        var collider = chest.gameObject.AddComponent<CapsuleCollider>();
        collider.center = new(-0.015f, -0.04f, 0.0f);
        collider.radius = 0.1f;
        collider.height = 0.31f;
        collider.direction = (int)CapsuleDirection.Z;

        var hips = prefab.transform.Find("root/Hips");
        hips.ApplySphereColliderSetting(center: new(-0.09f, 0.02f, 0.0f), radius: 0.172f);
    }
}
