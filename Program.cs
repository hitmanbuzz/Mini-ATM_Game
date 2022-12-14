namespace ATM_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("# [ATM GAME]");

            Console.Write(@"
[1] Withdraw Money
[2] Transfer Money
[3] Exit

[#] Select: ");
            string main_option = Console.ReadLine();
            while(main_option != "1" && main_option != "2" && main_option != "3")
            {
                // Loop for wrong option no.
                Console.Write("[#] Select again: ");
                main_option = Console.ReadLine();
            }

            if (main_option == "1") // Withdraw 
            {
                // Withdraw Section
                Console.Clear();
                Console.WriteLine("# [WITHDRAW SECTION]");
                Console.WriteLine();

                // Read Account Balance
                string read_balance = File.ReadAllText("account_balance\\balance.txt");
                Console.WriteLine($"CURRENT BALANCE: ${read_balance}");
                Console.WriteLine();

                Console.Write("WITHDRAW AMOUNT: $");
                string amount_withdraw = Console.ReadLine();

                while (Convert.ToDouble(amount_withdraw) > Convert.ToDouble(read_balance))
                {
                    Console.Write("WITHDRAW AMOUNT: $");
                    amount_withdraw = Console.ReadLine();
                }

                // If condition for true condition
                if (Convert.ToDouble(amount_withdraw) <= Convert.ToDouble(read_balance))
                {
                    if (Convert.ToDouble(amount_withdraw) > 0)
                    {
                        Console.WriteLine($"${Convert.ToDouble(amount_withdraw)} have been withdraw from the account.");
                        double new_balance = Convert.ToDouble(read_balance) - Convert.ToDouble(amount_withdraw);
                        File.WriteAllText("account_balance\\balance.txt", Convert.ToString(new_balance));
                        Console.WriteLine();
                        Console.WriteLine($"CURRENT BALANCE: {Convert.ToString(new_balance)}");
                        Console.ReadLine();
                    }
                }
            }

            else if (main_option == "2") // Transfer
            {
                // Transfer Section

                Console.Clear();
                Console.WriteLine("# [TRANSFER SECTION]");
                Console.WriteLine();
                string read_balance = File.ReadAllText("account_balance\\balance.txt");
                Console.Write("Transfer Amount: $");
                string amount_transfer = Console.ReadLine();

                // Read Transfer Account balance
                string read_transfer_account = File.ReadAllText("user_transfer\\user_transfer.txt");

                while (Convert.ToDouble(amount_transfer) > Convert.ToDouble(read_balance))
                {
                    Console.Write("Transfer Amount: $");
                    amount_transfer = Console.ReadLine();
                }

                // If condition for true condition
                if (Convert.ToDouble(amount_transfer) <= Convert.ToDouble(read_balance))
                {
                    if (Convert.ToDouble(amount_transfer) > 0)
                    {
                        double user_update_balance = Convert.ToDouble(read_transfer_account) + Convert.ToDouble(amount_transfer);
                        double my_update_balance = Convert.ToDouble(read_balance) - Convert.ToDouble(amount_transfer);
                        File.WriteAllText("user_transfer\\user_transfer.txt", Convert.ToString(user_update_balance));
                        File.WriteAllText("account_balance\\balance.txt", Convert.ToString(my_update_balance));
                        Console.WriteLine();
                        Console.WriteLine($"My Current Balance: ${Convert.ToString(my_update_balance)}");
                        Console.WriteLine($"User Current Balance: ${Convert.ToString(user_update_balance)}");
                        Console.ReadLine();
                    }
                }
            } 
        }
    }
}