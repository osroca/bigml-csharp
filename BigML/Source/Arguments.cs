using System.Collections.Generic;
using System.Linq;

namespace BigML
{
    public partial class Source
    {
        public class Arguments : Arguments<Source>
        {
            public Arguments()
            {
                Data = new List<string>();
                Parser = new Parser();
            }

            /// <summary>
            /// Data for inline source creation. 
            /// </summary>
            public IEnumerable<string> Data
            {
                get; set;
            }

            /// <summary>
            /// File containing your data in csv format. 
            /// It can be compressed, gzipped, or zipped if the archive contains only one file. 
            /// </summary>
            public string File
            {
                get; set;
            }

            /// <summary>
            /// A URL pointing to file containing your data in csv format. It can be compressed, gzipped, or zipped. 
            /// </summary>
            public string Remote
            {
                get; set;
            }

            public Parser Parser
            {
                get; private set;
            }

            public override System.Json.JsonValue ToJson()
            {
                dynamic json = base.ToJson();

                if (!string.IsNullOrWhiteSpace(File)) json.file = File;
                if (Data != null && Data.Any()) json.data = string.Join("\n", Data);
                if (!string.IsNullOrWhiteSpace(Remote)) json.remote = File;
                json.source_parser = Parser.ToJson();
                return json;
            }
        }
    }
}