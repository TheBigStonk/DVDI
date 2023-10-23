# Damn Vulnerable Dependency Injection (DVDI)
(*TLDR: The section below labelled [Installation](#-Installation) should help you set it up*)

Ever since Alex Birsan came up with his amazing research on Dependency Confusion in 2021 ([here](https://medium.com/@alex.birsan/dependency-confusion-4a5d60fec610)) 

In summary Alex's research takes a look at how local/public feeds/locations can all be confused with versions and people publishing everywhere can invariably lead to bad peoples code being referenced in your code! 😱😱😱

Now, what this is involves a POC with setup instructions which looks at:

- Publishing a package with the same name as a NuGet.org package to a local feed;
- Importing the local package to a victim app (.NET Console App); and
- Getting data exfiltration via an AWS API Gateway (HTTP, no auth'd) which connects to an AWS Lambda (Python) and logs data it receives.

![picture-of-dvdi-in-action](/Local_Dependency_Confusion_Example.png)

## Installation

To do later however adding in some snippets before I forget em

Command to pack the malicious C# Class Library to a package:
``` powershell
dotnet pack -c Release /p:PackageVersion=4.3.2.1
```

Add a local NuGet feed
``` powershell
dotnet nuget add source <Path to Local Feed Directory> -n LocalFeed
```

Add package to local feed
``` powershell
nuget add .\bin\Release\MimeKit.4.3.2.nupkg -Source C:\LocalNugetFeed\
```

Command to add package to victim app:
``` powershell
dotnet add package MimeKit --version 4.3.2.1 --source C:\LocalNugetFeed\
```

### AWS things

You'll also want to create a Lambda and copy-paste the Python lambda function (tested on a 3.10 runtime) and set up an API Gateway with HTTP no Auth, The logs are viewed via the default CloudWatch log group created.
    
## Prevention

.NET does have some answers to this with Package Source Mapping https://devblogs.microsoft.com/nuget/introducing-package-source-mapping/ however for the most part it is worth:

- Using only needed third-party dependencies;
- Build yourself an SBOM (Software Bill of Materials (I get the irony this doesn't have one));
- Utilise Package Source Mapping if you haven't already; and
- Use trusted libraries, lots of downloads != safe, however that shaddy package with 10 downloads released a day ago might warrant a closer look that newtonsoft.
## Acknowledgements

 - [readme generator via readme.so](https://readme.so/)
 - [NuGet for the awesome Package Management Ecosystem](https://www.nuget.org/)

[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)


