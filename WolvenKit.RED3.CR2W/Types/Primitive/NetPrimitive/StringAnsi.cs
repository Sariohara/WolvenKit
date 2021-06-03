using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using WolvenKit.RED3.CR2W.Reflection;
using WolvenKit.Common.Model.Cr2w;
using WolvenKit.Core.Extensions;

namespace WolvenKit.RED3.CR2W.Types
{
    [REDMeta()]
    public class StringAnsi : CVariable
    {


        public StringAnsi(IRed3EngineFile cr2w, CVariable parent, string name) : base(cr2w, parent, name)
        {
        }

        public string val { get; set; }

        public override void Read(BinaryReader file, uint size)
        {
            val = file.ReadLengthPrefixedStringNullTerminated();
        }

        public override void Write(BinaryWriter file)
        {
            file.WriteLengthPrefixedStringNullTerminated(val);
        }

        public override CVariable SetValue(object val)
        {
            this.IsSerialized = true;
            if (val is string)
            {
                this.val = (string) val;
            }
            else if (val is StringAnsi cvar)
            {
                this.val = cvar.val;
            }
            return this;
        }

        public override CVariable Copy(ICR2WCopyAction context)
        {
            var var = (StringAnsi) base.Copy(context);
            var.val = val;
            return var;
        }



        public override string ToString()
        {
            return val;
        }
        //public override void SerializeToXml(XmlWriter xw)
        //{
        //    DataContractSerializer ser = new DataContractSerializer(this.GetType());
        //    using (var ms = new MemoryStream())
        //    {
        //        ser.WriteStartObject(xw, this);
        //        ser.WriteObjectContent(xw, this);
        //        xw.WriteElementString("val", this.val.Replace("\x00", ""));
        //        ser.WriteEndObject(xw);
        //    }
        //}
    }
}
