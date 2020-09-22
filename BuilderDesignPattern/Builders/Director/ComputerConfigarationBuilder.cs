using BuilderDesignPattern.Builders.ComputerBuilder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace BuilderDesignPattern.Builders.Director
{
    public class ComputerConfigarationBuilder
    {
        public void BuildSystem(IComputerSystemBuilder systemBuilder, IFormCollection collection)
        {
            systemBuilder.AddDrive(collection["HardDrive"])
            .AddGraphics(collection["GraphicsCard"])
            .AddKeboard(collection["Keyborad"])
            .AddMonitor(collection["Monitor"])
            .AddMouse(collection["Mouse"])
            .AddRAM(collection["RAM"]);
        }

       
    }
}
