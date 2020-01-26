namespace License_Tems
{
    using System;
    using System.IO;
    using System.Text;

    public class ConfigItem : IComparable<ConfigItem>
    {
        private byte[] data;
        public static readonly DateTime MAX_DATE = new DateTime(0xbb8, 12, 0x1f);
        public static readonly DateTime MIN_DATE = new DateTime(0x7d0, 1, 1);
        private const long PC_TO_SYMBIAN_TIME_DIFF = 0x1db41003c000L;
        private const long SYMBIAN_TO_PC_TIME_FACTOR = 10L;
        private int tag;

        protected ConfigItem(int tag)
        {
            this.tag = tag;
        }

        public ConfigItem(int tag, bool value) : this(tag)
        {
            this.BoolValue = value;
        }

        public ConfigItem(int tag, byte[] value) : this(tag)
        {
            this.RawValue = value;
        }

        public ConfigItem(int tag, DateTime value) : this(tag)
        {
            this.DateTimeValue = value;
        }

        public ConfigItem(int tag, int value) : this(tag)
        {
            this.IntegerValue = value;
        }

        public ConfigItem(int tag, float value) : this(tag)
        {
            this.FloatValue = value;
        }

        public ConfigItem(int tag, string value) : this(tag)
        {
            this.StringValue = value;
        }

        public ConfigItem(int tag, Version value) : this(tag)
        {
            this.VersionValue = value;
        }

        protected internal ConfigItem(BinaryReader reader, int tlvVersion)
        {
            int num;
            if (tlvVersion == -1)
            {
                this.tag = reader.ReadByte() & 15;
                num = reader.ReadByte();
            }
            else
            {
                if (tlvVersion != 0)
                {
                    throw new NotSupportedException("TLV version not supported");
                }
                this.tag = ReadEncodedInt(reader);
                num = ReadEncodedInt(reader);
            }
            this.data = new byte[num];
            if (reader.Read(this.data, 0, num) != num)
            {
                throw new EndOfStreamException();
            }
        }

        public void CheckVersion(Version min, Version max)
        {
            Version versionValue = this.VersionValue;
            if (versionValue < min)
            {
                throw new ArgumentException(string.Format("File version ({0}) must be at least {1}.", versionValue, min));
            }
            if (versionValue > max)
            {
                throw new ArgumentException(string.Format("Current version {0} does not support file version {1}.", max, versionValue));
            }
        }

        public int CompareTo(ConfigItem other)
        {
            return (this.Tag - other.Tag);
        }

        protected internal static int ReadEncodedInt(BinaryReader reader)
        {
            byte num2;
            int num = 0;
            do
            {
                num = num << 7;
                num2 = reader.ReadByte();
                num |= num2 & 0x7f;
            }
            while ((num2 & 0x80) != 0);
            return num;
        }

        protected internal static void WriteEncodedInt(BinaryWriter writer, int value)
        {
            if (value < 0x80)
            {
                writer.Write((byte) value);
            }
            else if (value < 0x4000)
            {
                writer.Write((byte) ((value >> 7) | 0x80));
                writer.Write((byte) (value & 0x7f));
            }
            else if (value < 0x100000)
            {
                writer.Write((byte) ((value >> 14) | 0x80));
                writer.Write((byte) ((value >> 7) | 0x80));
                writer.Write((byte) (value & 0x7f));
            }
            else if (value < 0x8000000)
            {
                writer.Write((byte) ((value >> 0x15) | 0x80));
                writer.Write((byte) ((value >> 14) | 0x80));
                writer.Write((byte) ((value >> 7) | 0x80));
                writer.Write((byte) (value & 0x7f));
            }
            else
            {
                writer.Write((byte) ((value >> 0x1c) | 0x80));
                writer.Write((byte) ((value >> 0x15) | 0x80));
                writer.Write((byte) ((value >> 14) | 0x80));
                writer.Write((byte) ((value >> 7) | 0x80));
                writer.Write((byte) (value & 0x7f));
            }
        }

        internal void WriteTo(BinaryWriter writer)
        {
            WriteEncodedInt(writer, this.tag);
            WriteEncodedInt(writer, this.data.Length);
            writer.Write(this.data);
        }

        // property
        public bool BoolValue
        {
            get
            {
                return (this.data[0] != 0);
            }
            set
            {
                this.data = new byte[] { value ? ((byte) 1) : ((byte) 0) };
            }
        }

        public DateTime DateTimeValue
        {
            get
            {
                long ticks = (BitConverter.ToInt64(this.data, 0) - 0x1db41003c000L) * 10L;
                if ((ticks < 0L) || (ticks > MAX_DATE.Ticks))
                {
                    this.DateTimeValue = MAX_DATE;
                    return MAX_DATE;
                }
                if (ticks < MIN_DATE.Ticks)
                {
                    this.DateTimeValue = MIN_DATE;
                    return MIN_DATE;
                }
                return new DateTime(ticks);
            }
            set
            {
                this.data = BitConverter.GetBytes((long) ((value.Ticks / 10L) + 0x1db41003c000L));
            }
        }

        public float FloatValue
        {
            get
            {
                return BitConverter.ToSingle(this.data, 0);
            }
            private set
            {
                this.data = BitConverter.GetBytes(value);
            }
        }

        public int IntegerValue
        {
            get
            {
                switch (this.data.Length)
                {
                    case 1:
                        return this.data[0];

                    case 2:
                        return BitConverter.ToUInt16(this.data, 0);

                    case 4:
                        return BitConverter.ToInt32(this.data, 0);
                }
                throw new NotSupportedException("Value is not an integer.");
            }
             set
            {
                if ((value > 0xffff) || (value < 0))
                {
                    this.data = BitConverter.GetBytes(value);
                }
                else if (value <= 0xff)
                {
                    this.data = new byte[] { (byte) value };
                }
                else
                {
                    this.data = BitConverter.GetBytes((ushort) value);
                }
            }
        }

        public byte[] RawValue
        {
            get
            {
                return this.data;
            }
             set
            {
                this.data = value;
            }
        }

        public string StringValue
        {
            get
            {
                return Encoding.UTF8.GetString(this.data, 0, this.data.Length);
            }
            set
            {
                this.data = Encoding.UTF8.GetBytes(value ?? string.Empty);
            }
        }

        public int Tag
        {
            get
            {
                return this.tag;
            }
            set
            {
                this.tag = value;
            }
        }

        public Version VersionValue
        {
            get
            {
                int integerValue = this.IntegerValue;
                return new Version(1 + (integerValue >> 12), (integerValue >> 8) & 15, (integerValue >> 4) & 15, integerValue & 15);
            }
             set
            {
                this.IntegerValue = (((((value.Major - 1) & 0xff) << 12) | ((value.Minor & 0xff) << 8)) | ((value.Build & 0xff) << 4)) | (value.Revision & 0xff);
            }
        }
    }
}

