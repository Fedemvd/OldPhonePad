# 📱 Old Phone Pad

## 📝 Description

This project implements a function in C# that simulates typing text using an old-style mobile phone keypad. The input is a string of numbers (0-9), where each key maps to a group of letters, just like in classic phones. Special characters like `*` and `#` are also supported for editing and ending the message.

---

## ✅ Features

- Interprets sequences of digits as text input.
- Supports special keys:
  - `*` (deletes the last character)
  - `#` (ends the message)
- Handles repeated key presses to cycle through letters.
- Prevents duplicate letters if the same key isn't pressed consecutively.
- Stops processing after the `#` symbol.

---

## 🔢 Key Mapping

| Key | Letters        |
|-----|----------------|
| 1   |                |
| 2   | A B C          |
| 3   | D E F          |
| 4   | G H I          |
| 5   | J K L          |
| 6   | M N O          |
| 7   | P Q R S        |
| 8   | T U V          |
| 9   | W X Y Z        |
| 0   | (space)        |
| *   | Backspace      |
| #   | End input      |

---

## 🧠 Logic

- Pressing the same number key repeatedly cycles through its letters.
- When a different key is pressed, the last selected letter is committed to the output.
- `*` removes the last letter from the result.
- `#` ends the input and stops processing.
- Invalid or unknown characters are ignored.

---

## 🧪 Test Cases

| Input                          | Expected Output |
|--------------------------------|------------------|
| `"33#"`                        | `"E"`            |
| `"227*#"`                      | `"B"`            |
| `"4433555 555666096667775553#"`| `"HELLO WORLD"`  |
| `"2#"`                         | `"A"`            |
| `"222*2#"`                     | `"B"`            |
| `"7*7#"`                       | `"P"`            |
| `"0#"`                         | `" "` (space)    |
| `"**#"`                        | `""`             |

---

## 💻 Usage

```csharp
string input = "4433555 555666096667775553#";
string result = OldPhonePad.GetMessage(input);
Console.WriteLine(result);  // Output: "HELLO WORLD"
