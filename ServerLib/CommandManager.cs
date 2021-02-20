using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{

    public class CommandManager
    {
        public static void CommandLine(string line)
        {
            ProcessStartInfo cmd = new ProcessStartInfo(@"cmd.exe", @"/C " + line);
            // скрываем окно запущенного процесса
            cmd.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.RedirectStandardOutput = true;
            cmd.UseShellExecute = false;
            cmd.CreateNoWindow = true;
            // запускаем процесс
            Process procCommand = Process.Start(cmd);
        }
    }
}
