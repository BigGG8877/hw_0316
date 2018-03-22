using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Xml_anal1
{
    class Program
    {
        public class AirQ
        {
            public string Air_aera { get; set; }
            public string Amp { get; set; }
            public string AQI { get; set; }
            public string Date { get; set; }
        }

        public static List<AirQ> FindData()
        {
            List<AirQ> aa = new List<AirQ>();
            XElement xml_f = XElement.Load(@"E:\4de41cfc86973534afc48336a84efa05_export.xml");
            List<XElement> node = xml_f.Descendants("row").ToList();

            node.ForEach(x => {
                AirQ bb = new AirQ();
                bb.Air_aera = x.Element("Col2").Value;
                bb.Amp = x.Element("Col3").Value;
                bb.AQI = x.Element("Col4").Value;
                bb.Date = x.Element("Col5").Value;
                aa.Add(bb);
            });
            return aa;
        }

        public static void ShowData(List<AirQ> qq)
        {
            qq.ForEach(x =>
            {
                Console.WriteLine("地區:" + x.Air_aera);
                Console.WriteLine("主要汙染:" + x.Amp);
                Console.WriteLine("AQI值:" + x.AQI);
                Console.WriteLine("預測日期:" + x.Date);
                Console.WriteLine("----------------------------");
            });


        }

        static void Main(string[] args)
        {
            ShowData(FindData());
            Console.Read();
        }


    }
}
