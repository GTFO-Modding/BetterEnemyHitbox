using AssetShards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BetterEnemyHitbox.Fixes;

internal enum CapsuleDirection
{
    X = 0,
    Y = 1,
    Z = 2
}

internal abstract class PrefabFixer
{
    public abstract void Fix();

    protected static Transform[] GetBonesOfPrefab(string rootRendererPath, string prefab)
    {
        var prefabGO = GetPrefab(prefab);
        if (prefabGO == null)
        {
            return Array.Empty<Transform>();
        }

        var rendererObj = prefabGO.transform.Find(rootRendererPath);
        if (rendererObj == null)
        {
            return Array.Empty<Transform>();
        }

        var skinnedMesh = prefabGO.GetComponentInChildren<SkinnedMeshRenderer>();
        if (skinnedMesh == null)
        {
            return Array.Empty<Transform>();
        }

        Logger.DebugOnly($"Prefab: {prefab}");
        foreach (var bone in skinnedMesh.bones)
        {
            Logger.DebugOnly($" - {bone.name}");
        }

        return skinnedMesh.bones;
    }

    protected static GameObject GetPrefab(string prefab)
    {
        return AssetShardManager.GetLoadedAsset<GameObject>(prefab, false);
    }

    
}

internal static class BoneExtension
{
    public static void ApplySphereColliderSetting(this Transform bone, Vector3 center, float radius)
    {
        var collider = bone.GetComponent<SphereCollider>();
        if (collider == null)
        {
            Logger.Error($"Sphere Collider is missing!!! \"{bone.name}\"");
            return;
        }

        collider.center = center;
        collider.radius = radius;
    }

    public static void ApplySphereColliderSetting(this Transform[] bones, string boneName, Vector3 center, float radius)
    {
        var bone = bones.FindBone(boneName);
        if (bone == null)
        {
            Logger.Error($"Bone is missing!!! \"{boneName}\"");
            return;
        }

        bone.ApplySphereColliderSetting(center, radius);
    }

    public static void ApplyCapsuleColliderSetting(this Transform bone, Vector3 center, float radius, float height, CapsuleDirection dir)
    {
        var collider = bone.GetComponent<CapsuleCollider>();
        if (collider == null)
        {
            Logger.Error($"Capsule Collider is missing!!! \"{bone.name}\"");
            return;
        }

        collider.center = center;
        collider.height = height;
        collider.radius = radius;
        collider.direction = (int)dir;
    }

    public static void ApplyCapsuleColliderSetting(this Transform[] bones, string boneName, Vector3 center, float radius, float height, CapsuleDirection dir)
    {
        var bone = bones.FindBone(boneName);
        if (bone == null)
        {
            Logger.Error($"Bone is missing!!! \"{boneName}\"");
            return;
        }

        bone.ApplyCapsuleColliderSetting(center, radius, height, dir);
    }

    public static Transform FindBone(this Transform[] bones, string boneName)
    {
        var length = bones.Length;
        for (var i = 0; i < length; i++)
        {
            if (bones[i].name.Equals(boneName, StringComparison.InvariantCulture))
            {
                return bones[i];
            }
        }

        return null;
    }

    public static void DisplayHitboxes(GameObject prefabGO)
    {
        var sphereColliders = prefabGO.GetComponentsInChildren<SphereCollider>();
        foreach (var collider in sphereColliders)
        {
            
        }

        var capsuleColliders = prefabGO.GetComponentsInChildren<CapsuleCollider>();
        foreach (var collider in capsuleColliders)
        {
            
        }
    }
}