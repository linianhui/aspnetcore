#addin "Cake.IIS"
#addin "Cake.Hosts"
#addin "Cake.Powershell"

var target = Argument("target", "default");

var rootPath = "./";
var solution = rootPath + "aspnetcore.example.sln";
var srcProjectPath  = rootPath + "src/";

var websites = new []{
    new {
        host = "dotnet.watch.run",
        path = srcProjectPath + "dotnet.watch.run/",
    }
};

Task("deploy-iis")
    .Description("部署到iis")
    .DoesForEach(websites, (website) => 
{
    AddHostsRecord("127.0.0.1", website.host);

    DeleteSite(website.host);

    CreateWebsite(new WebsiteSettings
    {
        Name              = website.host,
        Binding           = IISBindings.Http.SetHostName(website.host)
                                            .SetIpAddress("*")
                                            .SetPort(80),
        ServerAutoStart   = true,
        PhysicalDirectory = website.path,
        ApplicationPool   = new ApplicationPoolSettings
        {
            Name                  = website.host,
            IdentityType          = IdentityType.LocalSystem,
            MaxProcesses          = 1,
            ManagedRuntimeVersion = "v4.0"
        }
    });
});

Task("open-browser")
    .Description("打开浏览器")
    .Does(() =>
{
    StartPowershellScript("Start-Process", args =>
    {
        var urls = "";
        foreach(var website in websites){
            urls += ",'http://" + website.host + "/'";
        }

        args.Append("chrome.exe")
            .Append("'-incognito'")
            .Append(urls);
    });
});


/// default task
Task("default")
    .Description("默认操作")
    .IsDependentOn("deploy-iis")
    .IsDependentOn("open-browser");

RunTarget(target);
