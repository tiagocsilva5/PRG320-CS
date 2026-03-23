using System;

interface ILibraryItem
{
    string Title { get; set; }
    string Publisher { get; set; }
    int PublicationYear { get; set; }
    void DisplayInfo();
}