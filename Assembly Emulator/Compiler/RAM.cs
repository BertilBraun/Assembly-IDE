namespace Assembly_Emulator
{
    class Memory
    {
        public byte[] data;

        public Memory(int size)
        {
            data = new byte[size];
        }

        public byte Byte(int address)
        {
            if (address % 8 != 0)
            {
                DockingManagerForm.This.AddError("Byte Address: " + address + ", must be a multiple of 8");
                return 0;
            }
            else
                return data[address / 8];
        }
        public void Byte(int address, byte data)
        {
            if (address % 8 != 0)
                DockingManagerForm.This.AddError("Byte Address: " + address + ", must be a multiple of 8");
            else
                this.data[address / 8] = data;
        }

        public byte Bit(int address)
        {
            return (data[address / 8] & (1 << (address % 8))) != 0 ? (byte)1 : (byte)0;
        }
        public void Bit(int address, int set)
        {
            if (set != 0)
                data[address / 8] |= (byte)(1 << ((byte)address % 8));
            else
                data[address / 8] &= (byte)~(1 << ((byte)address % 8));
        }
        public void Bit(int address, bool set)
        {
            if (set)
                data[address / 8] |= (byte)(1 << ((byte)address % 8));
            else
                data[address / 8] &= (byte)~(1 << ((byte)address % 8));
        }
        public void Set(int address)
        {
            Bit(address, true);
        }
        public void Clr(int address)
        {
            Bit(address, false);
        }

        public void Byte(int address, int data)
        {
            Byte(address, (byte)data);
        }
    }
}
