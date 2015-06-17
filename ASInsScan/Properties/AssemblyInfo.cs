#region Using directives

using System;
using System.Reflection;
using System.Runtime.InteropServices;
using log4net;
using System.Resources;

#endregion

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("AMC AllScript Insurance Scan")]
[assembly: AssemblyDescription("An application that will scan insurance cards of the patient and gather information from a Signature Screen and place the information into the Patients AllScript Chart")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Albany Medical Center, Information Services - EEHR")]
[assembly: AssemblyProduct("AMC AllScript Insurance Scan")]
[assembly: AssemblyCopyright("Copyright 2013")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// This sets the default COM visibility of types in the assembly to invisible.
// If you need to expose a type to COM, use [ComVisible(true)] on that type.
[assembly: ComVisible(false)]

// The assembly version has following format :
//
// Major.Minor.Build.Revision
//
// You can specify all the values or you can use the default the Revision and 
// Build Numbers by using the '*' as shown below:
[assembly: AssemblyVersion("1.0.*")]

// Configure log4net using the .config file
[assembly: log4net.Config.XmlConfigurator(Watch=true)]
// This will cause log4net to look for a configuration file
// called [Application].exe.config in the application base
// directory (i.e. the directory containing [Application].exe)
// The config file will be watched for changes.

[assembly: NeutralResourcesLanguageAttribute("en-US")]
