using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuilderDesignPattern.Builders.ComputerBuilder
{
   public  interface IComputerSystemBuilder
    {
        IComputerSystemBuilder AddRAM(string RAM);
        IComputerSystemBuilder AddDrive(string Size);
        IComputerSystemBuilder AddGraphics(string Size);
        IComputerSystemBuilder AddKeboard(string type);
        IComputerSystemBuilder AddMouse(string type);
        IComputerSystemBuilder AddMonitor(string size);
        ComputerSystem GetSystem();
    }
}
