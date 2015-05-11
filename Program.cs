using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Stregsystem stregsystem = new Stregsystem();
            StregsystemCLI cli = new StregsystemCLI(stregsystem);
            StregsystemCommandParser parser = new StregsystemCommandParser(cli, stregsystem);
            cli.Start(parser);
        }
    }
}
