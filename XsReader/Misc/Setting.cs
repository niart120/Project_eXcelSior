using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Project_eXcelSior.Misc;
public class Setting
{
    [JsonInclude]
    public string seed0;
    [JsonInclude]
    public string seed1;
    [JsonInclude]
    public Decimal targetAdvance;
    [JsonInclude]
    public Decimal fps;

    public Setting(string seed0, string seed1, Decimal targetAdvance, Decimal fps) { 
        this.seed0 = seed0;
        this.seed1 = seed1;
        this.targetAdvance = targetAdvance;
        this.fps = fps;
    }

    public static string GetConfigFilePath()
    {
        string appFilePath = AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\');
        return appFilePath + $"/config.json";
    }

    public static Setting? ReadConfig()
    {
        // 設定ファイルのフルパスを取得
        string configFile = GetConfigFilePath();

        if (File.Exists(configFile) == false)
        {
            // 設定ファイルなし
            return null;
        }

        using (var reader = new StreamReader(configFile, Encoding.UTF8))
        {
            // 設定ファイル読み込み
            string buf = reader.ReadToEnd();
            Setting? result = null;
            try
            {
                result = JsonSerializer.Deserialize<Setting>(buf);
            }
            catch (JsonException jex) 
            {
                return null;    
            }
            // デシリアライズして返す
            return result;
        }
    }

    public static void WriteConfig(Setting cfg)
    {
        // シリアライズ;
        var jsconfig = new JsonSerializerOptions
        {
            IncludeFields = true,
        };
        string buf = JsonSerializer.Serialize(cfg, jsconfig);

        // 設定ファイルのフルパス取得
        string configFile = GetConfigFilePath();

        using (var writer = new StreamWriter(configFile, false, Encoding.UTF8))
        {
            // 設定ファイルに書き込む
            writer.Write(buf);
        }
    }

}
