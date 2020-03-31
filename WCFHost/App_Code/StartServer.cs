using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

/// <summary>
/// Summary description for StartServer
/// </summary>
public class StartServer
{
    public StartServer()
    {
        Main();
    }

    ServiceHost host = new ServiceHost(typeof(Service));

    private void Main()
    {
        host.Open();
    }
}