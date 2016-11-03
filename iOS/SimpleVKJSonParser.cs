using System.Collections.Generic;
using System.Linq;

namespace RadaCodeTestTask.iOS
{

	public class SimpleVKJSonParser
	{

		string JsonText { get; set; }
		public SimpleVKJSonParser()
		{
			this.JsonText = "";
		}

		public SimpleVKJSonParser(string jsonText)
		{
			this.JsonText = jsonText;
		}

		/// <summary>
		/// Parses JSON data to the Dictionary string,string.
		/// </summary>
		/// <returns>Dictionary string,string</returns>
		/// <param name="keyAttribute">Name of the key attribute.</param>
		/// <param name="attribute">Name of the attribute to parse.</param>
		public Dictionary<string, string> ParseToDictionary(string keyAttribute, string attribute)
		{
			Dictionary<string, string> values = new Dictionary<string, string>();
			try
			{
				int index = 0;

				JsonText = JsonText.Remove(0, JsonText.IndexOf('[') + 1);
				JsonText = JsonText.Remove(JsonText.Count() - 2);

				while (JsonText.IndexOf("{", index, System.StringComparison.CurrentCulture) != -1)
				{
					if (index == 0)
						JsonText = JsonText.Remove(0, index);
					else JsonText = JsonText.Remove(0, index + 1);

					//int start = JsonText.IndexOf("{");
					int end = JsonText.IndexOf("}", System.StringComparison.Ordinal);
					string jsonInstance = JsonText.Remove(end);

					int start1 = jsonInstance.IndexOf(keyAttribute, System.StringComparison.Ordinal);
					int end1 = jsonInstance.IndexOf(",", start1, System.StringComparison.Ordinal);

					int start2 = jsonInstance.IndexOf(attribute, System.StringComparison.Ordinal);
					int end2 = jsonInstance.IndexOf("\"", start2 + 8);

					string id = jsonInstance.Substring(start1, end1 - start1);
					id = id.Remove(0, 5);

					string value = jsonInstance.Substring(start2, end2 - start2 + 1);
					value = value.Remove(value.Count() - 1);
					value = value.Remove(0, 8);

					values.Add(id, value);
					index = end;
				}
			}
			catch
			{

			}
			return values;

		}
	}
}
