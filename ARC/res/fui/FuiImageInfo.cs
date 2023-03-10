using System.Collections.Generic;

namespace FuiEditor
{
    class FuiImageInfo
    {
        public static readonly int NativeSize = 32;

        private int descriptor;
        private int attribute;
        private int imageWidth;
        private int imageHeight;
        private int imageOffset;
        private int imageSize;
        private int unkOffset;
        private int unk_0x1C;

        public FuiImageInfo()
        {

        }

        public void Read(byte[] filedata, int startIndex)
        {
            descriptor = FuiEditor.Data.FJUI.FuiUtils.ToInt32(filedata, startIndex + 0);
            attribute = FuiEditor.Data.FJUI.FuiUtils.ToInt32(filedata, startIndex + 4);
            imageWidth = FuiEditor.Data.FJUI.FuiUtils.ToInt32(filedata, startIndex + 8);
            imageHeight = FuiEditor.Data.FJUI.FuiUtils.ToInt32(filedata, startIndex + 12);
            imageOffset = FuiEditor.Data.FJUI.FuiUtils.ToInt32(filedata, startIndex + 16);
            imageSize = FuiEditor.Data.FJUI.FuiUtils.ToInt32(filedata, startIndex + 20);
            unkOffset = FuiEditor.Data.FJUI.FuiUtils.ToInt32(filedata, startIndex + 24);
            unk_0x1C = FuiEditor.Data.FJUI.FuiUtils.ToInt32(filedata, startIndex + 28);
        }

        public byte[] ToByteArray()
        {
            List<byte> byteList = new List<byte>();

            byteList.AddRange(FuiEditor.Data.FJUI.FuiUtils.GetBytes(descriptor));
            byteList.AddRange(FuiEditor.Data.FJUI.FuiUtils.GetBytes(attribute));
            byteList.AddRange(FuiEditor.Data.FJUI.FuiUtils.GetBytes(imageWidth));
            byteList.AddRange(FuiEditor.Data.FJUI.FuiUtils.GetBytes(imageHeight));
            byteList.AddRange(FuiEditor.Data.FJUI.FuiUtils.GetBytes(imageOffset));
            byteList.AddRange(FuiEditor.Data.FJUI.FuiUtils.GetBytes(ImageSize));
            byteList.AddRange(FuiEditor.Data.FJUI.FuiUtils.GetBytes(unkOffset));
            byteList.AddRange(FuiEditor.Data.FJUI.FuiUtils.GetBytes(unk_0x1C));

            return byteList.ToArray();
        }

        public int ImageOffset
        {
            get => imageOffset;
            set => imageOffset = value;
        }

        public int ImageSize
        {
            get => imageSize;
            set => imageSize = value;
        }

        public int Width
        {
            get => imageWidth;
            set => imageWidth = value;
        }

        public int Height
        {
            get => imageHeight;
            set => imageHeight = value;
        }

        public int Descriptor
        {
            get => descriptor;
            set => descriptor = value;
        }

        public int Attribute
        {
            get => attribute;
            set => attribute = value;
        }
    }
}
