// <copyright file="UnitExtensions.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Extensions
{
    using System;
    using System.Linq;
    using System.Security;

    using Ensage;

    using PlaySharp.Toolkit.Helper.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public static class UnitExtensions
    {
        [NotNull]
        public static Ability GetAbility([NotNull] this Unit unit, [NotNull] string name)
        {
            if (unit == null)
            {
                throw new ArgumentNullException(nameof(unit));
            }

            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            return unit.Spellbook.Spells.FirstOrDefault(s => s.Name == name);
        }
    }
}