using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TALOREAL {

    public class ConsoleAmountMenu {

        public int Selected { get; private set; } = 0;
        public int MaxCombinedValue { get; private set; } = -1;

        public string PreChoiceText = "";
        public string PostChoiceText = "";

        public event Action<ConsoleAmountMenu> OnDrawMenu;
        public event Action<ConsoleAmountMenu> OnChoicesDisplayed;
        public event Action<ConsoleAmountMenu, int> OnChoiceMade;
        public event Action<ConsoleAmountMenu> OnMenuClosed;

        public int ItemCount => Items.Count;
        List<ConsoleAmountMenuItem> Items = new List<ConsoleAmountMenuItem>();
        public int TotalValue { 
            get { 
                int count = 0; 
                Items.ForEach(i => count += i.Value); 
                return count; 
            } 
        }

        public int MaxTextLength {
            get {
                int length = 0;
                Items.ForEach(i => length = Math.Max(length, i.Text.Length));
                return length;
            }
        }

        public ConsoleAmountMenuItem this[int index] {
            get { return index < 0 || index >= Items.Count ? null : Items[index]; }
        }

        public ConsoleAmountMenu(int maxValue = -1) {
            MaxCombinedValue = maxValue;
        }

        public void AddItem(ConsoleAmountMenuItem item) { Items.Add(item); }

        public int[] GetValues() {
            if (Items.Count < 1) { return new int[] { }; }
            bool choosen = false, ogVisible = Console.CursorVisible;
            ConsoleKeyInfo key; Console.CursorVisible = false;
            while ((Selected != Items.Count) || choosen == false) {
                choosen = false;
                DisplayMenu();
                while (Console.KeyAvailable == false) { Thread.Sleep(62); }
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow) { Selected = Math.Max(0, Selected - 1); }
                if (key.Key == ConsoleKey.DownArrow) { Selected = Math.Min(Items.Count, Selected + 1); }
                if (key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.LeftArrow) {
                    choosen = true;
                    if (Selected != Items.Count) {
                        Items[Selected].Value -= 1;
                        Items[Selected].OnSelect();
                    }
                }
                if (key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.RightArrow) {
                    choosen = true;
                    if (Selected != Items.Count && (MaxCombinedValue < 1 || TotalValue < MaxCombinedValue)) {
                        Items[Selected].Value += 1;
                        Items[Selected].OnSelect();
                    }
                }
                if (choosen) { OnChoiceMade?.Invoke(this, Selected); }
            } 
            Console.CursorVisible = ogVisible;
            OnMenuClosed?.Invoke(this);
            int[] values = new int[Items.Count];
            values.ForEach((v, i) => v = Items[i].Value);
            for (int i = 0; i < values.Length; i++) {
                values[i] = Items[i].Value;
            }
            return values;
        }

        private void DisplayMenu() {
            int ndx = 0, x = 0, y = 0;
            int padding = MaxTextLength + 1;
            ConsoleColor ogText = Console.ForegroundColor;
            ConsoleColor ogBack = Console.BackgroundColor;
            Console.Clear();
            OnDrawMenu?.Invoke(this);
            if (MaxCombinedValue > 0) {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(TotalValue + " / " + MaxCombinedValue + " assigned");
            }
            if (PreChoiceText != "") { Console.WriteLine(PreChoiceText); }
            Items.ForEach(i => { DisplayMenuItem(i, ndx == Selected, padding, ref x, ref y); ndx++; });
            Console.BackgroundColor = Selected == Items.Count ? ConsoleColor.White : ConsoleColor.Black;
            Console.ForegroundColor = Selected == Items.Count ? ConsoleColor.Black : ConsoleColor.White;
            Console.WriteLine("Done");
            Console.BackgroundColor = ogBack;
            Console.ForegroundColor = ogText;
            if (PostChoiceText != "") { Console.WriteLine(PostChoiceText); }
            OnChoicesDisplayed?.Invoke(this);
        }

        private void DisplayMenuItem(ConsoleAmountMenuItem item, bool selected, int padding, ref int x, ref int y) {
            Console.BackgroundColor = selected == false ? item.BackColor : item.TextColor;
            Console.ForegroundColor = selected == false ? item.TextColor : item.BackColor;
            Console.Write((item.Text).PadRight(padding));
            Console.BackgroundColor = selected == false ? item.TextColor : item.BackColor;
            Console.ForegroundColor = selected == false ? item.BackColor : item.TextColor;
            int tenths = item.GetPercentage() / 10;
            Console.Write("".PadRight(tenths));
            Console.BackgroundColor = selected == false ? item.BackColor : item.TextColor;
            Console.ForegroundColor = selected == false ? item.TextColor : item.BackColor;
            Console.WriteLine("".PadRight(11 - tenths) + item.Value + " / " + item.Maximum);
            y += 1;
        }
    }
}
