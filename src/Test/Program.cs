// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Rec rec = new Rec();
rec.H = 10;
rec.W = 10;
Console.WriteLine($"Rec: {rec.GetArea()}");

Square square = new Square();
square.H = 10;
square.W = 10;

Console.WriteLine($"Square: {square.GetArea()}");

rec = square;
Console.WriteLine($"Rec square: {rec.GetArea()}");

Console.WriteLine($"Rec square: {((Rec)square).GetArea()}");

internal class Rec
{
    public virtual int H { get; set; }
    public virtual int W { get; set; }

    public virtual int GetArea()
    {
        return H * W;
    }
}

internal class Square : Rec
{
    //private int val = 0;

    //public override int W
    //{
    //    get => val; set => val = value;
    //}

    //public override int H
    //{
    //    get => val; set => val = value;
    //}

    public override int GetArea()
    {
        return W * H * 10000;
    }
}