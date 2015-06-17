/*
 * Created by SharpDevelop.
 * User: alexanw
 * Date: 11/8/2013
 * Time: 4:07 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Configuration;
using TwainDotNet;

namespace ASInsScan
{
    /// <summary>
    /// ScannerSettings class is used to store the TWAIN attribute properties of interacting with the scanner based on entries in the config file.
    /// </summary>
    /// <remarks>
    /// Author: William Alexander
    /// Company: Albany Medical Center
    /// Created Date: 11/15/2013
    /// Example Usage (app.config):
    ///   <configuration>
    ///     <configSections>
    ///       <section
    ///         name="scannerSettings"
    ///         type="ASInsScan.ScannerSettings, ASInsScan"
    ///         allowLocation="true"
    ///         allowDefinition="Everywhere" />
    ///     </configSections>
    ///     <scannerSettings
    ///         useDocumentFeeder="true"
    ///         showTwainUI="false"
    ///         showProgressIndicatorUI="false"
    ///         useDuplex="false"
    ///         shouldTransferAllPages="true">
    ///       <rotationSettings
    ///           automaticRotate="false"
    ///           automaticBorderDetection="false" />
    ///       <resolutionSettings
    ///           colourSetting="Colour"
    ///           dpi="300"
    ///           brightLevel="50" />
    ///     </scannerSettings>
    ///   </configuration>
    /// </remarks>
	public class ScannerSettings : ConfigurationSection
	{
		[ConfigurationProperty("useDocumentFeeder", DefaultValue=true, IsRequired = true)]
		public bool UseDocumentFeeder{
			get { return (bool)this["useDocumentFeeder"]; }
			set { this["useDocumentFeeder"] = value; }
		}
		
		[ConfigurationProperty("showTwainUI", DefaultValue=false, IsRequired = true)]
		public bool ShowTwainUI {
			get { return (bool)this["showTwainUI"]; }
			set { this["showTwainUI"] = value; }
		}

		[ConfigurationProperty("showProgressIndicatorUI", DefaultValue=false, IsRequired=true)]
		public bool ShowProgressIndicatorUI {
			get { return (bool)this["showProgressIndicatorUI"]; }
			set { this["showProgressIndicatorUI"] = value; }
		}

		[ConfigurationProperty("useDuplex", DefaultValue=false, IsRequired=true)]
		public bool UseDuplex {
			get { return (bool)this["useDuplex"]; }
			set { this["useDuplex"] = value; }
		}

		[ConfigurationProperty("shouldTransferAllPages", DefaultValue=true, IsRequired=true)]
		public bool ShouldTransferAllPages {
			get { return (bool)this["shouldTransferAllPages"]; }
			set { this["shouldTransferAllPages"] = value; }
		}
		
		[ConfigurationProperty("rotationSettings")]
		public RotationSettingsElement RotationSettings {
			get { return (RotationSettingsElement) this["rotationSettings"]; }
			set { this["rotationSettings"] = value; }
		}

		[ConfigurationProperty("resolutionSettings")]
		public ResolutionSettingsElement ResolutionSettings {
			get { return (ResolutionSettingsElement) this["resolutionSettings"]; }
			set { this["resolutionSettings"] = value; }
		}

        /// <summary>
        /// RotationSettingsElement is a Nested class within ScannerSettings class to store the Image Rotation setting attributes of the TWAIN API used for the scanner attached.
        /// </summary>
        /// <remarks>
        /// Author: William Alexander
        /// Company: Albany Medical Center
        /// Created Date: 11/15/2013
        /// </remarks>
        public class RotationSettingsElement : ConfigurationElement
        {
			
			[ConfigurationProperty("automaticRotate", DefaultValue=false, IsRequired = false)]
			public bool AutomaticRotate {
				get { return (bool)this["automaticRotate"]; }
		        set { this["automaticRotate"] = value; }
			}
			
			[ConfigurationProperty("automaticBorderDetection", DefaultValue=false, IsRequired = false)]
			public bool AutomaticBorderDetection {
				get { return (bool)this["automaticBorderDetection"]; }
				set { this["automaticBorderDetection"] = value; }
			}
		}

        /// <summary>
        /// ResolutionSettingsElement is a Nested class within ScannerSettings class to store the Image attributes of the TWAIN API used for the scanner attached.
        /// </summary>
        /// <remarks>
        /// Author: William Alexander
        /// Company: Albany Medical Center
        /// Created Date: 11/15/2013
        /// </remarks>
		public class ResolutionSettingsElement : ConfigurationElement {

			[ConfigurationProperty("colourSetting", DefaultValue=TwainDotNet.ColourSetting.Colour, IsRequired = false)]
			public TwainDotNet.ColourSetting ColourSetting {
				get { return (TwainDotNet.ColourSetting)this["colourSetting"]; }
				set { this["colourSetting"] = value; }
			}

			[ConfigurationProperty("dpi", DefaultValue=300, IsRequired = false)]
			public Nullable<int> Dpi {
				get { return (Nullable<int>)this["dpi"]; }
				set { this["dpi"] = value; }
			}
			
			[ConfigurationProperty("brightLevel", DefaultValue=50, IsRequired = false)]
			public Nullable<int> BrightLevel {
				get { return (Nullable<int>)this["brightLevel"]; }
				set { this["brightLevel"] = value; }
			}
		}
	}
}