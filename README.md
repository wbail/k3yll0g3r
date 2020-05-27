# k3yll0g3r

![front_img](https://github.com/wbail/k3yll0g3r/blob/master/front_img.jpg?raw=true)

Application for learning purposes.

### Tech

k3yll0g3r uses Windows to work properly:

* [.NET Framework](https://dotnet.microsoft.com/download/dotnet-framework/net472) - Robust framework!
* C# - duh

And of course k3yll0g3r itself is open source with a [public repository](https://github.com/wbail/k3yll0g3r) on GitHub.

### Features!
  
  - Screenshots and saves into a folder  :file_folder:
  - Keylogger, saves every key pressed into a log file  :file_folder:
  - Zip files  :lock:
  - Upload into a remote server  :cloud:
  - Auto hidden  :black_circle:

### Screenshot

![front_screenshot](https://github.com/wbail/k3yll0g3r/blob/master/screenshot.png?raw=true)

### Installation

k3yll0g3r requires [.NETFramework 4.7](https://dotnet.microsoft.com/download/dotnet-framework/net472) to run.

Download it from Microsoft website and install it.

### Usage (if you have a remote server)

In the ```App.config``` file, complete the fields.
```xml
  <appSettings>
    <!-- To be used at ServerClientService -->
    <add key="user" value=""/>
    <add key="password" value=""/>

    <!-- Example: ftp:// -->
    <add key="protocol" value=""/>

    <!-- If is ipv6 needs brackets [ipv6] -->
    <add key="server" value=""/>

    <!-- :21 -->
    <add key="port" value=""/>
  
  </appSettings>
```

### Authors

* **wbail** - *Initial work* - [wbail](https://github.com/wbail)