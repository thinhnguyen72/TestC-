using System;
using System.Collections;

class Program
{
    static Hashtable addressBook = new Hashtable();

    static void Main()
    {
        int choice;

        do
        {
            Console.WriteLine("Contact Manager");
            Console.WriteLine("1. Add new contact");
            Console.WriteLine("2. Find a contact by name");
            Console.WriteLine("3. Display contacts");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice (1-4): ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        AddContact();
                        break;
                    case 2:
                        FindContact();
                        break;
                    case 3:
                        DisplayContacts();
                        break;
                    case 4:
                        Console.WriteLine("Exiting the Contact Manager.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

            Console.WriteLine();
        } while (choice != 4);
    }

    static void AddContact()
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Phone: ");
        string phone = Console.ReadLine();

        Contact newContact = new Contact(name, phone);

        if (!addressBook.ContainsKey(name))
        {
            addressBook.Add(name, newContact);
            Console.WriteLine("Contact added successfully.");
        }
        else
        {
            Console.WriteLine("Contact with the same name already exists. Please choose a different name.");
        }
    }

    static void FindContact()
    {
        Console.Write("Enter Name to find: ");
        string name = Console.ReadLine();

        if (addressBook.ContainsKey(name))
        {
            Contact contact = (Contact)addressBook[name];
            Console.WriteLine($"Contact found: {contact.Name}, Phone: {contact.Phone}");
        }
        else
        {
            Console.WriteLine("Contact not found.");
        }
    }

    static void DisplayContacts()
    {
        Console.WriteLine("******** Address Book ********");
        Console.WriteLine("Contact Name\tPhone number");

        foreach (DictionaryEntry entry in addressBook)
        {
            Contact contact = (Contact)entry.Value;
            Console.WriteLine($"{contact.Name,-20}\t{contact.Phone,-15}");
        }
    }
}