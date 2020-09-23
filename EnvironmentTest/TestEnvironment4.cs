using EnvironmentTest.Environment.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnvironmentTest
{
    public class TestEnvironment4 : IEnvironment
    {
        public string DBConnectionString { get; set; }
        public List<User> Users { get; set; }
        public List<FileInfo> Files { get; set; }

        public void Initialize()
        {
            DBConnectionString = "DBsldkfldsjfldsjflsjdf";

            Users = new List<User>()
            {
                new User()
                {
                    Name = "abc",
                    Index = 1
                },
                new User()
                {
                    Name = "def",
                    Index = 2
                },
                new User()
                {
                    Name = "ghi",
                    Index = 3
                },
            };

            Files = new List<FileInfo>()
            {
                new FileInfo()
                {
                    Name = "file1",
                    FullPath = @"C:\Users\FileTest"
                },
                new FileInfo()
                {
                    Name = "file2",
                    FullPath = @"C:\Users\FileTest"
                },
                new FileInfo()
                {
                    Name = "file3",
                    FullPath = @"C:\Users\FileTest"
                },
            };
        }
    }
}
