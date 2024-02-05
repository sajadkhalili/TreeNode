namespace ConsoleApp1;

public class Node
{
    public int Id { get; set; }
    public int ParentId { get; set; }
    public string Text { get; set; }
    public List<Node> Children { get; set; }
}