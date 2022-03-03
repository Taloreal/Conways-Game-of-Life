using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TALOREAL {

    public class ConsoleSelectMenu {

        static string[] QuitPhrases = { "exit", "quit", "continue", "break" };

        public bool ClearConsole { get; private set; } = true;
        public bool Loops { get; private set; } = true;
        public bool Numbered { get; private set; } = false;

        private int _YOffset = 0;
        public int YOffset {
            get => _YOffset;
            set {
                value = value >= Console.WindowHeight ? Console.WindowHeight - 1 : value;
                value = value < 0 ? 0 : value;
                _YOffset = value;
            }
        }

        public int Selected { get; private set; } = 0;

        private int _ExitChoice = -1;
        public int ExitChoice { 
            get => _ExitChoice;
            set { _ExitChoice = Math.Min(Math.Max(value, 0), Choices.Count - 1); }
        }

        public string PreChoiceText = "";
        public string PostChoiceText = "";

        public ConsoleTextAlign TextAlignment { get; set; } = ConsoleTextAlign.LeftAligned;

        public event Action<ConsoleSelectMenu> OnDrawMenu;
        public event Action<ConsoleSelectMenu> OnChoicesDisplayed;
        public event Action<ConsoleSelectMenu, int> OnChoiceMade;
        public event Action<ConsoleSelectMenu> OnMenuClosed;

        public int ChoiceCount => Choices.Count;
        List<ConsoleMenuItem> Choices = new List<ConsoleMenuItem>();

        public ConsoleMenuItem this[int index] {
            get { return index < 0 || index >= Choices.Count ? null : Choices[index]; }
        }

        public ConsoleSelectMenu(bool loops, bool numbered, bool clearOnRefresh) { 
            Loops = loops;
            Numbered = numbered;
            ClearConsole = clearOnRefresh;
        }

        public void AddChoice(ConsoleMenuItem item) {
            Choices.Add(item);
            if (QuitPhrases.Contains(item.Text.ToLower())) {
                ExitChoice = Choices.IndexOf(item);
            }
        }

        public int GetChoice() {
            if (Choices.Count < 1) { return -1; }
            if (Loops && (ExitChoice < 0 || ExitChoice >= Choices.Count)) { return -1; }
            bool choosen = false;
            ConsoleKeyInfo key;
            bool ogVisible = Console.CursorVisible;
            Console.CursorVisible = false;
            do {
                choosen = false;
                DisplayMenu();
                while (Console.KeyAvailable == false) {
                    Thread.Sleep(62);
                }
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow) { Selected = Math.Max(0, Selected - 1); }
                if (key.Key == ConsoleKey.DownArrow) { Selected = Math.Min(Choices.Count - 1, Selected + 1); }
                if (key.Key == ConsoleKey.Enter) { 
                    choosen = true; 
                    Choices[Selected].OnSelect();
                    OnChoiceMade?.Invoke(this, Selected);
                }
            } while ((Loops && Selected != ExitChoice) || choosen == false);
            Console.CursorVisible = ogVisible;
            OnMenuClosed?.Invoke(this);
            return Selected;
        }

        private void DisplayMenu() {
            int ndx = 0;
            ConsoleColor ogText = Console.ForegroundColor;
            ConsoleColor ogBack = Console.BackgroundColor;
            if (ClearConsole) { Console.Clear(); }
            OnDrawMenu?.Invoke(this);
            if (PreChoiceText != "") { Console.WriteLine(PreChoiceText); }
            Choices.ForEach(c => { DisplayMenuItem(c, ref ndx); });
            Console.ForegroundColor = ogText;
            Console.BackgroundColor = ogBack;
            if (PostChoiceText != "") { Console.WriteLine(PostChoiceText); }
            OnChoicesDisplayed?.Invoke(this);
        }

        private void DisplayMenuItem(ConsoleMenuItem choice, ref int ndx) {
            Console.BackgroundColor = Selected != ndx ? choice.BackColor : choice.TextColor;
            Console.ForegroundColor = Selected != ndx ? choice.TextColor : choice.BackColor;
            Console.WriteLine((Numbered ? (ndx + 1) + ": " : "") + choice.Text);
            ndx++;
        }
    }
}
