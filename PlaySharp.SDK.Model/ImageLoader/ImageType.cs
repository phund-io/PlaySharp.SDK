// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageType.cs" company="PlaySharp">
//     Copyright (c) PlaySharp. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace PlaySharp.SDK.ImageLoader
{
    using System.ComponentModel;
    using System.Security;

    using JetBrains.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public enum ImageType
    {
        [Description("champion")]
        Champion,

        [Description("passive")]
        PassiveAbility,

        [Description("spell")]
        Spell,

        [Description("spell")]
        SummonerSpell,

        [Description("item")]
        Item,

        [Description("mastery")]
        Mastery,

        [Description("rune")]
        Rune,

        [Description("sprite")]
        Sprite,

        [Description("map")]
        Minimap,
    }
}