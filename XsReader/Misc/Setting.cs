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
    [JsonInclude]
    public double BLINKCONST;

    public Setting()
    {
        this.seed0 = "0";
        this.seed1 = "0";
        this.targetAdvance = 0;
        this.fps = 60;
        this.BLINKCONST = 61.0 / 60.0;
    }

    public Setting(string seed0, string seed1, Decimal targetAdvance, Decimal fps) { 
        this.seed0 = seed0;
        this.seed1 = seed1;
        this.targetAdvance = targetAdvance;
        this.fps = fps;
        this.BLINKCONST = 61.0 / 60.0;
    }
    public Setting(string seed0, string seed1, Decimal targetAdvance, Decimal fps, double BLINKCONST)
    {
        this.seed0 = seed0;
        this.seed1 = seed1;
        this.targetAdvance = targetAdvance;
        this.fps = fps;
        this.BLINKCONST = BLINKCONST;
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
