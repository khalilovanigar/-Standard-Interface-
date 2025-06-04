using System.Reflection.Metadata;
class Program
{
    static void Main()
    {
        System.Console.WriteLine($@"Choose version:
1.Basic
2.Pro
3.Expert"); 

        string input = Console.ReadLine();
        DocumentProgram docProgram;

        if (input == "2")
        {
            docProgram = new ProDocumentProgram();
        }
        else if (input == "3")
        {
            docProgram = new ExpertDocument();
        }
        else
        {
            docProgram = new DocumentProgram();
        }


        string[] options = { "Open Document", "Edit Document", "Save Document", "Exit" };
        int selectedIndex = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Use Up/Down arrows and Enter to select an option:\n");

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                    Console.WriteLine($"> {options[i]}");
                else
                    Console.WriteLine($"  {options[i]}");
            }

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                selectedIndex--;
                if (selectedIndex < 0) selectedIndex = options.Length - 1;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                selectedIndex++;
                if (selectedIndex >= options.Length) selectedIndex = 0;
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                Console.Clear();

                if (selectedIndex == 0)
                {
                    docProgram.OpenDocument();
                }
                else if (selectedIndex == 1)
                {
                    docProgram.EditDocument();
                }
                else if (selectedIndex == 2)
                {
                    docProgram.SaveDocument();
                }
                else if (selectedIndex == 3)
                {
                    Console.WriteLine("Exiting...");
                    return;
                }

                Console.WriteLine("\nPress any key to return to menu...");
                Console.ReadKey();
            }
        }
    }


    public class DocumentProgram
    {
        public void OpenDocument()
        {
            System.Console.WriteLine("Document opened");
        }
        public virtual void EditDocument()
        {
            System.Console.WriteLine("Can edit in Pro and Expert versions");
        }
        public virtual void SaveDocument()
        {
            System.Console.WriteLine("Can save in Pro and Expert versions");
        }
    }

    public class ProDocumentProgram : DocumentProgram
    {
        public void OpenDocument()
        {
            System.Console.WriteLine("Document opened");
        }
        public sealed override void EditDocument()
        {
            System.Console.WriteLine("Document Edited");
        }
        public void SaveDocument()
        {
            System.Console.WriteLine("Document saved in doc format,for pdf format buy Expert packet");
        }
    }

    public class ExpertDocument : ProDocumentProgram
    {
        public void OpenDocument()
        {
            System.Console.WriteLine("Document opened");
        }
        public void EditDocument()
        {
            System.Console.WriteLine("Document Edited");
        }
        public void SaveDocument()
        {
            System.Console.WriteLine("Document saved in pdf format");
        }
    }
}
