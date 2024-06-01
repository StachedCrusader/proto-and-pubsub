using System;
using System.Text.Json;
using Google.Protobuf;
using Proto.Messages;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("What do you want? s = serialize json into proto (one line plz), d = deserialize from proto to json, a = sample message structure");

string input = Console.ReadLine()!;

if(input.StartsWith("s"))
{
    string jsonInput = Console.ReadLine()!;

    Person personFromJson = Person.Parser.ParseJson(jsonInput);

    byte[] serializedPerson = personFromJson.ToByteArray();

    Console.WriteLine(Convert.ToBase64String(serializedPerson));
}
else if (input.StartsWith("d"))
{
    string protoInput = Console.ReadLine()!;

    byte[] serializedAsBytes = Convert.FromBase64String(protoInput);

    Person personFromProto = Person.Parser.ParseFrom(serializedAsBytes);

    Console.WriteLine(personFromProto);
}
else if(input.StartsWith("a"))
{
    Console.WriteLine(new Person()
    {
        FirstName = "First Name",
        LastName = "Last Name",
        Id = 1234
    });
}