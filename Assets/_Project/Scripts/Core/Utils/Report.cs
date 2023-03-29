using System;
using System.Collections;
using System.Text;
using UnityEngine;

namespace Dreihaus.Utils
{
    public class Report
    {
        private StringBuilder bob;

        public Report(string reportName)
        {
            bob = new StringBuilder();
            bob.AppendLine($"=== {reportName.ToUpper()} ===");
            Line();
        }

        public void Add(string line, int level = 0)
        {
            var tabs = "";
            if (level > 0)
            {
                for (int i = 0; i < level; i++)
                {
                    tabs += "\t";
                }
            }
            bob.AppendLine($"{tabs}{line}");
        }
        public void Line()
        {
            bob.AppendLine("-----------");
        }
        public void Space()
        {
            bob.AppendLine();
        }

        public void Print(LogCategory category = LogCategory.Core)
        {
            Logger.Log(category, bob.ToString());
        }
    }
}