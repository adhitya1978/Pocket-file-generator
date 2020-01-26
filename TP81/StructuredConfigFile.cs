namespace License_Tems
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Collections;

    public abstract class StructuredConfigFile 
    {
        private const int CurrentTlvVersion = 0;
        private IConfigItemFactory factory;
        private const int FileMagic = 0x51;
      
        
      
        protected StructuredConfigFile()
        {
        }

        protected virtual IConfigItemFactory CreateFactory()
        {
            return new StructuredConfigItemFactory();
        }

        public virtual void Load(Stream input)
        {
            ConfigItem item;
            BinaryReader reader = new BinaryReader(input, Encoding.Unicode);
            int num = reader.PeekChar() & 0xff;
            int tlvVersion = -1;
            int contentVersion = -1;
            if (num == 0x51)
            {
                reader.ReadByte();
                tlvVersion = reader.ReadByte();
                if (tlvVersion > 0)
                {
                    throw new NotSupportedException("Newer TLV version.");
                }
                if (reader.ReadByte() != this.ContentId)
                {
                    throw new NotSupportedException("Wrong content ID.");
                }
                contentVersion = reader.ReadByte();
                if (contentVersion > this.ContentVersion)
                {
                    throw new NotSupportedException("Newer content version.");
                }
            }
            List<ConfigSection> sections = new List<ConfigSection>();
            IConfigItemFactory factory = this.Factory;
            ConfigSection currentSection = null;
            ConfigSection section2 = null;
            while ((item = factory.ReadItem(reader, tlvVersion, contentVersion, ref currentSection)) != null)
            {
                if (currentSection == null)
                {
                    currentSection = new ConfigSection();
                }
                if (section2 != currentSection)
                {
                    section2 = currentSection;
                    sections.Add(currentSection);
                }
                currentSection.Add(item);
            }
            this.LoadFromList(sections, contentVersion);
        }


        public virtual void Load(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))
            {
                this.Load(stream);
            }
        }

        public abstract void LoadFromList(IEnumerable<ConfigSection> sections, int version);

        /*Generate License*/
        public virtual void Save(Stream output)
        {
            BinaryWriter writer = new BinaryWriter(output, Encoding.ASCII);            
            writer.Write((byte) 0x51);
            writer.Write((byte) 0);
            writer.Write((byte) ContentId);
            writer.Write((byte) ContentVersion);
            foreach (ConfigSection cs in SaveToList())
            {                
                cs.WriteTo(writer);
                foreach (ConfigItem Ci in cs)
                {
                    Ci.WriteTo(writer);
 
                }
            }
            writer.Flush();
        }


        protected abstract  IEnumerable<ConfigSection> SaveToList();       
        public abstract void create(IEnumerable<ConfigSection> Section);
        public virtual void Save(string filename)
        {
            using (FileStream stream = File.Create(filename))
            {
                Save(stream);
            }
        }

       
        public abstract int ContentId { get; }

        public abstract int ContentVersion { get; }
       

        protected IConfigItemFactory Factory
        {
            get
            {
                if (this.factory == null)
                {
                    this.factory = this.CreateFactory();
                }
                return this.factory;
            }
        }
    }
}

