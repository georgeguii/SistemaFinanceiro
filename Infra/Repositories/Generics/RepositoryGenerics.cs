using Microsoft.EntityFrameworkCore;

using Infra.Context;
using Domain.Interfaces.Generics;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace Infra.Repositories.Generics;

public class RepositoryGenerics<T> : InterfaceGeneric<T>, IDisposable where T : class
{
    private readonly ContextBase _context;

    public RepositoryGenerics(ContextBase context)
    {
        _context = context;
    }

    public async Task<IList<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetById(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task Add(T obj)
    {
        await _context.Set<T>().AddAsync(obj);
        await _context.SaveChangesAsync();
    }

    public async Task Update(T obj)
    {
        _context.Set<T>().Update(obj);
        await _context.SaveChangesAsync();
    }

    public async Task Remove(T obj)
    {
        _context.Set<T>().Remove(obj);
        await _context.SaveChangesAsync();
    }

    #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
    // Flag: Has Dispose already been called?
    bool disposed = false;
    // Instantiate a SafeHandle instance.
    SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);



    // Public implementation of Dispose pattern callable by consumers.
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }


    // Protected implementation of Dispose pattern.
    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
            return;

        if (disposing)
        {
            handle.Dispose();
            // Free any other managed objects here.
            //
        }

        disposed = true;
    }
    #endregion

}
