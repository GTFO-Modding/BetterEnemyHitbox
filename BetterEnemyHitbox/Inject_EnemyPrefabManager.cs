using AssetShards;
using BetterEnemyHitbox.Fixes;
using Enemies;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BetterEnemyHitbox;
[HarmonyPatch(typeof(EnemyPrefabManager), nameof(EnemyPrefabManager.GenerateAllEnemyPrefabs))]
internal static class Inject_EnemyPrefabManager
{
    static bool _Done = false;

    [HarmonyWrapSafe]
    private static void Prefix()
    {
        if (_Done)
            return;

        var fixer = new PrefabFixer[]
        {
            new FixBirtherPrefab(),
            new FixTankPrefab(),
            new FixShooterPrefab()
        };

        foreach (var fix in fixer)
        {
            fix.Fix();
        }

        _Done = true;
    }
}
