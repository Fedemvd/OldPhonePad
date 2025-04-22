using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Entrada manual
        Console.WriteLine("Escribí la secuencia (ej: 4433555 555666#):");
        string input = Console.ReadLine();
        Console.WriteLine($"Resultado: {OldPhonePad(input)}");

        // Casos de prueba
        Console.WriteLine("\n--- CASOS DE PRUEBA ---");
        Test("33#", "E");
        Test("227*#", "B");
        Test("4433555 555666#", "HELLO");
        Test("222 2 22#", "CAB");
        Test("999337777#", "WES");
        Test("8 88777444666 0 999337777#", "TUS MATES WES");
    }

    static void Test(string input, string expected)
    {
        string result = OldPhonePad(input);
        Console.WriteLine($"Input: \"{input}\" → Resultado: \"{result}\" {(result == expected ? "✔️" : $"❌ (Esperado: \"{expected}\")")}");
    }

    static string OldPhonePad(string input)
    {
        var result = "";
        var currentSequence = "";

        foreach (char c in input)
        {
            switch (c)
            {
                case ' ':
                    ProcessSequence(currentSequence, ref result);
                    currentSequence = "";
                    break;
                case '*':
                    ProcessSequence(currentSequence, ref result);
                    currentSequence = "";
                    if (result.Length > 0)
                        result = result.Substring(0, result.Length - 1);
                    break;
                case '#':
                    ProcessSequence(currentSequence, ref result);
                    return result;
                default:
                    if (currentSequence.Length > 0 && currentSequence[0] != c)
                    {
                        ProcessSequence(currentSequence, ref result);
                        currentSequence = "";
                    }
                    currentSequence += c;
                    break;
            }
        }

        // Por si no termina con #
        ProcessSequence(currentSequence, ref result);
        return result;
    }

    static void ProcessSequence(string sequence, ref string result)
    {
        if (string.IsNullOrEmpty(sequence))
            return;

        var key = sequence[0];
        int count = sequence.Length;

        var keypad = new Dictionary<char, string>
        {
            { '2', "ABC" }, { '3', "DEF" }, { '4', "GHI" },
            { '5', "JKL" }, { '6', "MNO" }, { '7', "PQRS" },
            { '8', "TUV" }, { '9', "WXYZ" }
        };

        if (keypad.ContainsKey(key))
        {
            string letters = keypad[key];
            int index = (count - 1) % letters.Length;
            result += letters[index];
        }
    }
}
