// <copyright file="EnsageAssembly.cs" company="PlaySharp">
//    Copyright (c) 2016 PlaySharp.
// </copyright>
namespace PlaySharp.SDK.Composition.EntryPoints
{
    using System.Threading.Tasks;

    public abstract class EnsageAssembly : EntryPoint, IAssembly
    {
    }

    public abstract class EnsageAsyncAssembly : EnsageAssembly, IAsyncAssembly
    {
        public abstract bool CanExecute { get; }

        public abstract Task ExecuteAsync();

        public virtual async Task OnUpdateAsync()
        {
            // TODO: impl async handler
        }
    }

    public interface IAsyncAssembly
    {
        Task OnUpdateAsync();
    }
}