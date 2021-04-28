using CheckersV4.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CheckersV4.Services
{
    class SerializeAndDeserialize
    {
        public static void SerializeObjectToXML<T>(T item, string FilePath)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            using (StreamWriter wr = new StreamWriter(FilePath))
            {
                xs.Serialize(wr, item);
            }
        }

        //public static void SerializeGame<T, W>(T board, W players, string FilePath)
        //{
        //    XmlSerializer xsBoard = new XmlSerializer(typeof(T));
        //    XmlSerializer xsPlayers = new XmlSerializer(typeof(W));

        //    using (StreamWriter wr = new StreamWriter(FilePath))
        //    {
        //        xsBoard.Serialize(wr, board);
        //        xsPlayers.Serialize(wr, players);
        //    }
        //}

        public static T DeserializeObjectToXML<T>(string FilePath)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            using (StreamReader rd = new StreamReader(FilePath))
            {
                return (T)xs.Deserialize(rd);
            }
        }

        //public static KeyValuePair<T, W> DeserializeGame<T, W>(string FilePath)
        //{
        //    XmlSerializer xsBoard = new XmlSerializer(typeof(T));
        //    XmlSerializer xsPlayers = new XmlSerializer(typeof(W));
        //    using (StreamReader rd = new StreamReader(FilePath))
        //    {
        //        return new KeyValuePair<T, W>((T)xsBoard.Deserialize(rd), (W)xsPlayers.Deserialize(rd));
        //    }
        //}
    }
}
