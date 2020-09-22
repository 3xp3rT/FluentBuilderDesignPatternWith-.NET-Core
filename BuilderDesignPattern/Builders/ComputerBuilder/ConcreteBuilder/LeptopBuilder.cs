using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuilderDesignPattern.Builders.ComputerBuilder.ConcreteBuilder
{
    public class LeptopBuilder : IComputerSystemBuilder
    {

        ComputerSystem leptop = new ComputerSystem();

        public IComputerSystemBuilder AddDrive(string Size)
        {
            leptop.HardDrive = Size;
            return this;
        }

        public IComputerSystemBuilder AddGraphics(string Size)
        {
            leptop.GraphicsCard = Size;
            return this;

        }

        public IComputerSystemBuilder AddKeboard(string type)
        {
            return this;
            
        }

        public IComputerSystemBuilder AddMonitor(string size)
        {
            return this;
            
        }

        public IComputerSystemBuilder AddMouse(string type)
        {
            return this;

        }

        public IComputerSystemBuilder AddRAM(string RAM)
        {
            leptop.RAM = RAM;
            return this;

        }

        public ComputerSystem GetSystem()
        {
            return leptop;
        }
    }
}
