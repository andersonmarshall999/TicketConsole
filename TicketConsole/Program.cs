using System;
using System.IO;

namespace TicketConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "tickets.csv";
            string choice;
            do
            {
                // ask user for input
                Console.WriteLine("1) Read data from file.");
                Console.WriteLine("2) Create file from data.");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    // read data from file
                    if (File.Exists(file))
                    {
                        StreamReader sr = new StreamReader(file);
                        // skip header line
                        sr.ReadLine();
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            // convert string to array
                            string[] arr = line.Split(',');
                            // display array data
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6}", arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
                else if (choice == "2")
                {
                    // create file from data
                    StreamWriter sw = new StreamWriter(file);
                    sw.WriteLine("TicketID,Summary,Status,Priority,Submitter,Assigned,Watching");
                    int ticketCount = 0;
                    string resp;
                    do
                    {
                        // create ticketId
                        ticketCount++;
                        int ticketId = ticketCount;
                        // prompt for and save summary
                        Console.WriteLine("Enter ticket summary.");
                        string summary = Console.ReadLine();
                        // prompt for and save status
                        Console.WriteLine("Enter ticket status.");
                        string status = Console.ReadLine();
                        // prompt for and save priority
                        Console.WriteLine("Enter ticket priority.");
                        string priority = Console.ReadLine();
                        // prompt for and save submitter
                        Console.WriteLine("Enter name of submitter.");
                        string submitter = Console.ReadLine();
                        // prompt for and save assigned
                        Console.WriteLine("Enter name of assigned personnel.");
                        string assigned = Console.ReadLine();
                        // prompt for and save watching
                        string watcher;
                        string watching = "";
                        int watcherCount = 0;
                        do
                        {
                            Console.WriteLine("Enter name(s) of people watching. Enter \"NA\" to stop.");
                            watcher = Console.ReadLine();
                            if (watcher.ToUpper() == "NA")
                            {
                                watcher = "NA";
                            }
                            else
                            {
                                watcherCount++;
                                if (watcherCount > 1) watching += "|";
                                watching += watcher;
                            } // theres probably a better way to separate watchers but whatever
                        } while (watcher != "NA");
                        sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", ticketId, summary, status, priority, submitter, assigned, watching);
                        Console.WriteLine("Create another ticket? (Y/N)");
                        // prompt for new ticket
                        resp = Console.ReadLine().ToUpper();
                    } while (resp == "Y");
                    sw.Close();
                }
            } while (choice == "1" || choice == "2");
        }
    }
}