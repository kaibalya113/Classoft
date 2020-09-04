using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Mail;
using System.Threading;

namespace ClassManager.Common
{
    public class Log
    {
        static StreamWriter Stream;
        public static String Client;
        public static string DateString;

        static Log()
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\Logs"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\Logs");
            }

            DateString = DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
        }

        public static bool LogError(String message, ErrorLevel errorLevel,Exception ex=null)
        {
            StreamWriter Stream = null;
            try
            {
                String logpath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "Logs\\ApplicationError" + DateString + ".log";
                Stream = new StreamWriter(logpath, true);


                Stream.WriteLine("\n\n-----------------------------------------------------------------------------------------------\n");
                Stream.WriteLine("Log Created At:" + DateTime.Now.ToString());
                Stream.WriteLine("\nApplication Error");
                Stream.WriteLine((ex==null)?"":ex.ToString());
                Stream.WriteLine("\n\nStack Strace Started\n\n");
                Stream.WriteLine((ex==null)?"":ex.StackTrace.ToString());
                Stream.WriteLine("\n\nEnd Of Stack Trace\n\n");
                Stream.WriteLine("\nSeverty :" + errorLevel.ToString());
                Stream.WriteLine(message);
                Stream.WriteLine("\n\n-----------------------------------------------------------------------------------------------\n");

                Stream.Close();

               if (errorLevel != ErrorLevel.INFORMATION)
               {
                    NotifySupport(new Exception(message));
                }
                return true;
            }
            catch (Exception e)
            {
                throw ex;
               // return false;
            }
            finally
            {
                if (Stream != null)
                {
                    Stream.Clone();
                }
            }
        }

        private static void NotifySupport(Exception ex)
        {
            try
            {

               Thread webRequestThread = new Thread(delegate ()
               {
                   try
                   {
                       System.Net.WebClient webClient = new System.Net.WebClient();
                       webClient.DownloadString("http://accunityservices.com/app/clientreporting/handleSupport.php?application=classmanager&client=" + Log.Client + "&error=" + ex.Message + "&error_desc=" + ex.StackTrace ?? ex.Message);
                   }
                   catch (Exception)
                   {

                   }

               });
                webRequestThread.Start();

            }
            catch (Exception)
            {
            }
        }

        public static bool LogError(Exception Ex, string source = "")
        {
            StreamWriter Stream = null;
            try
            {
                String logpath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "Logs\\ApplicationError" + DateString + ".log";
                Stream = new StreamWriter(logpath, true);


                Stream.WriteLine("\n\n-----------------------------------------------------------------------------------------------\n");
                Stream.WriteLine("Log Created At:" + DateTime.Now.ToString());
                Stream.WriteLine("\nApplication Error");
                Stream.WriteLine("\nFrom :" + ((source == "") ? Ex.Source.ToString() : source));
                Stream.WriteLine(Ex.Message);
                Stream.WriteLine("\n\nStack Strace Started\n\n");
                Stream.WriteLine(Ex.StackTrace.ToString());
                Stream.WriteLine("\n\nEnd Of Stack Trace\n\n");
                Stream.WriteLine("\n\n-----------------------------------------------------------------------------------------------\n");

                Stream.Close();
                NotifySupport(Ex);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                if (Stream != null)
                {
                    Stream.Close();
                }
            }
        }

        public static bool LogDBError(Exception Ex, string Source)
        {
            StreamWriter Stream = null;
            try
            {
                String logpath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "Logs\\Database" + DateString + ".log";
                Stream = new StreamWriter(logpath, true);


                Stream.WriteLine("\n\n-----------------------------------------------------------------------------------------------\n");
                Stream.WriteLine("Log Created At:" + DateTime.Now.ToString());
                Stream.WriteLine("\nApplication Error");
                Stream.WriteLine("\nFrom :" + Source);
                Stream.WriteLine(Ex.Message);
                Stream.WriteLine("\n\nStack Strace Started\n\n");
                Stream.WriteLine(Ex.StackTrace.ToString());
                Stream.WriteLine("\n\nEnd Of Stack Trace\n\n");
                Stream.WriteLine("\n\n-----------------------------------------------------------------------------------------------\n");

                Stream.Close();

                NotifySupport(Ex);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                if (Stream != null)
                {
                    Stream.Close();
                }
            }
        }

        public static bool LogError(Log.Level logLevel, string dataSource, string fileName = "ApplicationError")
        {
            StreamWriter Stream = null;
            try
            {
                String logpath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "Logs\\" + fileName + DateString + ".log";
                Stream = new StreamWriter(logpath, true);


                Stream.WriteLine("\n\n-----------------------------------------------------------------------------------------------\n");
                Stream.WriteLine("Log Created At:" + DateTime.Now.ToString());
                Stream.WriteLine("\n" + logLevel.ToString());
                Stream.WriteLine(dataSource);
                Stream.WriteLine("\n\n-----------------------------------------------------------------------------------------------\n");

                Stream.Close();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                if (Stream != null)
                {
                    Stream.Close();
                }
            }
        }

        public enum Level
        {
            INFORMATION, ERROR, FATAL
        }

        public enum LogType
        {
            SYNC
        }

        public static StreamWriter getLogger(LogType logEvent)
        {
            try
            {
                String logpath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "Logs\\" + logEvent.ToString() + DateString + ".log";
                return new StreamWriter(logpath, true);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
