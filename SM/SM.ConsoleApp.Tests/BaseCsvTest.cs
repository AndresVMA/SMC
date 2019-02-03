using System;
using System.IO;

namespace SM.DataService.CSV.Tests
{
    public class BaseCsvTest : IDisposable
    {
        private string _csvPath;
        public BaseCsvTest()
        {
            
            
        }

        protected string CreateTestFile(string fileName)
        {
            _csvPath = $"{AppDomain.CurrentDomain.BaseDirectory}{fileName}";
            var stream = File.Create(_csvPath);
            stream.Close();
            return _csvPath;
        }
        public void Dispose()
        {
            File.Delete(_csvPath);
        }
    }
}
