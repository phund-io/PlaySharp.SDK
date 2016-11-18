// <copyright file="GlobalAssemblyInfo.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: ComVisible(false)]
[assembly: AssemblyCulture("")]
[assembly: AssemblyProduct("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyCopyright("")]

#if DEBUG

[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif

//[assembly: Obfuscation(Feature = "rule=targets:All; features:Renaming; pattern:PlaySharp.AppDomain.*")]
//[assembly: Obfuscation(Feature = "rule=targets:All; features:AllObfuscations; pattern:PlaySharp.AppDomain.Toolkit.*")]