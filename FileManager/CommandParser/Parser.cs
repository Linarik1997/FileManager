using FileManager.CommandParser.Functions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager.CommandParser
{
    class Parser
    {
        public readonly string[] commands =
                { "ls",
                "cp",
                "rm",
                "info",
                "h" };
        public bool Find(string name)
        {
            foreach(var com in commands)
            {
                if (name == com)
                    return true;
            }
            return false;
        }
        public Command ParseLine(string[] args)
        {
            if (!Find(args[0]))
                throw new Exception($"Not Found Command {args[0]}");
            switch (args[0])
            {
                case "ls":
                    Listing listing = new Listing();
                    if (listing.canHandle(args))
                    {
                        return listing;
                    }
                    else
                        throw new Exception($"Command is not defined");
                default:
                    throw new Exception();
            }

        }

    }
}
