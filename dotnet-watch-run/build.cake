#addin "Cake.IIS"
#addin "Cake.Hosts"
#addin "Cake.FileHelpers"
#addin "Cake.Powershell"

/// params
var target = Argument("target", "default");

/// iis web site config
var webSiteConfig = new {
    host = "api.asp-net-core.dev",
    path = "./src",
    appPoolName = "apppool.noclr"
};

/// deploy task
Task("deploy")
    .Does(() =>
{
    DeleteSite(webSiteConfig.host);

    CreateWebsite(new WebsiteSettings()
    {
        Name = webSiteConfig.host,
        Binding = IISBindings.Http.SetHostName(webSiteConfig.host)
                                  .SetIpAddress("*")
                                  .SetPort(80),
        ServerAutoStart = true,
        PhysicalDirectory = webSiteConfig.path,
        ApplicationPool = new ApplicationPoolSettings()
        {
            Name = webSiteConfig.appPoolName,
            IdentityType = IdentityType.LocalSystem,
            MaxProcesses = 1,
            ManagedRuntimeVersion = null
        }
    });
        
    AddHostsRecord("127.0.0.1", webSiteConfig.host);
});

/// open browser task
Task("open-browser")
    .Does(() =>
{
    StartPowershellScript("Start-Process", args =>
    {
        args.Append("chrome.exe")
            .Append("'-incognito'")
            .Append(", '" + webSiteConfig.host + "'");
    });
});


/// default task
Task("default")
.IsDependentOn("deploy")
.IsDependentOn("open-browser");

RunTarget(target);
