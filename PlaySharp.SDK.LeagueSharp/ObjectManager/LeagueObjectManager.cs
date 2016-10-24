// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LeagueObjectManager.cs" company="PlaySharp">
//     Copyright (c) PlaySharp. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace PlaySharp.SDK.ObjectManager
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Security;

    using JetBrains.Annotations;

    using LeagueSharp;

    [PublicAPI]
    [SecuritySafeCritical]
    [Export(typeof(IObjectManager))]
    public class LeagueObjectManager : IObjectManager
    {
        private ImmutableArray<GameObject> cache = ImmutableArray<GameObject>.Empty;

        [SecuritySafeCritical]
        public LeagueObjectManager()
        {
            Game.OnUpdate += this.OnPreUpdate; // OnPreUpdate :jodus_pls:
        }

        public Obj_AI_Hero Hero
        {
            [SecuritySafeCritical]
            get
            {
                return ObjectManager.Player;
            }
        }

        [SecuritySafeCritical]
        public IEnumerable<TUnit> Get<TUnit>() where TUnit : GameObject, new()
        {
            return ObjectManager.Get<TUnit>();
        }

        [SecuritySafeCritical]
        [CollectionAccess(CollectionAccessType.Read)]
        public TUnit Get<TUnit>(int id) where TUnit : GameObject, new()
        {
            return this.cache.AsParallel().FirstOrDefault(e => e.NetworkId == id) as TUnit;
        }

        [SecuritySafeCritical]
        [CollectionAccess(CollectionAccessType.Read)]
        public IEnumerable<TUnit> GetFast<TUnit>() where TUnit : GameObject, new()
        {
            foreach (var unit in this.cache.AsParallel().OfType<TUnit>())
            {
                yield return unit;
            }
        }

        [SecuritySafeCritical]
        [CollectionAccess(CollectionAccessType.Read)]
        public ParallelQuery<TUnit> GetParallel<TUnit>() where TUnit : GameObject, new()
        {
            return this.cache.AsParallel().OfType<TUnit>();
        }

        [SecuritySafeCritical]
        [CollectionAccess(CollectionAccessType.UpdatedContent)]
        private void OnPreUpdate(EventArgs args)
        {
            this.cache = ObjectManager.Get<GameObject>().ToImmutableArray();
        }
    }
}