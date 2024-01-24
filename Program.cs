Console.WriteLine(CheckBrackets("((2+3)*5-(7-3)/3)*8"));
Console.WriteLine(CheckBrackets("((2+3)*5 - ((7-3) / 3) * 8"));

Console.WriteLine(CheckBrackets("{ int[] a = new int[10]; a[1] = (2-3)*4; }"));
Console.WriteLine(CheckBrackets("if ((a > 0) || (b < 3) { ++a; }"));

Console.WriteLine(CheckBrackets("([})])"));
Console.WriteLine(CheckBrackets("{[()]}"));
Console.WriteLine("\nДополнительное задание");

CountingCharacters("Строка1: A1,B2 Строка2: a3,b4");

bool CheckBrackets(string example)
{
    Stack<char> stack = new Stack<char>();

    Dictionary<char, char> brackets = new Dictionary<char, char>
    {
        { '(', ')' },
        { '[', ']' },
        { '{', '}' }
    };

    foreach(char e in example)
    {
        if (brackets.ContainsKey(e))
        {
            stack.Push(e);
        }
        else if (brackets.ContainsValue(e))
        {
            if (stack.Count == 0 || brackets[stack.Peek()] != e)
            {
                return false;
            }
            stack.Pop();
        }
    }

    return stack.Count == 0;
}

void CountingCharacters(string str)
{
    int enUpperCase = 0;
    int enLowerCase = 0;
    int ruUpperCase = 0;
    int ruLowerCase = 0;
    int digits = 0;
    int other = 0;

    foreach (char c in str)
    {
        if ('A' <= c && c <= 'Z')
        {
            enUpperCase++;
        } else if ('a' <= c && c <= 'z')
        {
            enLowerCase++;
        } else if ('А' <= c && c <= 'Я')
        {
            ruUpperCase++;
        } else if ('а' <= c && c <= 'я')
        {
            ruLowerCase++;
        } else if ('0' <= c && c <= '9')
        {
            digits++;
        } else
        {
            other++;
        }
    }

    Console.WriteLine($"EnUpperCase: {enUpperCase}\n" +
                $"EnLowerCase: {enLowerCase}\n" +
                $"RuUpperCase:  {ruUpperCase}\n" +
                $"RuLowerCase: {ruLowerCase}\n" +
                $"Digits: {digits}\n" +
                $"Other: {other}");
}