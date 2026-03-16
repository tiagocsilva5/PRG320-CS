using System;

class Item
{
    private string title;
    private string publisher;
    private int publicationYear;

    //encapsulation

    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public string Publisher
    {
        get { return publisher; }
        set { publisher = value; }
    }

    public int PublicationYear
    {
        get { return publicationYear; }
        set { publicationYear = value; }
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine("      ");
        Console.WriteLine($"Publisher: {Publisher}");
        Console.WriteLine("      ");
        Console.WriteLine($"Publication Year: {PublicationYear}");
        Console.WriteLine("      ");
    }
}