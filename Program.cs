using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using RiskSystems.Objects.Services;
using RiskFirstTest.Domain.Entites;
using System.Configuration;

namespace RiskSystems
{
    class Program
    {
        public static List<string> ReadPortifolio(string inputFile)
        {            
            List<string> lines = new List<string>();
            using (StreamReader reader = File.OpenText(inputFile))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            } 
            return lines;
        }
        static void Main()
        {
            string filePath = ConfigurationManager.AppSettings["filePath"]??"";
            var portifolioService = new PortfolioService();
            var linesPortifolio = ReadPortifolio(filePath);
            var portifolio =  portifolioService.CreatePotifolio(linesPortifolio);
            foreach (Trade trade in portifolio.Trades)
            {
                Console.WriteLine(trade.Category.ToString());
            }
            Console.ReadLine();
        }
    }
}