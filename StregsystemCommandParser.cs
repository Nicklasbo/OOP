using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class StregsystemCommandParser
    {
        Stregsystem Stregsystem;
        StregsystemCLI CLI;
        Dictionary<string, Action<string[]>> Commands;

        public StregsystemCommandParser(StregsystemCLI cli, Stregsystem stregsystem)
        {
            this.Stregsystem = stregsystem;
            this.CLI = cli;

            this.Commands = new Dictionary<string, Action<string[]>>
            {
                {":q", QuitAction},
                {":quit", QuitAction},
                {":activate", ActivateAction},
                {":deactivate", DeactivateAction},
                {":crediton", CreditOnAction},
                {":creditoff", CreditOffAction},
                {":addcredits", AddCreditsAction}
            };
        }

        public void ParseCommand(string line)
        {
            string[] commands = line.Split(' ');

            if (!string.IsNullOrEmpty(line))
            {
                if (commands[0].StartsWith(":"))
                {
                    if (this.Commands.ContainsKey(commands[0]))
                    {
                        this.Commands[commands[0]](commands);
                    }
                    else
                    {
                        this.CLI.DisplayAdminCommandNotFoundMessage();
                    }
                }
                else
                {
                    switch (commands.Count())
                    {
                        case 1:
                            this.CLI.DisplayUserInfo(this.Stregsystem.GetUser(commands[0]));

                            break;

                        case 2:
                            if (commands[1].Equals("transaction"))
                            {
                                this.CLI.DisplayTransactionList(this.Stregsystem.GetUser(commands[0]), 10);
                            }
                            else
                            {
                                this.Stregsystem.BuyProduct(this.Stregsystem.GetUser(commands[0]), this.Stregsystem.GetProduct(Convert.ToInt32(commands[1])));
                            }

                            break;

                        case 3:
                            if (commands[1].Equals("transaction"))
                            {
                                this.CLI.DisplayTransactionList(this.Stregsystem.GetUser(commands[0]), Convert.ToInt32(commands[2]));
                            }
                            else
                            {
                                for (int i = 0; i < Convert.ToInt32(commands[1]); i++)
                                {
                                    this.Stregsystem.BuyProduct(this.Stregsystem.GetUser(commands[0]), this.Stregsystem.GetProduct(Convert.ToInt32(commands[2])));
                                }
                            }

                            break;

                        default:
                            this.CLI.DisplayTooManyArgumentsError();
                            break;
                    }

                }
            }
        }

        void QuitAction(string[] commands)
        {
            System.Environment.Exit(1);
        }

        void ActivateAction(string[] commands)
        {
            this.Stregsystem.GetProduct(Convert.ToInt32(commands[1])).Active = true;
        }

        void DeactivateAction(string[] commands)
        {
            this.Stregsystem.GetProduct(Convert.ToInt32(commands[1])).Active = false;
        }

        void CreditOnAction(string[] commands)
        {
            this.Stregsystem.GetProduct(Convert.ToInt32(commands[1])).CanBeBoughtOnCredit = true;
        }

        void CreditOffAction(string[] commands)
        {
            this.Stregsystem.GetProduct(Convert.ToInt32(commands[1])).CanBeBoughtOnCredit = false;
        }

        void AddCreditsAction(string[] commands)
        {
            this.Stregsystem.AddCreditsToAccount(this.Stregsystem.GetUser(commands[1]), Convert.ToSingle(commands[2]));
        }
    }
}