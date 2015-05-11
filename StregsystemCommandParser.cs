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

        public StregsystemCommandParser(StregsystemCLI cli, Stregsystem stregsystem)
        {
            this.Stregsystem = stregsystem;
            this.CLI = cli;
        }

        public void ParseCommand(string command)
        {
            string[] data = command.Split(' ');

            if (command.StartsWith(":q") || command.StartsWith(":quit"))
            {
                System.Environment.Exit(1);
            }
            else if (command.StartsWith(":activate"))
            {
                this.Stregsystem.GetProduct(Convert.ToInt32(data[1])).Active = true;
            }
            else if (command.StartsWith(":deactivate"))
            {
                this.Stregsystem.GetProduct(Convert.ToInt32(data[1])).Active = false;
            }
            else if (command.StartsWith(":crediton"))
            {
                this.Stregsystem.GetProduct(Convert.ToInt32(data[1])).CanBeBoughtOnCredit = true;
            }
            else if (command.StartsWith(":creditoff"))
            {
                this.Stregsystem.GetProduct(Convert.ToInt32(data[1])).CanBeBoughtOnCredit = false;
            }
            else if (command.StartsWith(":addcredits"))
            {
                this.Stregsystem.AddCreditsToAccount(this.Stregsystem.GetUser(data[1]), Convert.ToSingle(data[2]));
            }
            else if (data.Count() == 1)
            {
                this.CLI.DisplayUserInfo(this.Stregsystem.GetUser(data[0]));

                //this.CLI.DisplayTransactionList(this.Stregsystem.GetUser(data[0]), 100); //TODO ret antal transactions parameter
            }
            else if (data.Count() == 2)
            {
                try
                {
                    this.Stregsystem.BuyProduct(this.Stregsystem.GetUser(data[0]), this.Stregsystem.GetProduct(Convert.ToInt32(data[1])));
                }
                catch (InsufficientCreditsException)
                {
                    this.CLI.DisplayInsufficientCash();
                }
                catch (UserNotFoundException)
                {
                    this.CLI.DisplayUserNotFound();
                }
                catch (ProductNotFoundException)
                {
                    this.CLI.DisplayProductNotFound();
                }
                catch (Exception e)
                {
                    this.CLI.DisplayGeneralError(e.Message);
                }
            }
            else if (data.Count() == 3)
            {
                for (int i = 0; i < Convert.ToInt32(data[1]); i++)
                {
                    this.Stregsystem.BuyProduct(this.Stregsystem.GetUser(data[0]), this.Stregsystem.GetProduct(Convert.ToInt32(data[2])));
                }
            }
            else if (data.Count() > 3)
            {
                this.CLI.DisplayTooManyArgumentsError();
            }
            else
            {
                this.CLI.DisplayGeneralError("den er er jo helt gal, du  følger ingen instruktioner what so ever! tag dig sammen");
            }

            this.CLI.ParseLine();
        }
    }
}
