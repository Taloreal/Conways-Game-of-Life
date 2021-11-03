using System;
using System.Xml.Serialization;

namespace TALOREAL {

    /// <summary>
    /// StrTyp_Key was suppose to be a quickway to switch between Settings database'
    /// "frontend" key and "backend" key. (nonstatic fields deprecated 2020.)
    /// </summary>
    [Serializable] public class StrTyp_Key {

        public string Name;
        [XmlIgnore] private Type _Kind;
        [XmlIgnore] private string _TypeName;
        [XmlIgnore] private const string TAG = " :1a3b5c7d9: ";

        /// <summary>
        /// The type of variable in Settings' database. (DEPRECATED)
        /// </summary>
        [XmlIgnore]
        public Type Kind {
            get { return _Kind; }
            set { _Kind = value; _TypeName = value.FullName; }
        }

        /// <summary>
        /// The name of the type of variable used. (DEPRECATED)
        /// </summary>
        public string TypeName {
            get { return _TypeName; }
            set { _Kind = Type.GetType(value); _TypeName = _Kind.FullName; }
        }

        /// <summary>
        /// The backend key used by Settings' database. (DEPRECATED)
        /// </summary>
        public string Key {
            get { return Get_STKCode(Name, Kind); }
        }

        /// <summary>
        /// Creates a String Type Key. (DEPRECATED)
        /// </summary>
        public StrTyp_Key(string STKCode) {
            string[] parts = STKCode.Split(TAG);
            if (parts.Length != 2) { throw new Exception("ERROR: Invalid String-Type key."); }
            if (parts[0].Contains(":")) { throw new Exception("ERROR: Key name cannot contain ':'."); }
            Name = parts[0];
            _Kind = Type.GetType(parts[1]);
        }

        /// <summary>
        /// Creates a String Type Key. (DEPRECATED)
        /// </summary>
        public StrTyp_Key(string called, Type ofKind) {
            if (called.Contains(":")) { throw new Exception("ERROR: Key name cannot contain ':'."); }
            Name = called;
            _Kind = ofKind;
        }

        /// <summary>
        /// Creates the string key for Settings' database.
        /// </summary>
        /// <param name="called">The frontend key.</param>
        /// <param name="ofKind">The type of variable.</param>
        /// <returns>The backend key.</returns>
        public static string Get_STKCode(string called, Type ofKind) {
            if (called.Contains(":")) { throw new Exception("ERROR: Key name cannot contain ':'."); }
            return called + TAG + ofKind.FullName;
        }
    }
}