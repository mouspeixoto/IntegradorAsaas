﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegradorAsaas.Repositorio
{
    public class BaseClass : IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;

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
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        ~BaseClass()
        {
            Dispose(false);
        }
    }
}