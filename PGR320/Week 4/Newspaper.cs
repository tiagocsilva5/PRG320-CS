using System;
using System.Runtime.CompilerServices;

class Newspaper : LibraryItemBase
{
    private string date;

    //encapsulation
    public string Date 
    {
        get { return date; }
        set { date = value; }
    }
    //constructor
    public Newspaper(string title, string publisher, int publicationYear, string date)
    {
        Title = title;
        Publisher = publisher;
        PublicationYear = publicationYear;
        Date = date;
    }

    //polymorphism
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine("      ");
    }
}
