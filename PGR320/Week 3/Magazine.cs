using System;

class Magazine : Item
{
    private string issueNumber;

    //encapsulation
    public string IssueNumber
    {
        get { return issueNumber; }
        set { issueNumber = value; }
    }

    public Magazine(string title, string publisher, int publicationYear, string issueNumber)
    {
        Title = title;
        Publisher = publisher;
        PublicationYear = publicationYear;
        IssueNumber = issueNumber;
    }
    //polymorphism
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Issue Number: {IssueNumber}");
        Console.WriteLine("      ");
    }
}
