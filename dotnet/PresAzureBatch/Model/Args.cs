using CommandLine;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresAzureBatch.Model
{
    internal class Args
    {
        [Option("username", Required = true, HelpText = "Nom de l'utilisateur")]
        public string? UserName { get; set; }
    }
}
