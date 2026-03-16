using System;
using System.Runtime.CompilerServices;

class Book : Item
{
    private string author;

    //encapsulation
    public string Author 
    {
        get { return author; }
        set { author = value; }
    }
    //constructor
    public Book(string title, string publisher, int publicationYear, string author)
    {
        Title = title;
        Publisher = publisher;
        PublicationYear = publicationYear;
        Author = author;
    }

    //polymorphism
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine("      ");
    }
}

