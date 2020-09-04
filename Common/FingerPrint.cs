using System;
using System.Management;
using System.Security.Cryptography;
using System.Security;
using System.Collections;
using System.Text;
namespace ClassManager.Common
{
    /// <summary>
    /// Generates a 16 byte Unique Identification code of a computer
    /// Example: 4876-8DB5-EE85-69D3-FE52-8CF7-395D-2EA9
    /// </summary>
    public class FingerPrint
    {
        public static  DateTime appReleaseDate = new DateTime(2019, 09, 01);

        private static string fingerPrint = string.Empty;
        public static string Value()
        {
            if (string.IsNullOrEmpty(fingerPrint))
            {
                fingerPrint = GetHash("CPU >> " + cpuId() + "\nBIOS >> " + biosId() + "\nBASE >> " + baseId()
                    //+"\nDISK >> "+ diskId() + "\nVIDEO >> " + videoId() +"\nMAC >> "+ macId()
                                     );
            }
            return fingerPrint;
        }
        private static string GetHash(string s)
        {
            MD5 sec = new MD5CryptoServiceProvider();
            ASCIIEncoding enc = new ASCIIEncoding();
            byte[] bt = enc.GetBytes(s);
            return GetHexString(sec.ComputeHash(bt)).Substring(0, 19);
        }
        private static string GetHexString(byte[] bt)
        {
            string s = string.Empty;
            for (int i = 0; i < bt.Length; i++)
            {
                byte b = bt[i];
                int n, n1, n2;
                n = (int)b;
                n1 = n & 15;
                n2 = (n >> 4) & 15;
                if (n2 > 9)
                    s += ((char)(n2 - 10 + (int)'A')).ToString();
                else
                    s += n2.ToString();
                if (n1 > 9)
                    s += ((char)(n1 - 10 + (int)'A')).ToString();
                else
                    s += n1.ToString();
                if ((i + 1) != bt.Length && (i + 1) % 2 == 0) s += "-";
            }
            return s;
        }
        #region Original Device ID Getting Code
        //Return a hardware identifier
        private static string identifier(string wmiClass, string wmiProperty, string wmiMustBeTrue)
        {
            string result = "";
            System.Management.ManagementClass mc = new System.Management.ManagementClass(wmiClass);
            System.Management.ManagementObjectCollection moc = mc.GetInstances();
            foreach (System.Management.ManagementObject mo in moc)
            {
                if (mo[wmiMustBeTrue].ToString() == "True")
                {
                    //Only get the first one
                    if (result == "")
                    {
                        try
                        {
                            result = mo[wmiProperty].ToString();
                            break;
                        }
                        catch
                        {
                        }
                    }
                }
            }
            return result;
        }
        //Return a hardware identifier
        private static string identifier(string wmiClass, string wmiProperty)
        {
            string result = "";
            System.Management.ManagementClass mc = new System.Management.ManagementClass(wmiClass);
            System.Management.ManagementObjectCollection moc = mc.GetInstances();
            foreach (System.Management.ManagementObject mo in moc)
            {
                //Only get the first one
                if (result == "")
                {
                    try
                    {
                        result = mo[wmiProperty].ToString();
                        break;
                    }
                    catch
                    {
                    }
                }
            }
            return result;
        }
        private static string cpuId()
        {
            //Uses first CPU identifier available in order of preference
            //Don't get all identifiers, as very time consuming
            string retVal = identifier("Win32_Processor", "UniqueId");
            if (retVal == "") //If no UniqueID, use ProcessorID
            {
                retVal = identifier("Win32_Processor", "ProcessorId");
                if (retVal == "") //If no ProcessorId, use Name
                {
                    retVal = identifier("Win32_Processor", "Name");
                    if (retVal == "") //If no Name, use Manufacturer
                    {
                        retVal = identifier("Win32_Processor", "Manufacturer");
                    }
                    //Add clock speed for extra security
                    retVal += identifier("Win32_Processor", "MaxClockSpeed");
                }
            }
            return retVal;
        }
        //BIOS Identifier
        private static string biosId()
        {
            return identifier("Win32_BIOS", "Manufacturer")
            + identifier("Win32_BIOS", "SMBIOSBIOSVersion")
            + identifier("Win32_BIOS", "IdentificationCode")
            + identifier("Win32_BIOS", "SerialNumber")
            + identifier("Win32_BIOS", "ReleaseDate")
            + identifier("Win32_BIOS", "Version");
        }
        //Main physical hard drive ID
        private static string diskId()
        {
            return identifier("Win32_DiskDrive", "Model")
            + identifier("Win32_DiskDrive", "Manufacturer")
            + identifier("Win32_DiskDrive", "Signature")
            + identifier("Win32_DiskDrive", "TotalHeads");
        }
        //Motherboard ID
        private static string baseId()
        {
            return identifier("Win32_BaseBoard", "Model")
            + identifier("Win32_BaseBoard", "Manufacturer")
            + identifier("Win32_BaseBoard", "Name")
            + identifier("Win32_BaseBoard", "SerialNumber");
        }
        //Primary video controller ID
        private static string videoId()
        {
            return identifier("Win32_VideoController", "DriverVersion")
            + identifier("Win32_VideoController", "Name");
        }
        //First enabled network card ID
        private static string macId()
        {
            return identifier("Win32_NetworkAdapterConfiguration", "MACAddress", "IPEnabled");
        }
        #endregion

