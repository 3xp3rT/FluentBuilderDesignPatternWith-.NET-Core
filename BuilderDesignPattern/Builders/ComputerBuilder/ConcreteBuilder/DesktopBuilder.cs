using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuilderDesignPattern.Builders.ComputerBuilder.ConcreteBuilder
{
    public class DesktopBuilder : IComputerSystemBuilder
    {
        ComputerSystem desktop = new ComputerSystem();
        public IComputerSystemBuilder AddDrive(string Size)
        {
            desktop.HardDrive = Size;
            return this;
        }

        public IComputerSystemBuilder AddGraphics(string Size)
        {
            desktop.GraphicsCard = Size;
            return this;

        }

        public IComputerSystemBuilder AddKeboard(string type)
        {
            desktop.Keyborad = type;
            return this;

        }

        public IComputerSystemBuilder AddMonitor(string size)
        {
            desktop.Monitor = size;
            return this;

        }

        public IComputerSystemBuilder AddMouse(string type)
        {
            desktop.Mouse = type;
            return this;

        }

        public IComputerSystemBuilder AddRAM(string RAM)
        {
            desktop.RAM = RAM;
            return this;

        }

        public ComputerSystem GetSystem()
        {
            return desktop;
        }
    }
}
