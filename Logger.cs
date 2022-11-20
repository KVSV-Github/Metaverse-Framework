using System;
using System.IO;

namespace KVSV.Debug {
    public static class Logger {
        public static void Log(string msg) {
            InternalLog("[" + DateTime.Now + "] " + msg);
        }

        public static void LogWarn(string msg) {
            InternalLog("[" + DateTime.Now + "] WARNING: " + msg);
        }

        public static void LogError(string msg) {
            InternalLog("[" + DateTime.Now + "] ERROR: " + msg);
        }

        private static  void InternalLog(string logString) {
            DirectoryInfo logsDir = Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\" + "logs");
            string logPath = logsDir.FullName + "\\" + "[" + DateTime.Now + "] debug.log";

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