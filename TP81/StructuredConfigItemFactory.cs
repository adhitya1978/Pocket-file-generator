namespace License_Tems
{
    using System;
    using System.IO;

    public class StructuredConfigItemFactory : UnstructuredConfigItemFactory
    {
        public override ConfigItem ReadItem(BinaryReader reader, int tlvVersion, int contentVersion, ref ConfigSection currentSection)
        {
            int num = reader.PeekChar();
            if (num < 0)
            {
                return null;
            }
            num &= 0xff;
            if (tlvVersion == -1)
            {
                int section = num >> 4;
                if (((currentSection == null) || (currentSection.Id != section)) || ((num & 15) == 0))
                {
                    currentSection = this.CreateSection(section);
                }
            }
            else
            {
                if (tlvVersion != 0)
                {
                    throw new NotSupportedException("TLV version not supported");
                }
                while (num == 0xff)
                {
                    reader.ReadByte();
                    int num3 = ConfigItem.ReadEncodedInt(reader);
                    currentSection = this.CreateSection(num3);
                    num = reader.PeekChar();
                    if (num < 0)
                    {
                        return null;
                    }
                    num &= 0xff;
                }
            }
            return this.ReadItem(reader, tlvVersion, contentVersion);
        }
    }
}

