#addin Microsoft.Win32.Registry&version=4.0.0.0
#addin System.Reflection.TypeExtensions&version=4.1.0.0
#addin nuget:?package=cake.iis&version=0.4.2
#addin nuget:?package=cake.hosts&version=1.5.1
#addin nuget:?package=cake.powershell&version=0.4.7

var target = Argument("target", "default");

var rootPath = "../";
var solution = rootPath + "aspnetcore.example.sln";
var srcProjectPath  = rootPath + "1-src/";

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
            MaxProcesses          = 8,
            ManagedRuntimeVersion = ""
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
