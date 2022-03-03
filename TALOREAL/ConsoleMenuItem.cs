using System;
using System.Collections.Generic;

namespace TALOREAL {

    public class ConsoleMenuItem {

        protected static Dictionary<ConsoleColor, ConsoleColor> InverseTable = new Dictionary<ConsoleColor, ConsoleColor>() {
            { ConsoleColor.Red, ConsoleColor.Green }, { ConsoleColor.White, ConsoleColor.Black },
            { ConsoleColor.DarkRed, ConsoleColor.Blue }, { ConsoleColor.Gray, ConsoleColor.DarkGray },
            { ConsoleColor.DarkBlue, ConsoleColor.Cyan }, { ConsoleColor.DarkGreen, ConsoleColor.Yellow },
            { ConsoleColor.DarkYellow, ConsoleColor.Magenta }, { ConsoleColor.DarkCyan, ConsoleColor.DarkMagenta },
            { ConsoleColor.DarkMagenta, ConsoleColor.DarkCyan }, { ConsoleColor.Magenta, ConsoleColor.DarkYellow },
            { ConsoleColor.Yellow, ConsoleColor.DarkGreen }, { ConsoleColor.Cyan, ConsoleColor.DarkBlue },
            { ConsoleColor.DarkGray, ConsoleColor.Gray }, { ConsoleColor.Blue, ConsoleColor.DarkRed },
            { ConsoleColor.Black, ConsoleColor.White }, { ConsoleColor.Green, ConsoleColor.Red },
        };


        public string Text { get; protected set; } = "";

        public ConsoleColor TextColor { get; protected set; } = ConsoleColor.White;
        public ConsoleColor BackColor { get; protected set; } = ConsoleColor.Black;

        public Action OnSelect { get; protected set; } = () => { };


        public ConsoleMenuItem(string text) { Text = text; }

        public virtual ConsoleMenuItem SetColors(ConsoleColor textColor, ConsoleColor backColor) {
            TextColor = textColor; BackColor = backColor; return this;
        }

        public virtual ConsoleMenuItem SetTextColor(ConsoleColor textColor) {
            TextColor = textColor;
            BackColor = InverseTable[TextColor];
            return this;
        }

        public virtual ConsoleMenuItem SetBackColor(ConsoleColor backColor) {
            BackColor = backColor;
            TextColor = InverseTable[BackColor];
            return this;
        }

        public virtual ConsoleMenuItem SetActionOnSelect(Action onSelect) {
            OnSelect = onSelect == null ? OnSelect : onSelect;
            return this;
        }
    }
}
