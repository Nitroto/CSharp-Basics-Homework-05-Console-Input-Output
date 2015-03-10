using System;
using System.Threading;
using System.Globalization;
class PrintCompanyInformation
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.Write("Company name: ");
        string companyName = Console.ReadLine();
        Console.Write("Company address: ");
        string companyAddress = Console.ReadLine();
        Console.Write("Phone number: ");
        string companyPhone = Console.ReadLine();
        if (companyPhone=="")
        {
            companyPhone = "(no phone)";
        }
        Console.Write("Fax number: ");
        string companyFax = Console.ReadLine();
        if (companyFax == "")
        {
            companyFax = "(no fax)";
        }
        Console.Write("Web site: ");
        string companyWeb = Console.ReadLine();
        if (companyWeb == "")
        {
            companyWeb = "(no web site)";
        }
        Console.Write("Manager first name: ");
        string managerFirstName = Console.ReadLine();
        Console.Write("Manager last name: ");
        string managerLastName = Console.ReadLine();
        Console.Write("Manager age: ");
        byte managerAge = Byte.Parse(Console.ReadLine());
        Console.Write("Manager phone number: ");
        string managerPhone = Console.ReadLine();
        if (managerPhone == "")
        {
            managerPhone = "(no phone)";
        }
        Console.WriteLine("{0}\r\nAddress: {1}\r\nTel.: {2}\r\nFax: {3}\r\nWeb site: {4}\r\nManager: {5} {6} (age: {7}, tel. {8})", companyName, companyAddress,companyPhone,companyFax, companyWeb,managerFirstName, managerLastName, managerAge, managerPhone);
    }
}
