using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Xamarin.Forms.Sample
{
    public static class ConfigStore
    {
        private const string ResourceName = "Xamarin.Forms.Sample.embedConfig.json";
        public static EmbedDetails Current { get; private set; }

        public static void Load()
        {
            try
            {
                var asm = Assembly.GetExecutingAssembly();
                using (var stream = asm.GetManifestResourceStream(ResourceName))
                {
                    if (stream != null)
                    {
                        using (var reader = new StreamReader(stream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true))
                        {
                            var json = reader.ReadToEnd();
                            if (json.Length > 0 && json[0] == '\uFEFF')
                                json = json.Substring(1);
                            Current = JsonSerializer.Deserialize<EmbedDetails>(json);
                        }
                    }
                }
            }
            catch
            {
                Current = null;
            }
        }
    }
}
