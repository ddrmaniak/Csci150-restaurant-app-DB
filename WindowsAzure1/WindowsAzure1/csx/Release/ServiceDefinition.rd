<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="WindowsAzure1" generation="1" functional="0" release="0" Id="2ca2aae6-efba-47ce-888f-96cda229257e" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="WindowsAzure1Group" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="foodApp:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/WindowsAzure1/WindowsAzure1Group/LB:foodApp:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="foodApp:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/WindowsAzure1/WindowsAzure1Group/MapfoodApp:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="foodAppInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/WindowsAzure1/WindowsAzure1Group/MapfoodAppInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:foodApp:Endpoint1">
          <toPorts>
            <inPortMoniker name="/WindowsAzure1/WindowsAzure1Group/foodApp/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapfoodApp:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/WindowsAzure1/WindowsAzure1Group/foodApp/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapfoodAppInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/WindowsAzure1/WindowsAzure1Group/foodAppInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="foodApp" generation="1" functional="0" release="0" software="C:\Users\Inspiron\Documents\Visual Studio 2010\Projects\foodApp\WindowsAzure1\WindowsAzure1\csx\Release\roles\foodApp" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;foodApp&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;foodApp&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/WindowsAzure1/WindowsAzure1Group/foodAppInstances" />
            <sCSPolicyUpdateDomainMoniker name="/WindowsAzure1/WindowsAzure1Group/foodAppUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/WindowsAzure1/WindowsAzure1Group/foodAppFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="foodAppUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="foodAppFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="foodAppInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="13894aed-d929-4856-a80b-613788f4f0c0" ref="Microsoft.RedDog.Contract\ServiceContract\WindowsAzure1Contract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="4b145ce6-898f-4181-9bfe-0b40e06542cc" ref="Microsoft.RedDog.Contract\Interface\foodApp:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/WindowsAzure1/WindowsAzure1Group/foodApp:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>