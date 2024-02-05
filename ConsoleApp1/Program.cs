// See https://aka.ms/new-console-template for more information

using ConsoleApp1;

Console.WriteLine("Hello, World!");



var service=new TreeService();
var nodes= service.GetParents(7, new List<Node>(), service.Nodes);


Console.ReadKey();