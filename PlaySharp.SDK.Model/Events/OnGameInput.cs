// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OnGameInput.cs" company="PlaySharp">
//     Copyright (c) PlaySharp. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace PlaySharp.SDK.Events
{
    using System;
    using System.Security;

    using JetBrains.Annotations;

    [PublicAPI]
    [SecuritySafeCritical]
    public class OnGameInput
    {
        public OnGameInput([NotNull] string input, bool process = true)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            this.Input = input;
            this.Process = process;
        }

        public string Input { [NotNull] get; }

        public bool Process { get; set; }
    }
}