        public static string getKey(string serial, string customerContactNo)
        {
            return serial + "MVC";
        }

        public static string generateMD5(String password)
        {   

            // byte array representation of that string
            byte[] encodedPassword = new UTF8Encoding().GetBytes(password);

            // need MD5 to calculate the hash
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);

            // string representation (similar to UNIX format)
            string encoded = BitConverter.ToString(hash)
                // without dashes
                .Replace("-", string.Empty)
                // make lowercase
               .ToLower();

            // encoded contains the hash you are wanting
            return encoded;

        }

        public static string generateLicenceKey(string serialKey, string contactNo,DateTime expiryDate)
        {
            string licenceKey =  generateMD5(serialKey + contactNo).Substring(0,6);            
            licenceKey = licenceKey.Substring(0, 2) + expiryDate.ToString("MM") + licenceKey.Substring(2, 2) + expiryDate.Year.ToString().Substring(2, 2) + licenceKey.Substring(4, 2);
            return licenceKey;
        }

        public static string validateLicence(string serialKey, string contactNo, string licenceKey)
        {
            string licenceHash = licenceKey.Substring(0, 2) + licenceKey.Substring(4, 2) +  licenceKey.Substring(8, 2);
            
            if (generateMD5(serialKey + contactNo).Substring(0, 6).Equals(licenceHash))
            {
                int expiaryMonth = Convert.ToInt32(licenceKey.Substring(2, 2));
                int expiaryYear = Convert.ToInt32(licenceKey.Substring(6, 2));

               
                if (expiaryYear > DateTime.Now.Year || (expiaryYear == Convert.ToInt32(DateTime.Now.Year.ToString().Substring(2,2)) && expiaryMonth >= DateTime.Now.Month))
                {
                    return "V";
                }
                else
                {
                    return "E";
                }
            }
            else
            {
                return "I";
            }
        }


        public static string  validateLicence(string contactNo, string licenceKey, out int noOfMonthsForExpiry)
        {
            noOfMonthsForExpiry = 0;
            try
            {
                string licenceHash = licenceKey.Substring(0, 2) + licenceKey.Substring(4, 2) + licenceKey.Substring(8, 2) + licenceKey.Substring(12, 2);
                noOfMonthsForExpiry = 0;

                if (generateMD5(Value() + contactNo).Substring(0, 6).Equals(licenceHash.Substring(0, 6)))
                {
                    int expiryMonth = Convert.ToInt32(licenceKey.Substring(2, 2));
                    int expiryYear = Convert.ToInt32(licenceKey.Substring(6, 2));
                    int expiryDay = Convert.ToInt32(licenceKey.Substring(10, 2));

                    DateTime expiryDate = new DateTime(Convert.ToInt32("20" + expiryYear.ToString()), expiryMonth, expiryDay);
                    noOfMonthsForExpiry = expiryDate.Date.Subtract(DateTime.Now).Days;

                    if (expiryDate >= DateTime.Now)
                    {
                        return "V";
                    }
                    else
                    {
                        return "E";
                    }
                }
                else
                {
                    return "I";
                }
            }
            catch (Exception ex)
            {
                Log.LogError(ex, "FingerPrint.validateLicence");
                return "I";
            }
        }
    }
}
