using Curs.Domain;

var dictionary = new HashDictionary<string, string>();

while (true)
{
    Console.WriteLine("1-Add");
    Console.WriteLine("2-Remove");
    Console.WriteLine("3-Get all keys");
    Console.WriteLine("4-Get all items");
    Console.WriteLine("5-Get item by key");
    Console.WriteLine("6-Get length");
    Console.WriteLine("0-Exit");

    Console.WriteLine("Comm: ");
    var commStr = Console.ReadLine();

    if (!int.TryParse(commStr, out var comm))
        continue;

    try
    {
        switch (comm)
        {
            case 1:
                Add();
                break;
            case 2:
                Remove();
                break;
            case 3:
                ShowArray<string>(dictionary.Keys);
                break;
            case 4:
                ShowArray<string>(dictionary.Values);
                break;
            case 5:
                GetElem();
                break;
            case 6:
                Console.WriteLine(dictionary.Length);
                break;
            default:
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    if (comm == 0)
        return;

    Console.WriteLine();
    Console.WriteLine("-----------------------");
    Console.WriteLine();
}

void Add()
{
    Console.WriteLine("Enter key: ");
    var key = Console.ReadLine();

    if (key is null)
    {
        Console.WriteLine("Key is null. Try again");
        return;
    }

    Console.WriteLine("Enter value: ");
    var value = Console.ReadLine();

    dictionary.Add(key, value);
}

void Remove()
{
    Console.WriteLine("Enter key: ");
    var key = Console.ReadLine();

    if (key is null)
    {
        Console.WriteLine("Key is null. Try again");
        return;
    }

    dictionary.Remove(key);
}

void ShowArray<T>(T[] array)
{
    foreach(var elem in array)
        Console.WriteLine($"{elem}");
}

void GetElem()
{
    Console.WriteLine("Enter key: ");
    var key = Console.ReadLine();

    if (key is null)
    {
        Console.WriteLine("Key is null. Try again");
        return;
    }

    var elem = dictionary.GetElement(key);

    Console.WriteLine(elem);
}