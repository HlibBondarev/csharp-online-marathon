using System;

//Please, create class DisposePatternImplementer that implements Disposable pattern and inherits from CloseableResource class
//Print such lines of information in the method responsible for releasing managed and unmanaged resources:
//"Disposing by developer" if the object of the class is disposed by developer
//or "Disposing by GC" if the object is disposed by garbage collector
//also, you should ensure that method Close() is called in either case.


namespace task04
{
    public class DisposePatternImplementer : CloseableResource, IDisposable
    {
        private bool disposed;
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    Console.WriteLine("Disposing by developer");
                }
                else
                {
                    Console.WriteLine("Disposing by GC");
                }
                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                base.Close();
                disposed = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~DisposePatternImplementer()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }
    }

    public abstract class CloseableResource
    {
        public void Close()
        {
        }
    }
}