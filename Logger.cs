using System;
using System.IO;

namespace KVSV.Debug {
    public static class Logger {
        public static void Log(string msg) {
            InternalLog("[" + DateTime.Now.ToString("MM DD YY HH mm ss") + "] " + msg);
        }

        public static void LogWarn(string msg) {
            InternalLog("[" + DateTime.Now.ToString("MM DD YY HH mm ss") + "] WARNING: " + msg);
        }

        public static void LogError(string msg) {
            InternalLog("[" + DateTime.Now.ToString("MM DD YY HH mm ss") + "] ERROR: " + msg);
        }

        private static  void InternalLog(string logString) {
            DirectoryInfo logsDir = Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\" + "logs");
            string logPath = logsDir.FullName + "\\" + DateTime.Now.ToString("[MM DD YY HH mm ss]") + " debug.log";

            try {
                logString = File.ReadAllText(logPath) + logString;
            }
            catch(FileNotFoundException) {
                
            }
            catch(DirectoryNotFoundException) {
                
            }
            File.WriteAllText(logPath, logString);
        }
    }
}