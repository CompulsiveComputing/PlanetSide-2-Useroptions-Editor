/*
 * Created by SharpDevelop.
 * User: Devahlin
 * Date: 01/26/2015
 * Time: 01:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Xml.Serialization;
using System.IO;

namespace PS2_INI_Editor
{
	/// <summary>
	/// Description of XMLSerialize.
	/// </summary>
	public class XMLSerialize
	{
		public static string SerializeToString(object obj) // taken from https://social.msdn.microsoft.com/Forums/en-US/5d08bc28-5b61-4c5a-8c4b-4665b1c929ea/serialize-object-to-string?forum=csharplanguage
		{
			XmlSerializer serializer = new XmlSerializer(obj.GetType());
			
			using (StringWriter writer = new StringWriter())
			{
				serializer.Serialize(writer, obj);
				
				return writer.ToString();
			}
		}
		
		public static ValueCatalogue ReadXMLValueCatalogue(string str) // I'd really like to shore the xmlreader up and have one generic reader
		{
			return DeserializeFromXmlString<ValueCatalogue>(str);
			/*var stringReader = new StringReader(str);
			System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(ValueCatalogue));
			ValueCatalogue catalogue = new ValueCatalogue();
			catalogue = (ValueCatalogue)reader.Deserialize(stringReader);
			stringReader.Dispose();
			return catalogue;*/

		}
		
		public static T DeserializeFromXmlString<T>(string xmlString) // http://stackoverflow.com/questions/4996876/generic-deserialization-of-an-xml-string
		{
			var serializer = new XmlSerializer(typeof(T));
			using (TextReader reader = new StringReader(xmlString))
			{
				return (T) serializer.Deserialize(reader);
			}
		}
		
		public static settingsBank ReadXMLSettingsBank(string str) // I'd really like to shore the xmlreader up and have one generic reader
		{
			var stringReader = new StringReader(str);
			System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(settingsBank));
			settingsBank bank = new settingsBank();
			bank = (settingsBank)reader.Deserialize(stringReader);
			
			stringReader.Dispose();
			return bank;

		}
	}
}
