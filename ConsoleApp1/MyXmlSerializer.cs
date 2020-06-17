using System.Xml;
using ExtendedXmlSerializer;
using ExtendedXmlSerializer.Configuration;

namespace ConsoleApp1
{
    public class MyXmlSerializer : ISerializer
    {
        private static readonly XmlWriterSettings XmlWriterSettings;

        static MyXmlSerializer()
        {
            XmlWriterSettings = new XmlWriterSettings { Indent = true };
        }

        public T Deserialize<T>(string data)
        {
            IExtendedXmlSerializer serializer = new ConfigurationContainer()
                .Create();

            return serializer.Deserialize<T>(data);
        }

        public string Serialize<T>(T item)
        {
            IExtendedXmlSerializer serializer = new ConfigurationContainer()
                .UseAutoFormatting()
                .UseOptimizedNamespaces()
                .EnableImplicitTyping(typeof(T))
                .Create();

            return serializer.Serialize(XmlWriterSettings, item);
        }
    }
}
