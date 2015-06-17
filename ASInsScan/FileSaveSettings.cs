/*
 * Created by SharpDevelop.
 * User: alexanw
 * Date: 11/13/2013
 * Time: 3:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Configuration;
namespace ASInsScan
{
    /// 
    /// <summary>
    /// FileSaveSettings is a class that stored the values placed in the application config file for use in the scanning program.
    /// <para>Properties:</para>
    /// <para> - ImageWidth: Stores the width in pixels that the image scanned is to be saved.</para>
    /// <para>- ImageHeight: Stores the heigth in pixels that the image scanned is to be saved.</para>
    /// <para>- FileNameFormat: The name format of the file being saved for IEX to pickup and place into the Allscripts application.</para>
    /// <para>- IexPath: The network share of where the file is to be stored to be picked up by the IEX service of Allscripts.</para>
    /// </summary>
	public class FileSaveSettings : ConfigurationSection
	{
        		
		[ConfigurationProperty("imageWidth", DefaultValue=350, IsRequired = true)]
		public int ImageWidth {
			get {
				int result = 350;
				Object o = this["imageWidth"];
				if (o != null)
					result = (int) o;
				return result;
			}
			set {
				this["imageWidth"] = value;
			}
		}
		
		[ConfigurationProperty("imageHeight", DefaultValue=400, IsRequired = true)]
		public int ImageHeight {
			get {
				int result = 400;
				Object o = this["imageHeight"];
				if (o != null)
					result = (int) o;
				return result;
			}
			set {
				this["imageHeight"] = value;
			}
		}
		
		[ConfigurationProperty("fileNameFormat", DefaultValue="%mrn %folderNumber %yyyyMMdd %id", IsRequired = true)]
		public String FileNameFormat{
			get { return (String)this["fileNameFormat"]; }
			set { this["fileNameFormat"] = value; }
		}
		
		[ConfigurationProperty("iexPath", DefaultValue="C:/temp", IsRequired = true)]
		public String IexPath {
			get { return (String)this["iexPath"]; }
			set { this["iexPath"] = value; }
		}

		[ConfigurationProperty("folderNumber", DefaultValue=9, IsRequired = true)]
		public int FolderNumber {
			get {
				int result = 9;
				Object o = this["folderNumber"];
				if (o != null)
					result = (int) o;
				return result;
			}
			set { this["folderNumber"] = value; }
		}
	}
}
