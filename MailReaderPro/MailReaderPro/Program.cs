using System;
using System.Threading.Tasks;
using MimeKit;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Reading in email from ../test-email.eml");

        var email = new MimeKit.MimeMessage();

        await email.SendMessage();
    }
}