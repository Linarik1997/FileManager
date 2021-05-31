using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.CommandParser
{
    public abstract class Command
    {
        public abstract string name { get; }
        public abstract bool canHandle(string[] args);
        public abstract void Handle(string[] args);
    }
}
