namespace License_Tems
{
    using System;
    using System.IO;

    public interface IConfigItemFactory
    {
        ConfigItem ReadItem(BinaryReader reader, int tlvVersion, int contentVersion, ref ConfigSection currentSection);
    }
}

