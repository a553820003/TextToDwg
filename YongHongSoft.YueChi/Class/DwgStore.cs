using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace YongHongSoft.YueChi
{
    [XmlRoot("dwgStore")]
    public class DwgStore
    {
        static string file = Application.StartupPath + "\\PosOfField.xml";
        public DwgStore() 
        {
            Dwg = new List<Dwg>();
        }
        [XmlElement("dwg")]
        public List<Dwg> Dwg { get; set; }
        public DwgStore Load()
        {
            return XmlHelper.Load(typeof(DwgStore), file) as DwgStore;
        }
    }
    public class Dwg
    {
        public Dwg()
        {
            Label = new List<Label>();
        }
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("fontheight")]
        public string FontHeight { get; set; }
        [XmlElement("label")]
        public List<Label> Label { get; set; }
    }
    public class Label 
    {
        [XmlAttribute("x")]
        public string X { get; set; }
        [XmlAttribute("y")]
        public string Y { get; set; }
        [XmlAttribute]
        public string Field { get; set; }
        public string Text { get; set; }
    }
}
