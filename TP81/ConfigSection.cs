namespace License_Tems
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Collections;

    public class ConfigSection : List<ConfigItem>,IComparable<ConfigSection>
    {
        public const int DefaultSection = -1;
        int id ;
        private const byte SectionMark = 0xff;

        public ConfigSection() : this(-1)
        {
        }

        public ConfigSection(int id)
        {
            if (id < -1)
            {
                throw new ArgumentException();
            }
            this.id = id;
        }

        public int CompareTo(ConfigSection other)
        {
            return (this.Id - other.Id);
        }

        internal void WriteTo(BinaryWriter writer)
        {
            if ((id != -1) && (Count > 0))
            {
                writer.Write((byte) 0xff);
                ConfigItem.WriteEncodedInt(writer, id);
            }
        }

        public int Id
        {
            set 
            {
                this.Id = value;
            }
            get
            {
                return this.id;
            }
        }
    }
}

