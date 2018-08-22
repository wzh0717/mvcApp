# asp.net Core MVC 应用

### 官方文档
* aspnet内库源码： [https://github.com/aspnet](https://github.com/aspnet)
* dotnet系统内库源码：[https://github.com/dotnet](https://github.com/dotnet)

---

####  自定义端口访问
* webHost增加UseUrls。 例：WebHost.UseUrls("http://*:5001","http://*:5002");
* 配置文件 hosting.json。例：
>> 通过查看[WebHost](https://github.com/aspnet/Hosting.git)源码我们得知，启动后会先读取相关配置参数，
```csharp
internal class WebHost:IWebHost
{
    private static readonly string DeprecatedServerUrlsKey = "server.urls";
    //...
    private void EnsureServer()
    {
        if (Server == null)
        {
            //...
            if (addresses != null && !addresses.IsReadOnly && addresses.Count == 0)
            {
            var urls = _config[WebHostDefaults.ServerUrlsKey] ?? _config[DeprecatedServerUrlsKey];                  
            }
        }
    }
}
public static class WebHostDefaults{
    public static readonly string ServerUrlsKey = "urls";
    //...
}
```
```json
{"server.urls": "http://localhost:5003;http://localhost:5004"}
```
```csharp
 public class Program
 {
    public static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("hosting.json", true)
            .Build();

        BuildWebHost(args, config).Run();
            //BuildWebHost(args).Run();
    }

    public static IWebHost BuildWebHost(string[] args, IConfiguration config) =>
        WebHost.CreateDefaultBuilder(args)
            //  .UseUrls("http://*:5001", "http://*:5002")
            .UseConfiguration(config)
            .UseStartup<Startup>()
            .Build();
    }
```
* 配置环境变量。设置ASPNETCORE_URLS、ASPNET_ENV、ASPNETCORE_SERVER.URLS的值。
