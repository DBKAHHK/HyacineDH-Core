namespace HyacineCore.Server.Configuration;

public class ConfigContainer
{
    public HttpServerConfig HttpServer { get; set; } = new();
    public KeyStoreConfig KeyStore { get; set; } = new();
    public GameServerConfig GameServer { get; set; } = new();
    public PathConfig Path { get; set; } = new();
    public DatabaseConfig Database { get; set; } = new();
    public ServerOption ServerOption { get; set; } = new();
    public MuipServerConfig MuipServer { get; set; } = new();
}

public class HttpServerConfig
{
    public string BindAddress { get; set; } = "0.0.0.0";
    public string PublicAddress { get; set; } = "127.0.0.1";
    public int Port { get; set; } = 21000;
    public bool UseSSL { get; set; } = false;
    public bool SendHotfix { get; set; } = true;
    public bool UseFetchRemoteHotfix { get; set; } = false;

    public string GetDisplayAddress()
    {
        return (UseSSL ? "https" : "http") + "://" + PublicAddress + ":" + Port;
    }

    public string GetBindDisplayAddress()
    {
        return (UseSSL ? "https" : "http") + "://" + BindAddress + ":" + Port;
    }
}

public class KeyStoreConfig
{
    public string KeyStorePath { get; set; } = "certificate.p12";
    public string KeyStorePassword { get; set; } = "123456";
}

public class GameServerConfig
{
    public string BindAddress { get; set; } = "0.0.0.0";
    public string PublicAddress { get; set; } = "127.0.0.1";
    public uint Port { get; set; } = 23301;
    public string GameServerId { get; set; } = "hyacine_core";
    public string GameServerName { get; set; } = "HyacineCore";
    public string GameServerDescription { get; set; } = "A re-implementation of StarRail server";
    public bool UsePacketEncryption { get; set; } = true;

    public string GetDisplayAddress()
    {
        return PublicAddress + ":" + Port;
    }
}

public class PathConfig
{
    public string ResourcePath { get; set; } = "Resources";
    public string ConfigPath { get; set; } = "Config";
    public string GameDataPath { get; set; } = "Config/GameData";
    public string KeyPath { get; set; } = "Config/Keys";
    public string DatabasePath { get; set; } = "Config/Database";
    public string LogPath { get; set; } = "Config/Logs";
    public string PluginPath { get; set; } = "Config/Plugins";
}

public class DatabaseConfig
{
    public string DatabaseType { get; set; } = "sqlite";
    public string DatabaseName { get; set; } = "hyacinecore.db";
    public string MySqlHost { get; set; } = "127.0.0.1";
    public int MySqlPort { get; set; } = 3306;
    public string MySqlUser { get; set; } = "root";
    public string MySqlPassword { get; set; } = "123456";
    public string MySqlDatabase { get; set; } = "hyacinecore";
}

public class ServerOption
{
    public int StartTrailblazerLevel { get; set; } = 1;
    public bool AutoUpgradeWorldLevel { get; set; } = true;
    public bool EnableMission { get; set; } = true; // experimental
    public bool EnableMessage { get; set; } = true; // works independently from mission
    public bool EnableQuest { get; set; } = true; // experimental
    public bool AutoLightSection { get; set; } = true;
    public string Language { get; set; } = "EN";
    public string FallbackLanguage { get; set; } = "EN";
    public HashSet<string> DefaultPermissions { get; set; } = ["*"];
    public ServerAnnounce ServerAnnounce { get; set; } = new();
    public WelcomeMailOption WelcomeMail { get; set; } = new();
    public ServerProfile ServerProfile { get; set; } = new();
    public bool AutoCreateUser { get; set; } = true;
    public bool SingleUser { get; set; } = true;
    public string SingleUsername { get; set; } = "player";
    public LogOption LogOption { get; set; } = new();
    public ServerConfig ServerConfig { get; set; } = new();
    public ChallengePeakOption ChallengePeak { get; set; } = new();
    public int FarmingDropRate { get; set; } = 1;
    public bool UseCache { get; set; } = false; // don't recommend

    public int ValidFarmingDropRate()
    {
        return Math.Max(Math.Min(FarmingDropRate, 999), 1);
    }
}

public class WelcomeMailOption
{
    public bool Enable { get; set; } = false;
    public string Sender { get; set; } = "HyacineCore";
    public string Title { get; set; } = "Welcome to HyacineCore!";
    public string Content { get; set; } = "Welcome aboard.";
    public int TemplateId { get; set; } = 1;
    public int ExpiredDay { get; set; } = 3650;
    public List<WelcomeMailReward> Rewards { get; set; } = [];
}

public class WelcomeMailReward
{
    public int ItemId { get; set; }
    public int Count { get; set; } = 1;
}

public class ChallengePeakOption
{
    // 0 = auto select by progress; 1~4 = force selected group.
    public uint SelectedGroupId { get; set; } = 4;
}

public class ServerConfig
{
    public bool RunDispatch { get; set; } = true;
    public string FromDispatchBaseUrl { get; set; } = "";
    public bool RunGateway { get; set; } = true; // if run gateway, also run game server
    public List<ServerRegion> Regions { get; set; } = [];
}

public class ServerRegion
{
    public string GateWayAddress { get; set; } = "";
    public string GameServerName { get; set; } = "";
    public string GameServerId { get; set; } = "";
    public int EnvType { get; set; } = 21;
}

public class LogOption
{
#if DEBUG
    public bool EnableGamePacketLog { get; set; } = true;
#else
    public bool EnableGamePacketLog { get; set; } = false;
#endif
    public bool LogPacketToConsole { get; set; } = true;
    public bool ShowKcpHandShake { get; set; } = true;
    public bool ShowTimeInLog { get; set; } = true;
    public bool DisableLogDetailPacket { get; set; } = false;
    public bool SavePersonalDebugFile { get; set; } = false;
    public bool ShowResourceCacheLoadingItemLog { get; set; } = true;
}

public class ServerAnnounce
{
    public bool EnableAnnounce { get; set; } = false;
    public string AnnounceContent { get; set; } = "Welcome to HyacineCore!";
}

public class ServerProfile
{
    public string Name { get; set; } = "HyacineLover";
    public int Uid { get; set; } = 5201314;
    public string Signature { get; set; } = "Type /help for a list of commands";
    public int Level { get; set; } = 70;
    public int HeadIcon { get; set; } = 200139;
    public int ChatBubbleId { get; set; } = 220008;
    public int PersonalCardId { get; set; } = 253001;

    public List<ServerAssistInfo> AssistInfo { get; set; } =
    [
        new() { AvatarId = 1409, Level = 80 }
    ];
}

public class ServerAssistInfo
{
    public int AvatarId { get; set; }
    public int Level { get; set; }
    public int SkinId { get; set; }
}

public class MuipServerConfig
{
    public string AdminKey { get; set; } = "None";
}
