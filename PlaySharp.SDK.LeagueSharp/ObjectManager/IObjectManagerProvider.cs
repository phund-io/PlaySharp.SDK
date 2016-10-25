// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IObjectManagerProvider.cs" company="PlaySharp.SDK">
//     Copyright (c) PlaySharp.SDK. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace PlaySharp.SDK.ObjectManager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Security;

    using JetBrains.Annotations;

    using LeagueSharp;

    /// <summary>
    /// Lazy Provider accessor.
    /// </summary>
    /// <typeparam name="TProvider"></typeparam>
    /// <typeparam name="TProviderMetadata"></typeparam>
    [PublicAPI]
    [SecuritySafeCritical]
    public interface ILazyProvider<TProvider, TProviderMetadata>
    {
        TProvider ActiveProvider { [NotNull] get; }

        IEnumerable<Lazy<TProvider, TProviderMetadata>> Providers { [NotNull] [ItemNotNull] get; }
    }

    /// <summary>
    /// ObjectManager provider service.
    /// </summary>
    [PublicAPI]
    [SecuritySafeCritical]
    public interface IObjectManagerProvider : IObjectManagerProvider<GameObject, int, Obj_AI_Hero>
    {
    }

    /// <summary>
    /// ObjectManager consumer service.
    /// </summary>
    [PublicAPI]
    [SecuritySafeCritical]
    public interface IObjectManager : IObjectManagerProvider<GameObject, int, Obj_AI_Hero>,
                                      ILazyProvider<IObjectManagerProvider, IObjectManagerProviderMetadata>
    {
    }

    [PublicAPI]
    [MetadataAttribute]
    [SecuritySafeCritical]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ObjectManagerProvider : ExportAttribute, IObjectManagerProviderMetadata
    {
        public ObjectManagerProvider([NotNull] string name)
            : base(typeof(IObjectManagerProvider))
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            this.Name = name;
        }

        public string Name { [NotNull] get; }
    }

    [PublicAPI]
    [SecuritySafeCritical]
    public interface IObjectManagerProviderMetadata
    {
        string Name { [NotNull] get; }
    }

    /// <summary>
    /// ObjectManager provider service impl.
    /// </summary>
    [PublicAPI]
    [SecuritySafeCritical]
    [ObjectManagerProvider("Default")]
    public class DefaultLeagueObjectManagerProvider : IObjectManagerProvider
    {
        public Obj_AI_Hero Hero => ObjectManager.Player;

        public IEnumerable<TUnit> Get<TUnit>() where TUnit : GameObject, new()
        {
            return ObjectManager.Get<TUnit>();
        }

        public TUnit Get<TUnit>(int id) where TUnit : GameObject, new()
        {
            return ObjectManager.GetUnitByNetworkId<TUnit>(id);
        }

        public IEnumerable<TUnit> GetFast<TUnit>() where TUnit : GameObject, new()
        {
            return ObjectManager.Get<TUnit>();
        }

        public ParallelQuery<TUnit> GetParallel<TUnit>() where TUnit : GameObject, new()
        {
            return ObjectManager.Get<TUnit>().AsParallel();
        }
    }

    /// <summary>
    /// ObjectManager consumer service impl.
    /// </summary>
    [PublicAPI]
    [SecuritySafeCritical]
    [Export(typeof(IObjectManager))]
    public class LeagueObjectManager : IObjectManager
    {
        public IObjectManagerProvider ActiveProvider { get; }

        [ImportMany(typeof(IObjectManagerProvider))]
        public IEnumerable<Lazy<IObjectManagerProvider, IObjectManagerProviderMetadata>> Providers { get; protected set; }

        public Obj_AI_Hero Hero => this.ActiveProvider.Hero;

        public IEnumerable<TUnit> Get<TUnit>() where TUnit : GameObject, new()
        {
            return this.ActiveProvider.Get<TUnit>();
        }

        public TUnit Get<TUnit>(int id) where TUnit : GameObject, new()
        {
            return this.ActiveProvider.Get<TUnit>(id);
        }

        public IEnumerable<TUnit> GetFast<TUnit>() where TUnit : GameObject, new()
        {
            return this.ActiveProvider.GetFast<TUnit>();
        }

        public ParallelQuery<TUnit> GetParallel<TUnit>() where TUnit : GameObject, new()
        {
            return this.ActiveProvider.GetParallel<TUnit>();
        }
    }
}