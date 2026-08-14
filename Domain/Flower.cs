namespace Domain;

public class Flower(int flowerId, string name, string color, decimal price)
{
    public int FlowerId { get; } = flowerId;
    public string Name { get; } = name;
    public string Color { get; } = color;
    public decimal Price { get; } = price;

    public override string ToString()
    {
        return $"{FlowerId} - {Name} - {Color} - {Price:F2}";
    }

}