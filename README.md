# NLogTargetsLoggly
NLog connector targeting Loggly

Usage (sample App.config):

```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
       <section name="nlog" type="NLog.Config.ConfigSectionHandler, NLog" />
  </configSections>

  <nlog>
    <extensions>
      <add assembly="NLogTargetsLoggly" />
    </extensions>
    <targets>
      <target name="Loggly" type="Loggly" 
              layout="${date:format=ddd MMM dd} ${time:format=HH:mm:ss} ${date:format=zzz yyyy} ${logger} : ${LEVEL}, ${message}, ${exception:format=tostring}" />
    </targets>
    <rules>
      <logger name="*" minLevel="Debug" writeTo="Loggly" />
    </rules>
  </nlog>

  <appSettings>
    <add key="LogglyToken" value="HERECOMESTHETOKEN" />
    <add key="LogglyTag" value="TAG" />
  </appSettings>
</configuration>
```
