namespace License_Tems
{
    using System;
    using System.IO;

    public class UnstructuredConfigItemFactory : IConfigItemFactory
    {
        protected virtual ConfigSection CreateSection(int section)
        {
            return new ConfigSection(section);
        }

        protected virtual ConfigItem ReadItem(BinaryReader reader, int tlvVersion, int contentVersion)
        {
            return new ConfigItem(reader, tlvVersion);
        }

        public virtual ConfigItem ReadItem(BinaryReader reader, int tlvVersion, int contentVersion, ref ConfigSection currentSection)
        {
            if (reader.PeekChar() < 0)
            {
                return null;
            }
            return this.ReadItem(reader, tlvVersion, contentVersion);
        }
    }
}

