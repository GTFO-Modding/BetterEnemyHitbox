using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BetterEnemyHitbox.Fixes;
internal class FixTankPrefab : PrefabFixer
{
    public override void Fix()
    {
        var bones = GetBonesOfPrefab("g_tank", "Assets/AssetPrefabs/CharacterBuilder/Enemies/Tank/Tank_CB.prefab");
        ApplyToBones(bones);

        var bossBones = GetBonesOfPrefab("g_tank", "Assets/AssetPrefabs/CharacterBuilder/Enemies/Tank_Boss/TankBoss_CB.prefab");
        ApplyToBones(bossBones);
    }

    private static void ApplyToBones(Transform[] bones)
    {
        bones.ApplySphereColliderSetting("Head", center: new(-0.04f, 0.08f, 0.0f), radius: 0.169871f);
        bones.ApplyCapsuleColliderSetting("Head",
            center: new(0.12f, -0.03f, 0.0f), radius: 0.0001f, height: 0.0001f, CapsuleDirection.Z);

        bones.ApplySphereColliderSetting("Chest", center: new(-0.1339f, -0.09f, 0.0f), radius: 0.2188f);
        bones.ApplyCapsuleColliderSetting("Chest",
            center: new(0.0f, -0.14f, 0.0f), radius: 0.23f, height: 0.51f, CapsuleDirection.Z);

        bones.ApplySphereColliderSetting("Spine", center: new(-0.1031f, -0.056f, 0.0f), radius: 0.1862f);
        bones.ApplyCapsuleColliderSetting("Spine",
            center: new(-0.01f, -0.14f, 0.0f), radius: 0.18f, height: 0.59f, CapsuleDirection.Z);
        bones.ApplySphereColliderSetting("Hips", center: new(-0.08f, -0.11f, 0.0f), radius: 0.23f);

        var leftMouth = bones.FindBone("LeftShoulder_MouthRig");
        leftMouth.gameObject.layer = LayerManager.LAYER_ENEMY_DAMAGABLE;
        var leftMouthCollider = leftMouth.gameObject.AddComponent<SphereCollider>();
        leftMouthCollider.center = new(-0.13f, 0.08f, -0.01f);
        leftMouthCollider.radius = 0.17f;

        var leftMouthDamageLimb = leftMouth.gameObject.AddComponent<Dam_EnemyDamageLimb_Custom>();
        leftMouthDamageLimb.m_type = eLimbDamageType.Armor;
        leftMouth.gameObject.AddComponent<ColliderMaterial>().m_FX_GroupOverride = FX_EffectSystem.FX_GroupName.Impact_EnemyBody;

        var rightMouth = bones.FindBone("RightShoulder_MouthRig");
        rightMouth.gameObject.layer = LayerManager.LAYER_ENEMY_DAMAGABLE;
        var rightMouthCollider = rightMouth.gameObject.AddComponent<SphereCollider>();
        rightMouthCollider.center = new(-0.1f, -0.06f, -0.03f);
        rightMouthCollider.radius = 0.17f;

        var rightMouthDamageLimb = rightMouth.gameObject.AddComponent<Dam_EnemyDamageLimb_Custom>();
        rightMouthDamageLimb.m_type = eLimbDamageType.Armor;
        rightMouth.gameObject.AddComponent<ColliderMaterial>().m_FX_GroupOverride = FX_EffectSystem.FX_GroupName.Impact_EnemyBody;
    }
}
