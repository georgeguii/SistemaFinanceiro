using Microsoft.EntityFrameworkCore;

using Infra.Context;
using Domain.Interfaces.Generics;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace Infra.Repositories.Generics;

public class RepositoryGenerics<T> : InterfaceGeneric<T>, IDisposable where T : class
{
    protected readonly ContextBase _context;

    protected virtual DbSet<T> _dbSet { get; }

    public RepositoryGenerics(ContextBase context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IList<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task Add(T obj)
    {
        await _dbSet.AddAsync(obj);
        await _context.SaveChangesAsync();
    }

    public async Task Update(T obj)
    {
        _context.Set<T>().Update(obj);
        await _context.SaveChangesAsync();
    }

    public async Task Remove(T obj)
    {
        _dbSet.Remove(obj);
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
