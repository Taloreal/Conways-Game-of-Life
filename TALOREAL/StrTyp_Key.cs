using System;
using System.Xml.Serialization;

namespace TALOREAL {

    [Serializable] public class StrTyp_Key {

        public string Name;
        [XmlIgnore] private Type _Kind;
        [XmlIgnore] private string _TypeName;
        [XmlIgnore] private const string TAG = " :1a3b5c7d9: ";

        [XmlIgnore]
        public Type Kind {
            get { return _Kind; }
            set { _Kind = value; _TypeName = value.FullName; }
        }

        public string TypeName {
            get { return _TypeName; }
            set { _Kind = Type.GetType(value); _TypeName = _Kind.FullName; }
        }

        public string Key {
            get { return Get_STKCode(Name, Kind); }
        }

        public StrTyp_Key(string STKCode) {
            string[] parts = STKCode.Split(TAG);
            if (parts.Length != 2) { throw new Exception("ERROR: Invalid String-Type key."); }
            if (parts[0].Contains(":")) { throw new Exception("ERROR: Key name cannot contain ':'."); }
            Name = parts[0];
            _Kind = Type.GetType(parts[1]);
        }

        public StrTyp_Key(string called, Type ofKind) {
            if (called.Contains(":")) { throw new Exception("ERROR: Key name cannot contain ':'."); }
            Name = called;
            _Kind = ofKind;
        }

        public static string Get_STKCode(string called, Type ofKind) {
            if (called.Contains(":")) { throw new Exception("ERROR: Key name cannot contain ':'."); }
            return called + TAG + ofKind.FullName;
        }
    }
}