﻿using System;
using System.IO;

namespace NetMentoring.Loggers
{
    public class LogWriter : IDisposable
    {
        private StreamWriter _streamWriter;

        public LogWriter(string pathToFile) 
            => _streamWriter = new StreamWriter(pathToFile);

        // added for educational purposes
        ~LogWriter() 
            => Dispose(false);

        public void Log(string message)
        {
            try
            {
                _streamWriter.WriteLine(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                _streamWriter?.Close();
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _disposeManagedResources;

        protected virtual void Dispose(bool disposing)
        {
            Console.WriteLine("Call of protected virtual void Dispose");
            if (_disposeManagedResources) return;
            if (disposing)
                _streamWriter?.Dispose();
            _disposeManagedResources = true;
        }
    }
}
