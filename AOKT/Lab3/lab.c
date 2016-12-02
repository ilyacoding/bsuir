#include <stdio.h>
#include <sys/io.h>
#include "pci.h"

void printVendor(unsigned short int data[2])
{
	int i = 0;
	for (i; i < PCI_VENTABLE_LEN; i++)
	{
		if (PciVenTable[i].VendorId == data[0])
		{
        		printf("-> Vendor ID: %x", data[0]);
			printf("  %s\n", PciVenTable[i].VendorName);
		}
	}
}


void printDevice(unsigned short int data[2])
{
	int i = 0;
	for (i; i < PCI_DEVTABLE_LEN; i++)
	{
		if (PciDevTable[i].VendorId == data[0])
		{
			if (PciDevTable[i].DeviceId == data[1])
			{
				printf("-> Device ID: %x", data[1]);
				printf("  %s\n", PciDevTable[i].DeviceName);
			}
		}
	}
}

union Converter {
   unsigned int int32;
   unsigned short int16[2];
   unsigned char int8[4];
} conv;

void printDevVen(unsigned int *dataDevVen)
{
	unsigned short int *data;
	data = (unsigned short int*) dataDevVen;
	printVendor(data);
	printDevice(data);
}

void printBars(unsigned int address)
{
    unsigned int data, reg;
    for (reg = 0x10; reg < 0x28; reg += 0x04)
    {
        outl(address + reg, 0xCF8);
        data = inl(0xCFC);
        if (data != 0)
        {
            printf("---\n");
            printf("BAR %d: %x\n", (reg - 0x10)/4, data);
            if (!(data & 0x01))
            {
                printf("- Memory (0bit = 0)\n");
                if ((data & 0x06) == 0x06)
                {
                    printf("- Type: reserved (11)\n");
                }
                else if ((data & 0x06) == 0x02)
                {
                    printf("- Type: Lower 1MB (01)\n");
                }
                else if ((data & 0x06) == 0x04)
                {
                    printf("- Type: Any 64-bit address space (10)\n");
                }
                else if ((data & 0x06) == 0x00)
                {
                    printf("- Type: Any 32-bit address space (00)\n");
                }
                if ((data & 0x08) == 0x08)
                {
                    printf("- Prefetchable: 1\n");
                }
                else {
                    printf("- Prefetchable: 0\n");
                }
                data = (data >> 4);
                printf("- Base Address: %x\n", data);
            } else
            {
                printf("- Port (0bit = 1)\n");
                if ((data & 0x02) == 0x02)
                {
                    printf("- Reserved: 1\n");
                }
                else {
                    printf("- Reserved: 0\n");
                }
                data = (data >> 2);
                printf("- Base Address: %x\n", data);
            }
            printf("---\n");
        }
    }
}

void printIOLimitBase(unsigned int address)
{
    unsigned int data;

    outl(address + 0x1C, 0xCF8);
    data = inl(0xCFC);

	conv.int32 = data;
	if (conv.int32 != 0)
    {
        printf("I/O Limit: %x\n", conv.int8[2]);
        printf("I/O Base: %x\n", conv.int8[3]);
    } else
    {
        outl(address + 0x1C, 0xCF8);
        data = inl(0xCFC);
        conv.int32 = data;
        if (conv.int32 != 0) {
            printf("Oldest part of the address: \n");
            printf("I/O Limit Upper 16 bits: %x\n", conv.int16[0]);
            printf("I/O Base Upper 16 bits: %x\n", conv.int16[1]);
        } else {
            printf("I/O Limit: 0\n");
            printf("I/O Limit Upper 16 bits: 0\n");
            printf("I/O Base: 0\n");
            printf("I/O Base Upper 16 bits: 0\n");
        }
    }
}

void printIntLinePin(unsigned int address)
{
    unsigned int data;

    outl(address + 0x3C, 0xCF8);
    data = inl(0xCFC);

	conv.int32 = data;
	if (conv.int16[1] != 0)
    {
        printf("Interrupt Pin: %u\n", conv.int8[0]);
        printf("Interrupt Line: %u\n", conv.int8[1]);
    } else
    {
        printf("No interruptions produced by bridge\n");
    }
}

int main(void)
{
	unsigned int address;
	//address = 0b10000000 00000000 00000 000 000000 0 0;
	// funcid = 000
	// devid  = 0000 0
	// busid  = 0000 0000

	unsigned int busid = address, devid, funcid, data, reg;
	printf("\nStarting to parse\n");
	iopl((3));
	for (busid = 0; busid < 256; busid++)
	{
		for (devid = 0; devid < 32; devid++)
		{
			for (funcid = 0; funcid < 8; funcid++)
			{
				address = 0x80000000;
				address = address | (busid << 16);
				address = address | (devid << 11);
				address = address | (funcid << 8);
				outl(address, 0xCF8);
                data = inl(0xCFC);
				if (data != 0xFFFFFFFF)
				{
					printf("%x:%x.%x\n", busid, devid, funcid);
					printDevVen(&data);
					// MOCT?
					/*for (reg = address; reg < address + 0x3C; reg += 0x04) {
                        outl(reg, 0xCF8);
                        data = inl(0xCFC);
                        printf("register:%x;;;data:%x;;;\n", reg, data);
					}*/
                    outl(address | (0x0C & 0xfc), 0xCF8);
                    data = inl(0xCFC);
					if (!(data & 0x10000)) // 0x800000 // 0x10000
					{
					    printf("not bridge\n\n");
                        printBars(address);

					} else {
                        printf("bridge\n\n");
                        printIOLimitBase(address);
                        printIntLinePin(address);
					}
					printf("------------------------------------------------------------\n");
				}
			}
		}
	}
	printf("Ended parsing\n");
	return 0;
}




